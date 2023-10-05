using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dhanman.money.Persistence.Migrations.Application
{
    /// <inheritdoc />
    public partial class invoice_Header : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "invoice_header_id",
                table: "invoice_headers");

            migrationBuilder.AlterColumn<int>(
                name: "payment_term",
                table: "invoice_headers",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<decimal>(
                name: "discount",
                table: "invoice_headers",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "note",
                table: "invoice_headers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "tax",
                table: "invoice_headers",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "total_amount",
                table: "invoice_headers",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "discount",
                table: "invoice_headers");

            migrationBuilder.DropColumn(
                name: "note",
                table: "invoice_headers");

            migrationBuilder.DropColumn(
                name: "tax",
                table: "invoice_headers");

            migrationBuilder.DropColumn(
                name: "total_amount",
                table: "invoice_headers");

            migrationBuilder.AlterColumn<int>(
                name: "payment_term",
                table: "invoice_headers",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "invoice_header_id",
                table: "invoice_headers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
