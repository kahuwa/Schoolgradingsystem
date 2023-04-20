using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GradingSystems.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "gradingsystem");

            migrationBuilder.CreateTable(
                name: "criteria",
                schema: "gradingsystem",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    criteria = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_criteria", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                schema: "gradingsystem",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    roletype = table.Column<string>(type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                schema: "gradingsystem",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    username = table.Column<string>(type: "character varying", nullable: false),
                    password = table.Column<string>(type: "character varying", nullable: false),
                    roles_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                    table.ForeignKey(
                        name: "fk_roles",
                        column: x => x.roles_id,
                        principalSchema: "gradingsystem",
                        principalTable: "roles",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "user_submissions",
                schema: "gradingsystem",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    user_id = table.Column<int>(type: "integer", nullable: true),
                    github = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_submissions", x => x.id);
                    table.ForeignKey(
                        name: "fk_user",
                        column: x => x.user_id,
                        principalSchema: "gradingsystem",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "criteria_to_submissions",
                schema: "gradingsystem",
                columns: table => new
                {
                    submission_id = table.Column<int>(type: "integer", nullable: false),
                    criteria_id = table.Column<int>(type: "integer", nullable: false),
                    teacher_id = table.Column<int>(type: "integer", nullable: false),
                    grade = table.Column<int>(type: "integer", nullable: true),
                    comment_teacher = table.Column<string>(type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("criteria_to_submissions_pkey", x => new { x.submission_id, x.criteria_id, x.teacher_id });
                    table.ForeignKey(
                        name: "fk_criteria",
                        column: x => x.criteria_id,
                        principalSchema: "gradingsystem",
                        principalTable: "criteria",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_submission",
                        column: x => x.submission_id,
                        principalSchema: "gradingsystem",
                        principalTable: "user_submissions",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_teacher",
                        column: x => x.teacher_id,
                        principalSchema: "gradingsystem",
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_criteria_to_submissions_criteria_id",
                schema: "gradingsystem",
                table: "criteria_to_submissions",
                column: "criteria_id");

            migrationBuilder.CreateIndex(
                name: "IX_criteria_to_submissions_teacher_id",
                schema: "gradingsystem",
                table: "criteria_to_submissions",
                column: "teacher_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_submissions_user_id",
                schema: "gradingsystem",
                table: "user_submissions",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_roles_id",
                schema: "gradingsystem",
                table: "users",
                column: "roles_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "criteria_to_submissions",
                schema: "gradingsystem");

            migrationBuilder.DropTable(
                name: "criteria",
                schema: "gradingsystem");

            migrationBuilder.DropTable(
                name: "user_submissions",
                schema: "gradingsystem");

            migrationBuilder.DropTable(
                name: "users",
                schema: "gradingsystem");

            migrationBuilder.DropTable(
                name: "roles",
                schema: "gradingsystem");
        }
    }
}
