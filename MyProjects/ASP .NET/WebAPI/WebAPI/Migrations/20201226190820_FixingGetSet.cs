using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class FixingGetSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Album_Band_BandID",
                table: "Album");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Band",
                table: "Band");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Album",
                table: "Album");

            migrationBuilder.RenameTable(
                name: "Band",
                newName: "Bands");

            migrationBuilder.RenameTable(
                name: "Album",
                newName: "Albums");

            migrationBuilder.RenameIndex(
                name: "IX_Album_BandID",
                table: "Albums",
                newName: "IX_Albums_BandID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bands",
                table: "Bands",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Albums",
                table: "Albums",
                column: "AlbumID");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Bands_BandID",
                table: "Albums",
                column: "BandID",
                principalTable: "Bands",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Bands_BandID",
                table: "Albums");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bands",
                table: "Bands");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Albums",
                table: "Albums");

            migrationBuilder.RenameTable(
                name: "Bands",
                newName: "Band");

            migrationBuilder.RenameTable(
                name: "Albums",
                newName: "Album");

            migrationBuilder.RenameIndex(
                name: "IX_Albums_BandID",
                table: "Album",
                newName: "IX_Album_BandID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Band",
                table: "Band",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Album",
                table: "Album",
                column: "AlbumID");

            migrationBuilder.AddForeignKey(
                name: "FK_Album_Band_BandID",
                table: "Album",
                column: "BandID",
                principalTable: "Band",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
