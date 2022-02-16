using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Net5.Deployment.API.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alumno",
                columns: table => new
                {
                    AlumnoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Nombres = table.Column<string>(type: "varchar(75)", nullable: false),
                    Apellidos = table.Column<string>(type: "varchar(75)", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Nivel = table.Column<string>(type: "varchar(75)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumno", x => x.AlumnoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alumno");
        }
    }
}
