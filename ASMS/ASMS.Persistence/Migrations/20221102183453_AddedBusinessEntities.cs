using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASMS.Persistence.Migrations
{
    public partial class AddedBusinessEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Institutes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstitutionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEditedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressStreet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressNumber = table.Column<int>(type: "int", nullable: false),
                    AddressExtraInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentificationNumber = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institutes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Institutes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MembershipTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsByQuantity = table.Column<bool>(type: "bit", nullable: false),
                    MonthQuantity = table.Column<int>(type: "int", nullable: false),
                    ClassQuantity = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEditedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AllowedUsers = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(16,3)", precision: 16, scale: 3, nullable: false),
                    HasOnlineClasses = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEditedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstituteId = table.Column<long>(type: "bigint", nullable: false),
                    MemberMinQuantity = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEditedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_Institutes_InstituteId",
                        column: x => x.InstituteId,
                        principalTable: "Institutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Coaches",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstituteId = table.Column<long>(type: "bigint", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(16,2)", precision: 16, scale: 2, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEditedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressStreet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressNumber = table.Column<int>(type: "int", nullable: false),
                    AddressExtraInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentificationNumber = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coaches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coaches_Institutes_InstituteId",
                        column: x => x.InstituteId,
                        principalTable: "Institutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Coaches_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InstitutesMembers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstituteId = table.Column<long>(type: "bigint", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEditedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressStreet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressNumber = table.Column<int>(type: "int", nullable: false),
                    AddressExtraInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentificationNumber = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstitutesMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstitutesMembers_Institutes_InstituteId",
                        column: x => x.InstituteId,
                        principalTable: "Institutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstitutesMembers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstituteId = table.Column<long>(type: "bigint", nullable: false),
                    EmittedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(16,3)", precision: 16, scale: 3, nullable: false),
                    PaymentType = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEditedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Institutes_InstituteId",
                        column: x => x.InstituteId,
                        principalTable: "Institutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstituteId = table.Column<long>(type: "bigint", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Floor = table.Column<int>(type: "int", nullable: true),
                    MembersCapacity = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEditedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Institutes_InstituteId",
                        column: x => x.InstituteId,
                        principalTable: "Institutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaffMembers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstituteId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEditedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressStreet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressNumber = table.Column<int>(type: "int", nullable: false),
                    AddressExtraInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentificationNumber = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffMembers_Institutes_InstituteId",
                        column: x => x.InstituteId,
                        principalTable: "Institutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffMembers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Memberships",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstituteId = table.Column<long>(type: "bigint", nullable: false),
                    MembershipTypeId = table.Column<long>(type: "bigint", nullable: false),
                    IsPremium = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(16,2)", precision: 16, scale: 2, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEditedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memberships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Memberships_Institutes_InstituteId",
                        column: x => x.InstituteId,
                        principalTable: "Institutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Memberships_MembershipTypes_MembershipTypeId",
                        column: x => x.MembershipTypeId,
                        principalTable: "MembershipTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstitutePlans",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanId = table.Column<int>(type: "int", nullable: false),
                    InstituteId = table.Column<long>(type: "bigint", nullable: false),
                    IsCurrentPlan = table.Column<bool>(type: "bit", nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "date", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEditedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstitutePlans", x => x.Id);
                    table.UniqueConstraint("AK_InstitutePlans_InstituteId_PlanId", x => new { x.InstituteId, x.PlanId });
                    table.ForeignKey(
                        name: "FK_InstitutePlans_Institutes_InstituteId",
                        column: x => x.InstituteId,
                        principalTable: "Institutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstitutePlans_Plans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plans",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InstituteMemberActivities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityId = table.Column<long>(type: "bigint", nullable: false),
                    InstituteMemberId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEditedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstituteMemberActivities", x => x.Id);
                    table.UniqueConstraint("AK_InstituteMemberActivities_InstituteMemberId_ActivityId", x => new { x.InstituteMemberId, x.ActivityId });
                    table.ForeignKey(
                        name: "FK_InstituteMemberActivities_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstituteMemberActivities_InstitutesMembers_InstituteMemberId",
                        column: x => x.InstituteMemberId,
                        principalTable: "InstitutesMembers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InstituteMemberNotes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstituteMemberId = table.Column<long>(type: "bigint", nullable: false),
                    CoachId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEditedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstituteMemberNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstituteMemberNotes_Coaches_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Coaches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InstituteMemberNotes_InstitutesMembers_InstituteMemberId",
                        column: x => x.InstituteMemberId,
                        principalTable: "InstitutesMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstituteMemberNotes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InstituteClasses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstituteId = table.Column<long>(type: "bigint", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClassStatus = table.Column<int>(type: "int", nullable: false),
                    ActivityId = table.Column<long>(type: "bigint", nullable: false),
                    PrincipalCoachId = table.Column<long>(type: "bigint", nullable: false),
                    AuxCoachId = table.Column<long>(type: "bigint", nullable: true),
                    RoomId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEditedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstituteClasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstituteClasses_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InstituteClasses_Coaches_AuxCoachId",
                        column: x => x.AuxCoachId,
                        principalTable: "Coaches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InstituteClasses_Coaches_PrincipalCoachId",
                        column: x => x.PrincipalCoachId,
                        principalTable: "Coaches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InstituteClasses_Institutes_InstituteId",
                        column: x => x.InstituteId,
                        principalTable: "Institutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstituteClasses_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InstituteMemberMemberships",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstituteMemberId = table.Column<long>(type: "bigint", nullable: false),
                    MembershipId = table.Column<long>(type: "bigint", nullable: false),
                    IsActiveMembership = table.Column<bool>(type: "bit", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEditedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstituteMemberMemberships", x => x.Id);
                    table.UniqueConstraint("AK_InstituteMemberMemberships_InstituteMemberId_MembershipId", x => new { x.InstituteMemberId, x.MembershipId });
                    table.ForeignKey(
                        name: "FK_InstituteMemberMemberships_InstitutesMembers_InstituteMemberId",
                        column: x => x.InstituteMemberId,
                        principalTable: "InstitutesMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstituteMemberMemberships_Memberships_MembershipId",
                        column: x => x.MembershipId,
                        principalTable: "Memberships",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InstituteMemberMemberships_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NoteFiles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrlPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstituteMemberNoteId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEditedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NoteFiles_InstituteMemberNotes_InstituteMemberNoteId",
                        column: x => x.InstituteMemberNoteId,
                        principalTable: "InstituteMemberNotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstituteMemberInstituteClasses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstituteMemberId = table.Column<long>(type: "bigint", nullable: false),
                    InstituteClassId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEditedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstituteMemberInstituteClasses", x => x.Id);
                    table.UniqueConstraint("AK_InstituteMemberInstituteClasses_InstituteMemberId_InstituteClassId", x => new { x.InstituteMemberId, x.InstituteClassId });
                    table.ForeignKey(
                        name: "FK_InstituteMemberInstituteClasses_InstituteClasses_InstituteClassId",
                        column: x => x.InstituteClassId,
                        principalTable: "InstituteClasses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InstituteMemberInstituteClasses_InstitutesMembers_InstituteMemberId",
                        column: x => x.InstituteMemberId,
                        principalTable: "InstitutesMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 11, 2, 18, 34, 53, 269, DateTimeKind.Utc).AddTicks(1866), new DateTime(2022, 11, 2, 18, 34, 53, 269, DateTimeKind.Utc).AddTicks(1868) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 11, 2, 18, 34, 53, 269, DateTimeKind.Utc).AddTicks(1957), new DateTime(2022, 11, 2, 18, 34, 53, 269, DateTimeKind.Utc).AddTicks(1958) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 11, 2, 18, 34, 53, 269, DateTimeKind.Utc).AddTicks(1961), new DateTime(2022, 11, 2, 18, 34, 53, 269, DateTimeKind.Utc).AddTicks(1961) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 11, 2, 18, 34, 53, 269, DateTimeKind.Utc).AddTicks(1963), new DateTime(2022, 11, 2, 18, 34, 53, 269, DateTimeKind.Utc).AddTicks(1963) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 11, 2, 18, 34, 53, 269, DateTimeKind.Utc).AddTicks(1965), new DateTime(2022, 11, 2, 18, 34, 53, 269, DateTimeKind.Utc).AddTicks(1966) });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_InstituteId",
                table: "Activities",
                column: "InstituteId");

            migrationBuilder.CreateIndex(
                name: "IX_Coaches_InstituteId",
                table: "Coaches",
                column: "InstituteId");

            migrationBuilder.CreateIndex(
                name: "IX_Coaches_UserId",
                table: "Coaches",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InstituteClasses_ActivityId",
                table: "InstituteClasses",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_InstituteClasses_AuxCoachId",
                table: "InstituteClasses",
                column: "AuxCoachId");

            migrationBuilder.CreateIndex(
                name: "IX_InstituteClasses_InstituteId",
                table: "InstituteClasses",
                column: "InstituteId");

            migrationBuilder.CreateIndex(
                name: "IX_InstituteClasses_PrincipalCoachId",
                table: "InstituteClasses",
                column: "PrincipalCoachId");

            migrationBuilder.CreateIndex(
                name: "IX_InstituteClasses_RoomId",
                table: "InstituteClasses",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_InstituteMemberActivities_ActivityId",
                table: "InstituteMemberActivities",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_InstituteMemberInstituteClasses_InstituteClassId",
                table: "InstituteMemberInstituteClasses",
                column: "InstituteClassId");

            migrationBuilder.CreateIndex(
                name: "IX_InstituteMemberMemberships_MembershipId",
                table: "InstituteMemberMemberships",
                column: "MembershipId");

            migrationBuilder.CreateIndex(
                name: "IX_InstituteMemberMemberships_PaymentId",
                table: "InstituteMemberMemberships",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_InstituteMemberNotes_CoachId",
                table: "InstituteMemberNotes",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_InstituteMemberNotes_InstituteMemberId",
                table: "InstituteMemberNotes",
                column: "InstituteMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_InstituteMemberNotes_UserId",
                table: "InstituteMemberNotes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_InstitutePlans_PlanId",
                table: "InstitutePlans",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Institutes_UserId",
                table: "Institutes",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InstitutesMembers_InstituteId",
                table: "InstitutesMembers",
                column: "InstituteId");

            migrationBuilder.CreateIndex(
                name: "IX_InstitutesMembers_UserId",
                table: "InstitutesMembers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_InstituteId",
                table: "Memberships",
                column: "InstituteId");

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_MembershipTypeId",
                table: "Memberships",
                column: "MembershipTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_NoteFiles_InstituteMemberNoteId",
                table: "NoteFiles",
                column: "InstituteMemberNoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_InstituteId",
                table: "Payments",
                column: "InstituteId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_InstituteId",
                table: "Rooms",
                column: "InstituteId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffMembers_InstituteId",
                table: "StaffMembers",
                column: "InstituteId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffMembers_UserId",
                table: "StaffMembers",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstituteMemberActivities");

            migrationBuilder.DropTable(
                name: "InstituteMemberInstituteClasses");

            migrationBuilder.DropTable(
                name: "InstituteMemberMemberships");

            migrationBuilder.DropTable(
                name: "InstitutePlans");

            migrationBuilder.DropTable(
                name: "NoteFiles");

            migrationBuilder.DropTable(
                name: "StaffMembers");

            migrationBuilder.DropTable(
                name: "InstituteClasses");

            migrationBuilder.DropTable(
                name: "Memberships");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Plans");

            migrationBuilder.DropTable(
                name: "InstituteMemberNotes");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "MembershipTypes");

            migrationBuilder.DropTable(
                name: "Coaches");

            migrationBuilder.DropTable(
                name: "InstitutesMembers");

            migrationBuilder.DropTable(
                name: "Institutes");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 22, 15, 58, 15, 776, DateTimeKind.Utc).AddTicks(4902), new DateTime(2022, 9, 22, 15, 58, 15, 776, DateTimeKind.Utc).AddTicks(4902) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 22, 15, 58, 15, 776, DateTimeKind.Utc).AddTicks(4972), new DateTime(2022, 9, 22, 15, 58, 15, 776, DateTimeKind.Utc).AddTicks(4972) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 22, 15, 58, 15, 776, DateTimeKind.Utc).AddTicks(4975), new DateTime(2022, 9, 22, 15, 58, 15, 776, DateTimeKind.Utc).AddTicks(4975) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 22, 15, 58, 15, 776, DateTimeKind.Utc).AddTicks(4977), new DateTime(2022, 9, 22, 15, 58, 15, 776, DateTimeKind.Utc).AddTicks(4978) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 22, 15, 58, 15, 776, DateTimeKind.Utc).AddTicks(4979), new DateTime(2022, 9, 22, 15, 58, 15, 776, DateTimeKind.Utc).AddTicks(4980) });
        }
    }
}
