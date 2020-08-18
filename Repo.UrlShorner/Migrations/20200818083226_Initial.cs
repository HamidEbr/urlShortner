using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repo.UrlShorner.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UrlDatas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newid()"),
                    OriginalURL = table.Column<string>(nullable: false),
                    ShortenedURL = table.Column<string>(nullable: false),
                    Token = table.Column<string>(nullable: false),
                    Visits = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrlDatas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UrlDatas_ShortenedURL",
                table: "UrlDatas",
                column: "ShortenedURL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UrlDatas_Token",
                table: "UrlDatas",
                column: "Token",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UrlDatas");
        }
    }
}
