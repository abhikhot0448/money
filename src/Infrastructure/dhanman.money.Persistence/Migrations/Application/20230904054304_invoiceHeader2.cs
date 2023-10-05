using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dhanman.money.Persistence.Migrations.Application
{
    /// <inheritdoc />
    public partial class invoiceHeader2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.AddColumn<string>(
                name: "currency",
                table: "invoice_headers",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "currency",
                table: "invoice_headers");

           
        }
    }
}
