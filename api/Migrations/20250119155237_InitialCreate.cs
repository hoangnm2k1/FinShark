using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Purchase = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LastDiv = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Industry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarketCap = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StockId = table.Column<int>(type: "int", nullable: true),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Portfolios",
                columns: table => new
                {
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StockId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolios", x => new { x.AppUserId, x.StockId });
                    table.ForeignKey(
                        name: "FK_Portfolios_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Portfolios_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5d228960-166a-4524-9755-37488471c0fd", null, "Admin", "ADMIN" },
                    { "80d99aa3-31b7-4b37-bede-37a3e3821ae6", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "CompanyName", "Industry", "LastDiv", "MarketCap", "Purchase", "Symbol" },
                values: new object[,]
                {
                    { 1, "McCullough, Reichert and Hauck", "Grocery", 4.94m, 47648231724L, 179.04m, "ZWOSN" },
                    { 2, "Sipes and Sons", "Automotive", 6.87m, 56941654642L, 142.74m, "VGBFD" },
                    { 3, "Spencer LLC", "Kids", 4.05m, 23782501699L, 254.38m, "OQTFQ" },
                    { 4, "Hyatt LLC", "Sports", 6.75m, 10085289771L, 376.01m, "AKY" },
                    { 5, "Hane, Hansen and Thompson", "Grocery", 7.21m, 51582447334L, 202.07m, "ZQHV" },
                    { 6, "Hickle and Sons", "Jewelery", 9.48m, 60687124289L, 256.33m, "HWH" },
                    { 7, "Ebert - Schulist", "Jewelery", 0.58m, 60268912359L, 25.33m, "YNX" },
                    { 8, "Green, Yundt and Goyette", "Jewelery", 4.19m, 49715225624L, 400.67m, "KSQK" },
                    { 9, "Hintz, Howe and Cummings", "Games", 3.35m, 26248589239L, 366.01m, "USG" },
                    { 10, "Bins LLC", "Automotive", 9.34m, 17825421757L, 63.25m, "KBED" },
                    { 11, "Cremin - Daugherty", "Garden", 9.20m, 99802114187L, 72.50m, "BQR" },
                    { 12, "Tillman - Feeney", "Tools", 9.26m, 65056930203L, 234.90m, "BKO" },
                    { 13, "Collins, Bogan and Welch", "Outdoors", 7.67m, 79110745488L, 81.76m, "FJGF" },
                    { 14, "Lemke, Heidenreich and Gulgowski", "Electronics", 8.11m, 61849397626L, 21.22m, "BCLT" },
                    { 15, "Grimes - Macejkovic", "Books", 3.28m, 9904248549L, 431.78m, "ULMT" },
                    { 16, "Kilback - Quitzon", "Movies", 0.61m, 17463370649L, 230.55m, "JDSW" },
                    { 17, "Cronin, Harber and Botsford", "Outdoors", 8.05m, 1985795096L, 59.05m, "WAI" },
                    { 18, "Schuster - Jaskolski", "Jewelery", 8.79m, 89196772410L, 356.10m, "BFTT" },
                    { 19, "Wiza - Swift", "Movies", 6.07m, 38150114232L, 157.11m, "WVIUD" },
                    { 20, "Feeney and Sons", "Kids", 0.30m, 53974896565L, 457.14m, "WGNVQ" },
                    { 21, "Grimes - Marvin", "Industrial", 6.19m, 30887453871L, 62.98m, "NZEMK" },
                    { 22, "Heaney, Haag and Volkman", "Beauty", 4.96m, 21447762508L, 340.45m, "WIT" },
                    { 23, "Marvin - Connelly", "Industrial", 8.71m, 44696097359L, 114.30m, "WYD" },
                    { 24, "Feeney LLC", "Books", 2.01m, 60181658681L, 419.06m, "QBVJ" },
                    { 25, "Ferry - Bailey", "Health", 1.95m, 53242802307L, 123.42m, "OLVEC" },
                    { 26, "Berge and Sons", "Movies", 0.18m, 12291305795L, 276.92m, "SMVLL" },
                    { 27, "Bayer, Gerhold and Upton", "Movies", 9.52m, 96557373029L, 265.30m, "VDZ" },
                    { 28, "Waelchi, Welch and Lueilwitz", "Grocery", 1.01m, 93932311589L, 133.44m, "UYPCY" },
                    { 29, "Stroman and Sons", "Movies", 1.67m, 6130844979L, 401.29m, "DBX" },
                    { 30, "Hamill, Schmidt and Bartoletti", "Jewelery", 8.83m, 14519939330L, 361.67m, "YTSV" },
                    { 31, "Mueller Group", "Shoes", 9.95m, 44238708886L, 32.08m, "GOVX" },
                    { 32, "DuBuque - Herzog", "Kids", 5.91m, 51846944180L, 362.80m, "CQAEJ" },
                    { 33, "Medhurst - Sawayn", "Home", 2.81m, 78947063900L, 480.09m, "IKJ" },
                    { 34, "Bashirian, Hartmann and Pfeffer", "Kids", 2.13m, 11655879818L, 228.00m, "OAKHS" },
                    { 35, "Treutel Group", "Jewelery", 3.96m, 13301172369L, 43.18m, "AIM" },
                    { 36, "Kuhn - Feeney", "Electronics", 1.49m, 78689320213L, 315.97m, "BHZG" },
                    { 37, "Rau - Koch", "Movies", 8.02m, 96679204180L, 221.27m, "WSBD" },
                    { 38, "Sporer LLC", "Shoes", 5.64m, 51979577807L, 17.44m, "FJFB" },
                    { 39, "Marks - Collier", "Electronics", 4.43m, 79802240708L, 426.30m, "HVH" },
                    { 40, "Douglas - Walker", "Sports", 6.10m, 34363633606L, 490.97m, "XDXRT" },
                    { 41, "Weber, Kiehn and Herzog", "Tools", 0.72m, 89590417124L, 104.25m, "KSED" },
                    { 42, "Wisozk Inc", "Books", 5.84m, 30874450122L, 447.65m, "VFTS" },
                    { 43, "Upton - Yundt", "Clothing", 6.74m, 19153128980L, 270.99m, "SNI" },
                    { 44, "Williamson - Schaden", "Kids", 2.14m, 56363832451L, 311.13m, "LUWZP" },
                    { 45, "Roob, Dooley and Weissnat", "Kids", 0.35m, 64606523709L, 136.55m, "AQR" },
                    { 46, "Hauck, Jones and Labadie", "Electronics", 0.41m, 45964087544L, 58.36m, "ZNGJ" },
                    { 47, "Brown - Willms", "Baby", 0.01m, 74354434638L, 466.51m, "DUX" },
                    { 48, "Flatley, Skiles and Reilly", "Home", 8.80m, 36528743888L, 98.66m, "JRRU" },
                    { 49, "Heidenreich - Welch", "Sports", 9.69m, 11551101926L, 197.65m, "KYOWP" },
                    { 50, "Gutkowski - Leuschke", "Movies", 8.14m, 21698133917L, 459.34m, "FTKJ" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AppUserId",
                table: "Comments",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_StockId",
                table: "Comments",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_StockId",
                table: "Portfolios",
                column: "StockId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Portfolios");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Stocks");
        }
    }
}
