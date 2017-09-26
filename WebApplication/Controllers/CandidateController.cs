using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.IO;
using WebApplication.Helpers;

namespace WebApplication.Controllers
{
    [Route("api")]
    public class CandidateController : Controller
    {
        private readonly CandidateContext _context;

        public CandidateController(CandidateContext context)
        {
            _context = context;
        }

        [HttpGet("/cadidate")]
        public IEnumerable<Candidate> GetAll() => _context.Candidates.ToList();

        [HttpGet("{id}", Name = "candidate")]
        public IActionResult GetById(long id)
        {
            var item = _context.Candidates.FirstOrDefault(candidate => candidate.Id == id);
            if (item == null) { NotFound(); }
            return new ObjectResult(item);
        }

        [HttpPost("/candidate")]
        public IActionResult Post()
        {
            var httpRequest = HttpContext.Request;

            var json = HttpContext.Request.Headers["Candidates"];

            var jsonSerializer = new JsonSerializer();
            var candidates = jsonSerializer.Deserialize<Candidate>(new JsonTextReader(new StringReader(json)));

            using (var memoryStream = new MemoryStream())
            {
                //var candidateHelper = new CandidateHelper();
                //candidateHelper.IFormCurriculum.CopyTo(memoryStream);

                //candidates.CurriculumVitae = memoryStream.ToArray();
                _context.Add(candidates);
                _context.SaveChanges();
                return Ok(candidates);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
