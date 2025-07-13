using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PitStop.Core.Migrations
{
    /// <inheritdoc />
    public partial class CreateCustomerTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    cus_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cus_type_id = table.Column<short>(type: "smallint", nullable: true),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    lastname = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    address = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    city = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    state = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    telephone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    mobile = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    gdpr = table.Column<bool>(type: "boolean", nullable: false),
                    gdpr_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    gdpr_allow_letter_flag = table.Column<bool>(type: "boolean", nullable: true),
                    gdpr_allow_call_flag = table.Column<bool>(type: "boolean", nullable: true),
                    gdpr_allow_sms_flag = table.Column<bool>(type: "boolean", nullable: true),
                    gdpr_allow_email_flag = table.Column<bool>(type: "boolean", nullable: true),
                    gdpr_allow_analytic_flag = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.cus_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_customer_lastname",
                table: "customer",
                column: "lastname");

            migrationBuilder.CreateIndex(
                name: "IX_customer_mobile",
                table: "customer",
                column: "mobile");

            migrationBuilder.CreateIndex(
                name: "IX_customer_telephone",
                table: "customer",
                column: "telephone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customer");
        }
    }
}
