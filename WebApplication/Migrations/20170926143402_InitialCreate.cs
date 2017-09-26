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
                name: "candidates",
                schema: "Candidate",
                columns: table => new
                {
                    CandidateId = table.Column<long>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CandidateCity = table.Column<string>(type: "nvarchar(45)", nullable: false),
                    CandidateCountry = table.Column<string>(type: "nvarchar(45)", nullable: false),
                    CandidateCV = table.Column<byte[]>(type: "varbinary(1000)", nullable: true),
                    CandidateEmail = table.Column<string>(type: "nvarchar(45)", nullable: false),
                    CandidateState = table.Column<string>(type: "nvarchar(45)", nullable: false),
                    CandidateName = table.Column<string>(type: "nvarchar(45)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_candidates", x => x.CandidateId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "candidates",
                schema: "Candidate");
        }
    }
}
