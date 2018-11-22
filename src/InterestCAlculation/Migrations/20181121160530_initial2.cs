using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InterestCAlculation.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "BaseRate",
                table: "Agreements",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "PersonalId",
                table: "Customers",
                maxLength: 11,
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BaseRate",
                table: "Agreements");

            migrationBuilder.AlterColumn<int>(
                name: "PersonalId",
                table: "Customers",
                maxLength: 11,
                nullable: false);
        }
    }
}
