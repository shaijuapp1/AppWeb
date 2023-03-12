using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class TableData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TableDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TableId = table.Column<int>(type: "integer", nullable: false),
                    Txt1 = table.Column<string>(type: "text", nullable: true),
                    Txt2 = table.Column<string>(type: "text", nullable: true),
                    Txt3 = table.Column<string>(type: "text", nullable: true),
                    Txt4 = table.Column<string>(type: "text", nullable: true),
                    Txt5 = table.Column<string>(type: "text", nullable: true),
                    Txt6 = table.Column<string>(type: "text", nullable: true),
                    Txt7 = table.Column<string>(type: "text", nullable: true),
                    Txt8 = table.Column<string>(type: "text", nullable: true),
                    Txt9 = table.Column<string>(type: "text", nullable: true),
                    Txt10 = table.Column<string>(type: "text", nullable: true),
                    Txt11 = table.Column<string>(type: "text", nullable: true),
                    Txt12 = table.Column<string>(type: "text", nullable: true),
                    Txt13 = table.Column<string>(type: "text", nullable: true),
                    Txt14 = table.Column<string>(type: "text", nullable: true),
                    Txt15 = table.Column<string>(type: "text", nullable: true),
                    Txt16 = table.Column<string>(type: "text", nullable: true),
                    Txt17 = table.Column<string>(type: "text", nullable: true),
                    Txt18 = table.Column<string>(type: "text", nullable: true),
                    Txt19 = table.Column<string>(type: "text", nullable: true),
                    Txt20 = table.Column<string>(type: "text", nullable: true),
                    Date1 = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Date2 = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Date3 = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Date4 = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Date5 = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Date6 = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Date7 = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Date8 = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Date9 = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Date10 = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Num1 = table.Column<float>(type: "real", nullable: false),
                    Num2 = table.Column<float>(type: "real", nullable: false),
                    Num3 = table.Column<float>(type: "real", nullable: false),
                    Num4 = table.Column<float>(type: "real", nullable: false),
                    Num5 = table.Column<float>(type: "real", nullable: false),
                    Num6 = table.Column<float>(type: "real", nullable: false),
                    Num7 = table.Column<float>(type: "real", nullable: false),
                    Num8 = table.Column<float>(type: "real", nullable: false),
                    Num9 = table.Column<float>(type: "real", nullable: false),
                    Num10 = table.Column<float>(type: "real", nullable: false),
                    User1 = table.Column<int>(type: "integer", nullable: false),
                    User2 = table.Column<int>(type: "integer", nullable: false),
                    User3 = table.Column<int>(type: "integer", nullable: false),
                    User4 = table.Column<int>(type: "integer", nullable: false),
                    User5 = table.Column<int>(type: "integer", nullable: false),
                    User6 = table.Column<int>(type: "integer", nullable: false),
                    User7 = table.Column<int>(type: "integer", nullable: false),
                    User8 = table.Column<int>(type: "integer", nullable: false),
                    User9 = table.Column<int>(type: "integer", nullable: false),
                    User10 = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableDatas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: true),
                    UserOrGrpId = table.Column<int>(type: "integer", nullable: false),
                    TypeId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TableDatas");

            migrationBuilder.DropTable(
                name: "UserTypes");
        }
    }
}
