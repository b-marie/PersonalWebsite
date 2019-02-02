using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalWebsite.Repository.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "About",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(nullable: true),
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_About", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(nullable: true),
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: true),
                    Recommendation = table.Column<string>(nullable: true),
                    FinishedReadingAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommunityInvolvement",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(nullable: true),
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityInvolvement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employment",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(nullable: true),
                    Id = table.Column<Guid>(nullable: false),
                    CompanyName = table.Column<string>(nullable: true),
                    CompanyLogoUrl = table.Column<string>(nullable: true),
                    CompanyUrl = table.Column<string>(nullable: true),
                    JobTitle = table.Column<string>(nullable: true),
                    JobDescription = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GoalCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoalCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(nullable: true),
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(nullable: true),
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    ProjectUrl = table.Column<string>(nullable: true),
                    GitHubUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Goals",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(nullable: true),
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    CompletedAt = table.Column<DateTime>(nullable: true),
                    GoalCategoryForeignKey = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Goals_GoalCategories_GoalCategoryForeignKey",
                        column: x => x.GoalCategoryForeignKey,
                        principalTable: "GoalCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(nullable: true),
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    ImageLink = table.Column<string>(nullable: true),
                    PostCategoryForeignKey = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_PostCategories_PostCategoryForeignKey",
                        column: x => x.PostCategoryForeignKey,
                        principalTable: "PostCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommunityInvolvementSkills",
                columns: table => new
                {
                    CommunityInvolvementId = table.Column<Guid>(nullable: false),
                    SkillId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityInvolvementSkills", x => new { x.CommunityInvolvementId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_CommunityInvolvementSkills_Skills_CommunityInvolvementId",
                        column: x => x.CommunityInvolvementId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommunityInvolvementSkills_CommunityInvolvement_SkillId",
                        column: x => x.SkillId,
                        principalTable: "CommunityInvolvement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmploymentSkills",
                columns: table => new
                {
                    EmploymentId = table.Column<Guid>(nullable: false),
                    SkillId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentSkills", x => new { x.EmploymentId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_EmploymentSkills_Skills_EmploymentId",
                        column: x => x.EmploymentId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmploymentSkills_Employment_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Employment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectSkills",
                columns: table => new
                {
                    ProjectId = table.Column<Guid>(nullable: false),
                    SkillId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectSkills", x => new { x.ProjectId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_ProjectSkills_Skills_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectSkills_Projects_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostTag",
                columns: table => new
                {
                    PostId = table.Column<Guid>(nullable: false),
                    TagId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTag", x => new { x.PostId, x.TagId });
                    table.ForeignKey(
                        name: "FK_PostTag_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTag_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommunityInvolvementSkills_SkillId",
                table: "CommunityInvolvementSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_EmploymentSkills_SkillId",
                table: "EmploymentSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Goals_GoalCategoryForeignKey",
                table: "Goals",
                column: "GoalCategoryForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PostCategoryForeignKey",
                table: "Posts",
                column: "PostCategoryForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_PostTag_TagId",
                table: "PostTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSkills_SkillId",
                table: "ProjectSkills",
                column: "SkillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "About");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "CommunityInvolvementSkills");

            migrationBuilder.DropTable(
                name: "EmploymentSkills");

            migrationBuilder.DropTable(
                name: "Goals");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "PostTag");

            migrationBuilder.DropTable(
                name: "ProjectSkills");

            migrationBuilder.DropTable(
                name: "Quotes");

            migrationBuilder.DropTable(
                name: "CommunityInvolvement");

            migrationBuilder.DropTable(
                name: "Employment");

            migrationBuilder.DropTable(
                name: "GoalCategories");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "PostCategories");
        }
    }
}
