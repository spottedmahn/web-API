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

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var item = _context.Candidates.FirstOrDefault(candidate => candidate.Id == id);
            if (item == null) { NotFound(); }
            return new ObjectResult(item);
        }
    }
}
