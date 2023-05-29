using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HueFestival_OnlineTicket.Migrations
{
    /// <inheritdoc />
    public partial class NewUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "TicketBooks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_AccountId",
                table: "Roles",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Accounts_AccountId",
                table: "Roles",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Accounts_AccountId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_AccountId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "TicketBooks");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Accounts");
        }
    }
}
