using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HueFestival_OnlineTicket.Migrations
{
    /// <inheritdoc />
    public partial class UpdateQrCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TicketBookId",
                table: "Tickets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TickId",
                table: "TicketBooks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TicketBookId",
                table: "Tickets",
                column: "TicketBookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketBooks_TicketBookId",
                table: "Tickets",
                column: "TicketBookId",
                principalTable: "TicketBooks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketBooks_TicketBookId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_TicketBookId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "TicketBookId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "TickId",
                table: "TicketBooks");
        }
    }
}
