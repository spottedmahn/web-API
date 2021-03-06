﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    [Table(name: "candidate")]
    public class Candidate
    {
        [Key]
        [Column(name: "id", TypeName = "int", Order = 0)]
        public int CandidateId { get; set; }

        [Required]
        [Column(name: "name", TypeName = "nvarchar(max)", Order = 1)]
        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        [Column(name: "email", TypeName = "nvarchar(max)", Order = 2)]
        public string Email { get; set; }

        [Required]
        [Column(name: "city", TypeName = "nvarchar(max)", Order = 3)]
        public string City { get; set; }

        [Required]
        [Column(name: "state", TypeName = "nvarchar(max)", Order = 4)]
        public string State { get; set; }

        [Required]
        [Column(name: "country", TypeName = "nvarchar(max)", Order = 5)]
        public string Country { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name: "id_file", TypeName = "uniqueidentifier ROWGUIDCOL", Order = 6)]
        public Guid FileId { get; set; }

        [Required]
        [Column(name: "curriculum_vitae", TypeName = "varbinary(max) FILESTREAM", Order = 7)]
        public byte[] CurriculumVitae { get; set; }
    }
}
