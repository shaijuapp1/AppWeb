using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class TableField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserOrGrpId",
                table: "UserTypes",
                newName: "TableId");

            migrationBuilder.RenameColumn(
                name: "TypeId",
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

            migrationBuilder.CreateTable(
                name: "TableFields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TableId = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    FiledType = table.Column<int>(type: "integer", nullable: false),
                    FideldName = table.Column<string>(type: "text", nullable: true),
                    DataSecurityId = table.Column<int>(type: "integer", nullable: false),
                    Required = table.Column<bool>(type: "boolean", nullable: false),
                    CustomValidationId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableFields", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TableFields");

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

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "UserTypes",
                newName: "TypeId");

            migrationBuilder.RenameColumn(
                name: "TableId",
                table: "UserTypes",
                newName: "UserOrGrpId");

            migrationBuilder.RenameColumn(
                name: "FideldName",
                table: "UserTypes",
                newName: "Type");
        }
    }
}
