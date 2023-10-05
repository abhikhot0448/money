using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dhanman.Money.Persistence.Migrations.Application
{
    /// <inheritdoc />
    public partial class customers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                name: "city",
                table: "customers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "phone_number",
                table: "customers",
                type: "character varying(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "city",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "phone_number",
                table: "customers");

        }
    }
}
