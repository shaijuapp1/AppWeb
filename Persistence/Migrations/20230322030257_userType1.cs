using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class userType1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomValidationId",
                table: "UserTypes");

            migrationBuilder.DropColumn(
                name: "DataSecurityId",
                table: "UserTypes");

            migrationBuilder.DropColumn(
                name: "FiledType",
                table: "UserTypes");

            migrationBuilder.DropColumn(
                name: "Required",
                table: "UserTypes");

            migrationBuilder.DropColumn(
                name: "TableId",
                table: "UserTypes");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "DataSecuritys");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "UserTypes",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "FideldName",
                table: "UserTypes",
                newName: "Type");

            migrationBuilder.AddColumn<string>(
                name: "GrpId",
                table: "UserTypes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserListID",
                table: "DataSecuritys",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RoleMasters",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleMasters", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleMasters");

            migrationBuilder.DropColumn(
                name: "GrpId",
                table: "UserTypes");

            migrationBuilder.DropColumn(
                name: "UserListID",
                table: "DataSecuritys");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserTypes",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "UserTypes",
                newName: "FideldName");

            migrationBuilder.AddColumn<int>(
                name: "CustomValidationId",
                table: "UserTypes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DataSecurityId",
                table: "UserTypes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FiledType",
                table: "UserTypes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Required",
                table: "UserTypes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TableId",
                table: "UserTypes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "DataSecuritys",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
