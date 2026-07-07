using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace task21.Migrations
{
    /// <inheritdoc />
    public partial class addsubscriptionLeveltouser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SubscriptionLevel",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubscriptionLevel",
                table: "AspNetUsers");
        }
    }
}
