using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Library.Data.Migrations
{
    public partial class pricelist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumbers",
                table: "Employees",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.CreateTable(
                name: "LibServiceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Order = table.Column<int>(nullable: false),
                    ServiceNameBg = table.Column<string>(maxLength: 100, nullable: false),
                    ServiceNameEn = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibServiceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LibServiceDescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DescriptionBg = table.Column<string>(maxLength: 700, nullable: true),
                    DescriptionEn = table.Column<string>(maxLength: 700, nullable: true),
                    LibServiceTypeId = table.Column<int>(nullable: false),
                    Order = table.Column<int>(nullable: false),
                    PriceInfoBg = table.Column<string>(maxLength: 80, nullable: true),
                    PriceInfoEn = table.Column<string>(maxLength: 80, nullable: true),
                    ServiceTypeBg = table.Column<string>(maxLength: 100, nullable: false),
                    ServiceTypeEn = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibServiceDescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LibServiceDescriptions_LibServiceTypes_LibServiceTypeId",
                        column: x => x.LibServiceTypeId,
                        principalTable: "LibServiceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LibServiceDescriptions_LibServiceTypeId",
                table: "LibServiceDescriptions",
                column: "LibServiceTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LibServiceDescriptions");

            migrationBuilder.DropTable(
                name: "LibServiceTypes");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumbers",
                table: "Employees",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
