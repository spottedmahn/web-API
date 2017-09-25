using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication.Controllers
{
    [Route("api/cadidate")]
    public class CandidateController : Controller
    {
        private readonly CandidateContext _context;

        public CandidateController(CandidateContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Candidate> GetAll() => _context.Candidates.ToList();

        [HttpGet("{id}", Name = "GetCandidate")]
        public IActionResult GetById(long id)
        {
            var item = _context.Candidates.FirstOrDefault(candidate => candidate.Id == id);
            if (item == null) { NotFound(); }
            return new ObjectResult(item);
        }

        [HttpPost]
        public void Post([FromBody]string value)
        {
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
