using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Library.Data.Migrations
{
    public partial class WorkSchedules : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepartmentNameBg = table.Column<string>(maxLength: 150, nullable: false),
                    DepartmentNameEn = table.Column<string>(maxLength: 150, nullable: false),
                    SaturdayBg = table.Column<string>(maxLength: 150, nullable: false),
                    SaturdayEn = table.Column<string>(maxLength: 150, nullable: false),
                    SundayBg = table.Column<string>(maxLength: 150, nullable: false),
                    SundayEn = table.Column<string>(maxLength: 150, nullable: false),
                    WorkdaysBg = table.Column<string>(maxLength: 150, nullable: false),
                    WorkdaysEn = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkSchedules", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkSchedules");
        }
    }
}
