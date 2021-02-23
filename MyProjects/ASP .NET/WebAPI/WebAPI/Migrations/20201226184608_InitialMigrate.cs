using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class InitialMigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Band",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Genre = table.Column<string>(nullable: true),
                    Founded = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Band", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Album",
                columns: table => new
                {
                    AlbumID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 20, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    BandID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Album", x => x.AlbumID);
                    table.ForeignKey(
                        name: "FK_Album_Band_BandID",
                        column: x => x.BandID,
                        principalTable: "Band",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Band",
                columns: new[] { "ID", "Founded", "Genre", "Name" },
                values: new object[] { 1, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Genre1", "FirstBand" });

            migrationBuilder.InsertData(
                table: "Band",
                columns: new[] { "ID", "Founded", "Genre", "Name" },
                values: new object[] { 2, new DateTime(2001, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Genre2", "SecondBand" });

            migrationBuilder.InsertData(
                table: "Album",
                columns: new[] { "AlbumID", "BandID", "Description", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Description of Album 1", "Album1" },
                    { 2, 1, "Description of Album 2", "Album2" },
                    { 3, 2, "Description of Album 3", "Album3" },
                    { 4, 2, "Description of Album 4", "Album4" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Album_BandID",
                table: "Album",
                column: "BandID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Album");

            migrationBuilder.DropTable(
                name: "Band");
        }
    }
}
