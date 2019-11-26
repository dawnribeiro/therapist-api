using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace therapist_api.Migrations
{
    public partial class InitialCreateWithTableSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Therapists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    LastName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    WorkPhone = table.Column<int>(nullable: false),
                    HomePhone = table.Column<int>(nullable: false),
                    Street = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    P101 = table.Column<DateTime>(nullable: false),
                    S1 = table.Column<DateTime>(nullable: false),
                    S2 = table.Column<DateTime>(nullable: false),
                    S3 = table.Column<DateTime>(nullable: false),
                    S4 = table.Column<DateTime>(nullable: false),
                    P202 = table.Column<DateTime>(nullable: false),
                    N1 = table.Column<DateTime>(nullable: false),
                    N2 = table.Column<DateTime>(nullable: false),
                    N3 = table.Column<DateTime>(nullable: false),
                    N4 = table.Column<DateTime>(nullable: false),
                    Bach = table.Column<string>(nullable: true),
                    Certified = table.Column<string>(nullable: true),
                    SeminarsTaken = table.Column<string>(nullable: true),
                    Website = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Therapists", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Therapists");
        }
    }
}
