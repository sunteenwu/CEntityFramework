using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _51EntityCoreMany.Migrations
{
    public partial class Mymanytomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ModelImages",
                columns: table => new
                {
                    ModelImageId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelImages", x => x.ModelImageId);
                });

            migrationBuilder.CreateTable(
                name: "ModelTags",
                columns: table => new
                {
                    ModelTagId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelTags", x => x.ModelTagId);
                });

            migrationBuilder.CreateTable(
                name: "ModelImageTag",
                columns: table => new
                {
                    ModelImageId = table.Column<int>(nullable: false),
                    ModelTagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelImageTag", x => new { x.ModelImageId, x.ModelTagId });
                    table.ForeignKey(
                        name: "FK_ModelImageTag_ModelImages_ModelImageId",
                        column: x => x.ModelImageId,
                        principalTable: "ModelImages",
                        principalColumn: "ModelImageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModelImageTag_ModelTags_ModelTagId",
                        column: x => x.ModelTagId,
                        principalTable: "ModelTags",
                        principalColumn: "ModelTagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModelImageTag_ModelTagId",
                table: "ModelImageTag",
                column: "ModelTagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModelImageTag");

            migrationBuilder.DropTable(
                name: "ModelImages");

            migrationBuilder.DropTable(
                name: "ModelTags");
        }
    }
}
