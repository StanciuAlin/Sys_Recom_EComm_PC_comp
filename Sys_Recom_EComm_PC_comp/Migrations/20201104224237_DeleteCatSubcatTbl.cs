using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sys_Recom_EComm_PC_comp.Migrations
{
    public partial class DeleteCatSubcatTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatSubcats");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CatSubcats",
                columns: table => new
                {
                    CatSubcatID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubcategoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatSubcats", x => x.CatSubcatID);
                });
        }
    }
}
