using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.IO;
using Microsoft.EntityFrameworkCore;

using static System.Console;
using Microsoft.AspNetCore.Cors;

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

        [HttpGet("candidates")]
        public JsonResult GetAll() => 
            Json(dataBase.Candidates.ToList());

        [HttpGet("{id}", Name = "candidate")]
        public async Task<IActionResult> Get(int? id)
        {
            if (id == null)
                return NotFound();

            var item = await dataBase.Candidates.Where(candidate => candidate.Id == id).FirstOrDefaultAsync();

            if (item == null)
                return NotFound();

            return Json(item);
        }

        [HttpPost("candidate")]
        public async Task<IActionResult> Post(IFormFile file)
        {
            var json = HttpContext.Request.Form["Candidates"];
            var jsonTextReader = new JsonTextReader(new StringReader(json));
            var candidates = new JsonSerializer().Deserialize<Candidate>(jsonTextReader);

            if (!ModelState.IsValid) 
                return BadRequest();
            
            using (var memoryStream = new MemoryStream())
            {
                await file.OpenReadStream().CopyToAsync(memoryStream);
                candidates.CurriculumVitae = memoryStream.ToArray();
            }
            await dataBase.AddAsync(candidates);
            dataBase.SaveChanges();
            return Ok(candidates);
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
                var candidate = new Candidate { Id = (int) id };

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
