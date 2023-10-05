using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dhanman.money.Persistence.Migrations.Application
{
    /// <inheritdoc />
    public partial class invoiceHeader : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "invoice_headers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    coa_id = table.Column<Guid>(type: "uuid", nullable: false),
                    invoice_number = table.Column<string>(type: "text", nullable: false),
                    invoice_voucher = table.Column<string>(type: "text", nullable: false),
                    invoice_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    payment_term = table.Column<int>(type: "integer", nullable: true),
                    invoice_status_id = table.Column<Guid>(type: "uuid", nullable: false),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    currency = table.Column<string>(type: "text", nullable: false),
                    invoice_payment_id = table.Column<Guid>(type: "uuid", nullable: false),
                    due_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    client_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    tax = table.Column<decimal>(type:"numeric",nullable:true),
                    discount = table.Column<decimal>(type: "numeric", nullable: true),
                    total_amount = table.Column<decimal>(type: "numeric", nullable: false),
                    note = table.Column<string>(type:"text",nullable:true),
                    created_on_utc = table.Column<DateTime>(type: "timestamp", nullable: false),
                    modified_on_utc = table.Column<DateTime>(type: "timestamp", nullable: true),
                    deleted_on_utc = table.Column<DateTime>(type: "timestamp", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_invoice_headers", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "invoice_headers");
        }
    }
}
