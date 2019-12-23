using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AIShellAn.Server.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "AnnotationResult",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ItemId = table.Column<Guid>(nullable: false),
                    AnnotationResultType = table.Column<int>(nullable: false),
                    CreateOn = table.Column<DateTime>(nullable: false),
                    SpendTime = table.Column<float>(nullable: false),
                    LoadingTime = table.Column<float>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Content = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnotationResult", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnnotationTemplate",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Type = table.Column<int>(nullable: false),
                    CreateOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnotationTemplate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 50, nullable: true),
                    RealName = table.Column<string>(maxLength: 20, nullable: true),
                    Password = table.Column<string>(maxLength: 50, nullable: true),
                    Sex = table.Column<int>(nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    CreatorId = table.Column<Guid>(nullable: true),
                    Phone = table.Column<string>(maxLength: 20, nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    LastLoginTime = table.Column<DateTime>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: true),
                    NativePlace = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Role = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_User_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnnotationTemplateItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: true),
                    TemplateType = table.Column<int>(nullable: false),
                    Content = table.Column<string>(maxLength: 200, nullable: true),
                    Necessary = table.Column<bool>(nullable: false),
                    Effect = table.Column<bool>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false),
                    Default = table.Column<string>(maxLength: 200, nullable: true),
                    AnnotationTemplateId = table.Column<Guid>(nullable: false),
                    CreateOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnotationTemplateItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnnotationTemplateItem_AnnotationTemplate_AnnotationTemplat~",
                        column: x => x.AnnotationTemplateId,
                        principalTable: "AnnotationTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnnotationTask",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ManagerId = table.Column<Guid>(nullable: false),
                    TemplateId = table.Column<Guid>(nullable: true),
                    TaskCode = table.Column<string>(maxLength: 100, nullable: true),
                    TaskName = table.Column<string>(maxLength: 100, nullable: true),
                    TaskDescribe = table.Column<string>(maxLength: 5000, nullable: true),
                    TaskType = table.Column<int>(nullable: false),
                    AnnotationType = table.Column<int>(nullable: false),
                    CreateOn = table.Column<DateTime>(nullable: false),
                    TaskStatus = table.Column<int>(nullable: false),
                    FinshedTime = table.Column<DateTime>(nullable: true),
                    Urgency = table.Column<int>(nullable: false),
                    TaskScope = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnotationTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnnotationTask_User_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnnotationTask_AnnotationTemplate_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "AnnotationTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    TeamName = table.Column<string>(maxLength: 20, nullable: true),
                    Describe = table.Column<string>(maxLength: 1000, nullable: true),
                    CreateOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Team_User_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DataPackage",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AnnotationTaskId = table.Column<Guid>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    AnnotationUserId = table.Column<Guid>(nullable: true),
                    TeamId = table.Column<Guid>(nullable: true),
                    TeamName = table.Column<string>(maxLength: 20, nullable: true),
                    InspectionUserId = table.Column<Guid>(nullable: true),
                    InspectionUser_Name = table.Column<string>(nullable: true),
                    PackageStatus = table.Column<int>(nullable: false),
                    RecevieTime = table.Column<DateTime>(nullable: true),
                    FinishTime = table.Column<DateTime>(nullable: true),
                    CreateOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataPackage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataPackage_AnnotationTask_AnnotationTaskId",
                        column: x => x.AnnotationTaskId,
                        principalTable: "AnnotationTask",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataPackage_User_AnnotationUserId",
                        column: x => x.AnnotationUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InspectionTask",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InspectionType = table.Column<int>(nullable: false),
                    TaskName = table.Column<string>(maxLength: 50, nullable: true),
                    CreateOn = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    FinishTime = table.Column<DateTime>(nullable: true),
                    AnnotationTaskId = table.Column<Guid>(nullable: true),
                    InspectionUserIds = table.Column<string>(nullable: true),
                    DrawPackageCount = table.Column<int>(nullable: true),
                    DrawPackagePercent = table.Column<int>(nullable: true),
                    InspectionTimeRangeStart = table.Column<DateTime>(nullable: true),
                    InspectionTimeRangeEnd = table.Column<DateTime>(nullable: true),
                    AnnotationUserIds = table.Column<string>(nullable: true),
                    Urgency = table.Column<int>(nullable: false),
                    ResultContent = table.Column<string>(maxLength: 1000, nullable: true),
                    Version = table.Column<int>(nullable: false),
                    InspectionTaskStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionTask_AnnotationTask_AnnotationTaskId",
                        column: x => x.AnnotationTaskId,
                        principalTable: "AnnotationTask",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InspectionTask_User_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamTask",
                columns: table => new
                {
                    TeamId = table.Column<Guid>(nullable: false),
                    AnnotationTaskId = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamTask", x => new { x.TeamId, x.AnnotationTaskId });
                    table.ForeignKey(
                        name: "FK_TeamTask_AnnotationTask_TeamId",
                        column: x => x.TeamId,
                        principalTable: "AnnotationTask",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamTask_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeamUser",
                columns: table => new
                {
                    TeamId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamUser", x => new { x.TeamId, x.UserId });
                    table.ForeignKey(
                        name: "FK_TeamUser_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamUser_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LongSpeechItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AnnotationTaskId = table.Column<Guid>(nullable: false),
                    PackageId = table.Column<Guid>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    AnnotationUserId = table.Column<Guid>(nullable: true),
                    CreateOn = table.Column<DateTime>(nullable: false),
                    AnnotationTime = table.Column<DateTime>(nullable: true),
                    ItemStatus = table.Column<int>(nullable: false),
                    Effective = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LongSpeechItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LongSpeechItem_User_AnnotationUserId",
                        column: x => x.AnnotationUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LongSpeechItem_DataPackage_PackageId",
                        column: x => x.PackageId,
                        principalTable: "DataPackage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShortSpeechItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AnnotationTaskId = table.Column<Guid>(nullable: false),
                    PackageId = table.Column<Guid>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    AnnotationUserId = table.Column<Guid>(nullable: true),
                    CreateOn = table.Column<DateTime>(nullable: false),
                    AnnotationTime = table.Column<DateTime>(nullable: true),
                    ItemStatus = table.Column<int>(nullable: false),
                    Effective = table.Column<bool>(nullable: true),
                    Urtexte = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShortSpeechItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShortSpeechItem_User_AnnotationUserId",
                        column: x => x.AnnotationUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShortSpeechItem_DataPackage_PackageId",
                        column: x => x.PackageId,
                        principalTable: "DataPackage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionPackageRecord",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PackageId = table.Column<Guid>(nullable: false),
                    AnnotationTaskId = table.Column<Guid>(nullable: false),
                    InspectionTaskId = table.Column<Guid>(nullable: false),
                    PackageNumber = table.Column<int>(nullable: false),
                    FinishTime = table.Column<DateTime>(nullable: true),
                    InspectionPackageStatus = table.Column<int>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    TeamId = table.Column<Guid>(nullable: true),
                    InspectionUserId = table.Column<Guid>(nullable: true),
                    InspectionUserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionPackageRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionPackageRecord_InspectionTask_InspectionTaskId",
                        column: x => x.InspectionTaskId,
                        principalTable: "InspectionTask",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectionPackageRecord_DataPackage_PackageId",
                        column: x => x.PackageId,
                        principalTable: "DataPackage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LongSpeechText",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Order = table.Column<int>(nullable: false),
                    LongSpeechItemId = table.Column<Guid>(nullable: false),
                    Text = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LongSpeechText", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LongSpeechText_LongSpeechItem_LongSpeechItemId",
                        column: x => x.LongSpeechItemId,
                        principalTable: "LongSpeechItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionItemRecord",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ItemId = table.Column<Guid>(nullable: false),
                    AnnotationTaskId = table.Column<Guid>(nullable: false),
                    InspectionTaskId = table.Column<Guid>(nullable: false),
                    InspectionPackageRecordId = table.Column<Guid>(nullable: true),
                    InspectionTime = table.Column<DateTime>(nullable: true),
                    InspectionStatus = table.Column<int>(nullable: false),
                    ErrorType = table.Column<int>(nullable: false),
                    Suggestion = table.Column<string>(maxLength: 1000, nullable: true),
                    InspectionUserId = table.Column<Guid>(nullable: true),
                    Version = table.Column<int>(nullable: false),
                    AnnotationResultId = table.Column<Guid>(nullable: false),
                    SpendTime = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionItemRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionItemRecord_AnnotationResult_AnnotationResultId",
                        column: x => x.AnnotationResultId,
                        principalTable: "AnnotationResult",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectionItemRecord_AnnotationTask_AnnotationTaskId",
                        column: x => x.AnnotationTaskId,
                        principalTable: "AnnotationTask",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectionItemRecord_InspectionPackageRecord_InspectionPack~",
                        column: x => x.InspectionPackageRecordId,
                        principalTable: "InspectionPackageRecord",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InspectionItemRecord_User_InspectionPackageRecordId",
                        column: x => x.InspectionPackageRecordId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnnotationTask_ManagerId",
                table: "AnnotationTask",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_AnnotationTask_TemplateId",
                table: "AnnotationTask",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_AnnotationTemplateItem_AnnotationTemplateId",
                table: "AnnotationTemplateItem",
                column: "AnnotationTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_DataPackage_AnnotationTaskId",
                table: "DataPackage",
                column: "AnnotationTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_DataPackage_AnnotationUserId",
                table: "DataPackage",
                column: "AnnotationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionItemRecord_AnnotationResultId",
                table: "InspectionItemRecord",
                column: "AnnotationResultId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionItemRecord_AnnotationTaskId",
                table: "InspectionItemRecord",
                column: "AnnotationTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionItemRecord_InspectionPackageRecordId",
                table: "InspectionItemRecord",
                column: "InspectionPackageRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionPackageRecord_InspectionTaskId",
                table: "InspectionPackageRecord",
                column: "InspectionTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionPackageRecord_PackageId",
                table: "InspectionPackageRecord",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionTask_AnnotationTaskId",
                table: "InspectionTask",
                column: "AnnotationTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionTask_CreatorId",
                table: "InspectionTask",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_LongSpeechItem_AnnotationUserId",
                table: "LongSpeechItem",
                column: "AnnotationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LongSpeechItem_PackageId",
                table: "LongSpeechItem",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_LongSpeechText_LongSpeechItemId",
                table: "LongSpeechText",
                column: "LongSpeechItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ShortSpeechItem_AnnotationUserId",
                table: "ShortSpeechItem",
                column: "AnnotationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShortSpeechItem_PackageId",
                table: "ShortSpeechItem",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_CreatorId",
                table: "Team",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamUser_UserId",
                table: "TeamUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_CreatorId",
                table: "User",
                column: "CreatorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnnotationTemplateItem");

            migrationBuilder.DropTable(
                name: "InspectionItemRecord");

            migrationBuilder.DropTable(
                name: "LongSpeechText");

            migrationBuilder.DropTable(
                name: "ShortSpeechItem");

            migrationBuilder.DropTable(
                name: "TeamTask");

            migrationBuilder.DropTable(
                name: "TeamUser");

            migrationBuilder.DropTable(
                name: "AnnotationResult");

            migrationBuilder.DropTable(
                name: "InspectionPackageRecord");

            migrationBuilder.DropTable(
                name: "LongSpeechItem");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "InspectionTask");

            migrationBuilder.DropTable(
                name: "DataPackage");

            migrationBuilder.DropTable(
                name: "AnnotationTask");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "AnnotationTemplate");
        }
    }
}
