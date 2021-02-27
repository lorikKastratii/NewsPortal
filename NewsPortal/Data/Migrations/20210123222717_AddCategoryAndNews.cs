using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsPortal.Data.Migrations
{
    public partial class AddCategoryAndNews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "News");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "News",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "News",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "News",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_News_CategoryId",
                table: "News",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_News_Category_CategoryId",
                table: "News",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_Category_CategoryId",
                table: "News");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_News_CategoryId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "News");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "News",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "News",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "News",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
