using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebApplication.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Candidate");

            migrationBuilder.CreateTable(
                name: "candidate",
                schema: "Candidate",
                columns: table => new
                {
                    CandidateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CandidateCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CandidateCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CandidateCV = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CandidateEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CandidateState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CandidateName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_candidate", x => x.CandidateId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "candidate",
                schema: "Candidate");
        }
    }
}
