using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nibo.ConciliatorOFX.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BankAccounts",
                columns: table => new
                {
                    BankAccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankId = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<long>(type: "bigint", nullable: false),
                    AccountType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.BankAccountId);
                });

            migrationBuilder.CreateTable(
                name: "BankTransactionsLists",
                columns: table => new
                {
                    BankTransactionsListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankTransactionsLists", x => x.BankTransactionsListId);
                });

            migrationBuilder.CreateTable(
                name: "LedgerBalanceAggregates",
                columns: table => new
                {
                    LedgerBalanceAggregateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LedgerBalanceAggregates", x => x.LedgerBalanceAggregateId);
                });

            migrationBuilder.CreateTable(
                name: "BankTransactions",
                columns: table => new
                {
                    BankTransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionType = table.Column<int>(type: "int", nullable: false),
                    PostedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Memo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankTransactionsListId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankTransactions", x => x.BankTransactionId);
                    table.ForeignKey(
                        name: "FK_BankTransactions_BankTransactionsLists_BankTransactionsListId",
                        column: x => x.BankTransactionsListId,
                        principalTable: "BankTransactionsLists",
                        principalColumn: "BankTransactionsListId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BankStatements",
                columns: table => new
                {
                    BankStatementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankAccountId = table.Column<int>(type: "int", nullable: true),
                    BankTransactionsListId = table.Column<int>(type: "int", nullable: true),
                    LedgerBalanceAggregateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankStatements", x => x.BankStatementId);
                    table.ForeignKey(
                        name: "FK_BankStatements_BankAccounts_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "BankAccounts",
                        principalColumn: "BankAccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BankStatements_BankTransactionsLists_BankTransactionsListId",
                        column: x => x.BankTransactionsListId,
                        principalTable: "BankTransactionsLists",
                        principalColumn: "BankTransactionsListId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BankStatements_LedgerBalanceAggregates_LedgerBalanceAggregateId",
                        column: x => x.LedgerBalanceAggregateId,
                        principalTable: "LedgerBalanceAggregates",
                        principalColumn: "LedgerBalanceAggregateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankStatements_BankAccountId",
                table: "BankStatements",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_BankStatements_BankTransactionsListId",
                table: "BankStatements",
                column: "BankTransactionsListId");

            migrationBuilder.CreateIndex(
                name: "IX_BankStatements_LedgerBalanceAggregateId",
                table: "BankStatements",
                column: "LedgerBalanceAggregateId");

            migrationBuilder.CreateIndex(
                name: "IX_BankTransactions_BankTransactionsListId",
                table: "BankTransactions",
                column: "BankTransactionsListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankStatements");

            migrationBuilder.DropTable(
                name: "BankTransactions");

            migrationBuilder.DropTable(
                name: "BankAccounts");

            migrationBuilder.DropTable(
                name: "LedgerBalanceAggregates");

            migrationBuilder.DropTable(
                name: "BankTransactionsLists");
        }
    }
}
