﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace WebApplication.Models
{
    public class CandidateContext : DbContext
    {
        public DbSet<Candidate> Candidates { get; set; }

        public CandidateContext(DbContextOptions<CandidateContext> options) : base(options) { }
    }
}
