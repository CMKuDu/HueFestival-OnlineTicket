using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HueFestival_OnlineTicket.Migrations
{
    /// <inheritdoc />
    public partial class DeleteTranId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketBooks_Customers_CustomerId",
                table: "TicketBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacstatus_TicketBooks_TicketBookId",
                table: "Transacstatus");

            migrationBuilder.DropIndex(
                name: "IX_Transacstatus_TicketBookId",
                table: "Transacstatus");

            migrationBuilder.DropIndex(
                name: "IX_TicketBooks_CustomerId",
                table: "TicketBooks");

            migrationBuilder.DropColumn(
                name: "TicketBookId",
                table: "Transacstatus");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "TicketBooks");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "TicketBooks");

            migrationBuilder.DropColumn(
                name: "Money",
                table: "TicketBooks");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "TicketBooks");

            migrationBuilder.DropColumn(
                name: "Transacstatus",
                table: "TicketBooks");

            migrationBuilder.AddColumn<int>(
                name: "TicketBookId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_TicketBookId",
                table: "Customers",
                column: "TicketBookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_TicketBooks_TicketBookId",
                table: "Customers",
                column: "TicketBookId",
                principalTable: "TicketBooks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_TicketBooks_TicketBookId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_TicketBookId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "TicketBookId",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "TicketBookId",
                table: "Transacstatus",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "TicketBooks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TicketBooks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Money",
                table: "TicketBooks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "TicketBooks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Transacstatus",
                table: "TicketBooks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transacstatus_TicketBookId",
                table: "Transacstatus",
                column: "TicketBookId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketBooks_CustomerId",
                table: "TicketBooks",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketBooks_Customers_CustomerId",
                table: "TicketBooks",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transacstatus_TicketBooks_TicketBookId",
                table: "Transacstatus",
                column: "TicketBookId",
                principalTable: "TicketBooks",
                principalColumn: "Id");
        }
    }
}
