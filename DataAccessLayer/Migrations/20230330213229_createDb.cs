using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class createDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "@AppUserTypes",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_@AppUserTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppOperationClaims",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppOperationClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUsers",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefreshToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 3, 31, 0, 32, 28, 559, DateTimeKind.Local).AddTicks(3163)),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedUserId = table.Column<int>(type: "int", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    GsmNumber = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    ProfileImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UserTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserAppOperationClaim",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserTypeId = table.Column<int>(type: "int", nullable: true),
                    AppOperationClaimId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "char(4)", maxLength: 4, nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: true),
                    UserTypeId = table.Column<int>(type: "int", nullable: false),
                    OperationClaimId = table.Column<int>(type: "int", nullable: false),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserAppOperationClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserAppOperationClaim_@AppUserTypes_AppUserTypeId",
                        column: x => x.AppUserTypeId,
                        principalSchema: "dbo",
                        principalTable: "@AppUserTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppUserAppOperationClaim_AppOperationClaims_AppOperationClaimId",
                        column: x => x.AppOperationClaimId,
                        principalSchema: "dbo",
                        principalTable: "AppOperationClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserAppOperationClaim_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalSchema: "dbo",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "@AppUserTypes",
                columns: new[] { "Id", "UserTypeName" },
                values: new object[] { 1, "System Admin" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "@AppUserTypes",
                columns: new[] { "Id", "UserTypeName" },
                values: new object[] { 2, "Admin" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AppUsers",
                columns: new[] { "Id", "Adress", "CreateDate", "CreatedUserId", "DeletedDate", "DeletedUserId", "Email", "FirstName", "GsmNumber", "IsDeleted", "LastName", "Password", "PasswordHash", "PasswordSalt", "ProfileImageUrl", "RefreshToken", "UpdateDate", "UpdateUserId", "UserName", "UserTypeId" },
                values: new object[] { -1, "İstanbul", new DateTime(2023, 3, 31, 0, 32, 28, 566, DateTimeKind.Local).AddTicks(5439), 1, null, null, "tt@gmail.com", "Tuncay", "", false, "Tanin", null, new byte[] { 200, 68, 184, 110, 43, 38, 26, 84, 212, 225, 70, 130, 174, 108, 26, 142, 7, 16, 79, 132, 95, 181, 190, 200, 236, 133, 148, 223, 69, 8, 215, 159, 66, 190, 131, 90, 215, 192, 125, 203, 95, 243, 186, 5, 24, 242, 60, 113, 33, 36, 69, 71, 204, 17, 211, 61, 69, 147, 223, 144, 168, 223, 145, 122 }, new byte[] { 147, 54, 3, 142, 245, 3, 95, 214, 239, 25, 92, 152, 23, 96, 129, 187, 142, 150, 60, 98, 155, 246, 216, 117, 141, 64, 28, 95, 155, 169, 100, 236, 74, 164, 199, 111, 83, 255, 182, 25, 83, 191, 32, 233, 163, 64, 127, 77, 144, 125, 160, 217, 175, 88, 43, 171, 115, 196, 120, 169, 34, 136, 248, 64, 143, 227, 205, 126, 43, 1, 254, 112, 153, 5, 65, 152, 33, 138, 28, 5, 53, 26, 207, 124, 63, 67, 58, 186, 233, 117, 115, 201, 231, 92, 241, 4, 175, 208, 130, 119, 117, 252, 246, 173, 34, 237, 220, 117, 168, 157, 108, 254, 145, 69, 242, 225, 50, 148, 54, 197, 252, 23, 175, 172, 217, 213, 33, 158 }, null, new Guid("9e81b4ed-9a9a-44d2-ab88-93b657b08376"), null, null, "tt", 0 });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserAppOperationClaim_AppOperationClaimId",
                schema: "dbo",
                table: "AppUserAppOperationClaim",
                column: "AppOperationClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserAppOperationClaim_AppUserId",
                schema: "dbo",
                table: "AppUserAppOperationClaim",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserAppOperationClaim_AppUserTypeId",
                schema: "dbo",
                table: "AppUserAppOperationClaim",
                column: "AppUserTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserAppOperationClaim",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "@AppUserTypes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AppOperationClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AppUsers",
                schema: "dbo");
        }
    }
}
