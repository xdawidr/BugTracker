using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BugTracker.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddCommentsAndBugClassExtension : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Bugs",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    BugId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    InactivatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InactivedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Bugs_BugId",
                        column: x => x.BugId,
                        principalTable: "Bugs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Bugs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Image" },
                values: new object[] { new DateTime(2023, 8, 30, 10, 34, 4, 442, DateTimeKind.Local).AddTicks(2913), null });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 30, 10, 34, 4, 442, DateTimeKind.Local).AddTicks(2213));

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BugId",
                table: "Comments",
                column: "BugId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProjectId",
                table: "Comments",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Bugs");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Bugs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 9, 16, 53, 31, 96, DateTimeKind.Local).AddTicks(7037));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 9, 16, 53, 31, 96, DateTimeKind.Local).AddTicks(6821));
        }
    }
}
