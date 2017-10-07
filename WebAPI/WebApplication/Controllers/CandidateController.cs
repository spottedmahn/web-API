using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.IO;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.Controllers
{
    [Route("api")]
    [Produces("aplication/json")]
    [Consumes("application/json", "application/json-patch+json", "multipart/form-data")]
    public class CandidateController : Controller
    {
        private readonly CandidateContext dataBase;

        public CandidateController(CandidateContext context) => 
            dataBase = context;

        [HttpGet("candidate")]
        public IEnumerable<Candidate> GetAll() => 
            dataBase.Candidates.ToList();

        [HttpGet("{id}", Name = "candidate")]
        public IActionResult GetById(long? id)
        {
            var item = dataBase.Candidates.FirstOrDefault(candidate => candidate.Id == id);

            if (item == null)
                NotFound();

            return new ObjectResult(item);
        }

        [HttpPost("candidate")]
        public async Task<IActionResult> Post(IFormFile file)
        {
            var httpRequest = HttpContext.Request;

            var json = HttpContext.Request.Form["Candidates"];

            var candidates = new JsonSerializer()
                .Deserialize<Candidate>(new JsonTextReader(new StringReader(json)));

            if (ModelState.IsValid)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await file.OpenReadStream().CopyToAsync(memoryStream);
                    candidates.CurriculumVitae = memoryStream.ToArray();
                }
                await dataBase.AddAsync(candidates);
                dataBase.SaveChanges();

                return Ok(candidates);
            }
            return BadRequest();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                Candidate candidate = new Candidate { Id = (int) id };

                dataBase.Entry(candidate).State = EntityState.Deleted;
                await dataBase.SaveChangesAsync();

                return Ok(candidate);
            }
            catch(DbUpdateConcurrencyException)
            {
                return NotFound();
            }
        }
    }
}
