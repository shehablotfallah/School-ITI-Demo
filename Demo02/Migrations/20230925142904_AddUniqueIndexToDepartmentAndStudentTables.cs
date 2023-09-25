using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo02.Migrations
{
	public partial class AddUniqueIndexToDepartmentAndStudentTables : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<string>(
				name: "Email",
				table: "Students",
				type: "nvarchar(450)",
				nullable: false,
				oldClrType: typeof(string),
				oldType: "nvarchar(max)");

			migrationBuilder.CreateIndex(
				name: "IX_Students_Email",
				table: "Students",
				column: "Email",
				unique: true);

			migrationBuilder.CreateIndex(
				name: "IX_Departments_Name",
				table: "Departments",
				column: "Name",
				unique: true);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropIndex(
				name: "IX_Students_Email",
				table: "Students");

			migrationBuilder.DropIndex(
				name: "IX_Departments_Name",
				table: "Departments");

			migrationBuilder.AlterColumn<string>(
				name: "Email",
				table: "Students",
				type: "nvarchar(max)",
				nullable: false,
				oldClrType: typeof(string),
				oldType: "nvarchar(450)");
		}
	}
}
