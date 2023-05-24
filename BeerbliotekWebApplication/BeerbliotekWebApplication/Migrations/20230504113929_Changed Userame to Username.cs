using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeerbliotekWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class ChangedUserametoUsername : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Userame",
                table: "Accounts",
                newName: "Username");

            migrationBuilder.CreateTable(
                name: "Beers2",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Alcohol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Volume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beers2", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Beers2");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Accounts",
                newName: "Userame");
        }
    }
}
