using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo02.Migrations
{
	public partial class AddLastUpdatedOnToBaseModelClass : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<DateTime>(
				name: "LastUpdatedOn",
				table: "Students",
				type: "datetime2",
				nullable: true);

			migrationBuilder.AddColumn<DateTime>(
				name: "LastUpdatedOn",
				table: "Departments",
				type: "datetime2",
				nullable: true);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "LastUpdatedOn",
				table: "Students");

			migrationBuilder.DropColumn(
				name: "LastUpdatedOn",
				table: "Departments");
		}
	}
}
