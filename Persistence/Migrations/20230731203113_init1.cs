using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    UID = table.Column<Guid>(type: "Guid", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Patronymic = table.Column<string>(type: "TEXT", nullable: true),
                    Telephone = table.Column<string>(type: "TEXT", nullable: true),
                    Passport = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.UID);
                });

            migrationBuilder.CreateTable(
                name: "TypeAccounts",
                columns: table => new
                {
                    UID = table.Column<Guid>(type: "Guid", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeAccounts", x => x.UID);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    UID = table.Column<Guid>(type: "Guid", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    DateOpen = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Procent = table.Column<int>(type: "INTEGER", nullable: false),
                    CountMonetaryUnit = table.Column<decimal>(type: "TEXT", nullable: false),
                    TypeAccountId = table.Column<Guid>(type: "Guid", nullable: false),
                    IsLock = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsClose = table.Column<bool>(type: "INTEGER", nullable: false),
                    ClientId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.UID);
                    table.ForeignKey(
                        name: "FK_Accounts_TypeAccounts_TypeAccountId",
                        column: x => x.TypeAccountId,
                        principalTable: "TypeAccounts",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_TypeAccountId",
                table: "Accounts",
                column: "TypeAccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "TypeAccounts");
        }
    }
}
