using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HueFestival_OnlineTicket.Migrations
{
    /// <inheritdoc />
    public partial class LocationId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TicketBookId",
                table: "Transacstatus",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transacstatus_TicketBookId",
                table: "Transacstatus",
                column: "TicketBookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transacstatus_TicketBooks_TicketBookId",
                table: "Transacstatus",
                column: "TicketBookId",
                principalTable: "TicketBooks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transacstatus_TicketBooks_TicketBookId",
                table: "Transacstatus");

            migrationBuilder.DropIndex(
                name: "IX_Transacstatus_TicketBookId",
                table: "Transacstatus");

            migrationBuilder.DropColumn(
                name: "TicketBookId",
                table: "Transacstatus");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Customers");
        }
    }
}
