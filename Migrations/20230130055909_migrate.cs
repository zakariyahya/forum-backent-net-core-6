using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace forum.Migrations
{
    /// <inheritdoc />
    public partial class migrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "forums",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    content = table.Column<int>(type: "integer", nullable: false),
                    createdBy = table.Column<string>(type: "text", nullable: false),
                    createdTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    lastModifiedBy = table.Column<string>(type: "text", nullable: false),
                    lastModifiedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_forums", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    roleId = table.Column<int>(type: "integer", nullable: false),
                    roleName = table.Column<string>(type: "text", nullable: false),
                    createdBy = table.Column<string>(type: "text", nullable: false),
                    createdTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    lastModifiedBy = table.Column<string>(type: "text", nullable: false),
                    lastModifiedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    firstName = table.Column<string>(type: "text", nullable: false),
                    lastName = table.Column<string>(type: "text", nullable: false),
                    username = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    passwordHash = table.Column<byte[]>(type: "bytea", nullable: false),
                    passwordSalt = table.Column<byte[]>(type: "bytea", nullable: false),
                    role = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "userRoles",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userid = table.Column<int>(type: "integer", nullable: false),
                    roleid = table.Column<int>(type: "integer", nullable: false),
                    createdBy = table.Column<string>(type: "text", nullable: false),
                    createdTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    lastModifiedBy = table.Column<string>(type: "text", nullable: false),
                    lastModifiedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userRoles", x => x.id);
                    table.ForeignKey(
                        name: "FK_userRoles_Role_roleid",
                        column: x => x.roleid,
                        principalTable: "Role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userRoles_Users_userid",
                        column: x => x.userid,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_userRoles_roleid",
                table: "userRoles",
                column: "roleid");

            migrationBuilder.CreateIndex(
                name: "IX_userRoles_userid",
                table: "userRoles",
                column: "userid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "forums");

            migrationBuilder.DropTable(
                name: "userRoles");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
