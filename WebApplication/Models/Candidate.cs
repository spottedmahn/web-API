using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    [Table("candidates", Schema = "Candidate")]
    public class Candidate
    {
        [Key]
        [Column("CandidateId", TypeName = "int")]
        public long Id { get; set; }

        [Required]
        [Column("CandidateName", TypeName = "nvarchar(45)")]
        public string Name { get; set; }

        [Required]
        [Column("CandidateEmail", TypeName = "nvarchar(45)")]
        public string Email { get; set; }

        [Required]
        [Column("CandidateCity", TypeName = "nvarchar(45)")]
        public string City { get; set; }

        [Required]
        [Column("CandidateState", TypeName = "nvarchar(45)")]
        public string Estate { get; set; }

        [Required]
        [Column("CandidateCountry", TypeName = "nvarchar(45)")]
        public string Country { get; set; }

        [Column("CandidateCV", TypeName = "varbinary(1000)")]
        public byte[] CurriculumVitae { get; set; }
    }
}
