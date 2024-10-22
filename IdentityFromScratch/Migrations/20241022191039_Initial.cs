using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IdentityFromScratch.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    EnrolmentId = table.Column<int>(type: "integer", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    NetPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    VAT = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sudents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    OTP = table.Column<string>(type: "text", nullable: false),
                    OTPExpiryTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sudents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
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
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CourseId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Header = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lessons_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrolments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MemberId = table.Column<int>(type: "integer", nullable: false),
                    CourseId = table.Column<int>(type: "integer", nullable: false),
                    EnrolmentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    GrossAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    NetAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    VATAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    PaymentProvider = table.Column<int>(type: "integer", nullable: false),
                    PaymentProviderPaymentId = table.Column<string>(type: "text", nullable: false),
                    PaymentProviderPayerId = table.Column<string>(type: "text", nullable: false),
                    PaymentStatus = table.Column<int>(type: "integer", nullable: false),
                    StudentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrolments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enrolments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrolments_Sudents_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Sudents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Objectives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LessonId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Objective = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objectives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Objectives_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Progress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MemberId = table.Column<int>(type: "integer", nullable: false),
                    LessonId = table.Column<int>(type: "integer", nullable: false),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsStarted = table.Column<bool>(type: "boolean", nullable: false),
                    IsNext = table.Column<bool>(type: "boolean", nullable: false),
                    StudentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Progress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Progress_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Progress_Sudents_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Sudents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "Name", "NetPrice", "TotalPrice", "VAT" },
                values: new object[] { 1, "Map reading and navigation course", "The Competent Navigator", 499.99m, 599.99m, 100m });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CourseId", "Description", "Header", "Name" },
                values: new object[,]
                {
                    { 1, 1, "In this lesson we explore the idea of a map as a bird's eye of the ground. Topographical maps represent physical, man-made and relief features and are used for a variety or purposes including land navigation i.e. moving safely and efficiently from one location to another, which is exactly what we will be using them for in this course.", "A map is simply a bird's eye view of the ground.", "Lesson 1 - What is a map?" },
                    { 2, 1, "In this lesson we explore the pros and cons of each and recommend which type of map you should use and when.", "here are paper, laminated, fabric and digital maps.", "Lesson 2 - What types of maps are there?" },
                    { 3, 1, "In this lesson we explore maps of different scales to see how much detailed information they contain.", "Scale is simply how much smaller the map is compared to the ground the map represents.", "Lesson 3 - What is scale?" },
                    { 4, 1, "In this lesson we explore what map scales are useful for which purposes and activities so that you can select the appropriate scales of maps to plan and execute your outdoor activities.", "Different map scales suit different purposes and activities.", "Lesson 4 - What map scales suit which purposes?" },
                    { 5, 1, "In this lesson we explore the margins of a variety of maps to discover the important information that you will need to know when using them for navigation.", "Most maps contain important information in the margins of the map.", "Lesson 5 - What important information is there in the margins of a map?" },
                    { 6, 1, "In this lesson we explore grid references and geographical coordinates and how to use them to pin point any location on the map and on the ground.", "To pin point your location on a map and on the ground you will need a unique grid reference or set of geographical coordinates.", "Lesson 6 - What are grid references and geographical coordinates?" },
                    { 7, 1, "In this lesson we explore how direction is measured as an angle from North together with the tools we use to measure it, protractors and compasses.", "Direction is measured as an angle from North.", "Lesson 7 - What is direction?" },
                    { 8, 1, "In this lesson we explore the Grid Magnetic Angle (GMA), the angular difference between the grid north on your map and the magnetic north measured by your compass. We examine how to make adjustments to bearings to avoid errors as you move them from map to compass and compass to map.", "Grid Magnetic Angle (GMA) is the angular difference between grid north and magnetic north.", "Lesson 8 - What is the Grid Magnetic Angle (GMA)?" },
                    { 9, 1, "In this lesson we explore how contour lines are used to represent elevation and relief. We explore how this provides information on the height and shape of features on the ground and why this is a navigation superpower.", "Contour lines are lines on the map that delineate points of equal height or elevation.", "Lesson 9 - What are contour lines?" },
                    { 10, 1, "In this lesson we explore how to line up or orientate your map with features on the ground and/or with your compass. In this way what you see in front of you is lined up with what you see on your map which is essential and vital for accurate navigation.", "An important first step in navigating any leg of your route is to orientate your map to the ground.", "Lesson 10 - How to orientate a map" },
                    { 11, 1, "In this lesson we explore how to use a ruler or the side of your compass to measure distance between two points in mm or cm on the map and convert it to distance on the ground in m or km by using the map's scale.", "Distance on a map is measured in mm or cm and then converted to m and km on the ground based on the scale of the map.", "Lesson 11 - How to measure distance on a map" },
                    { 12, 1, "In this lesson we explore how to take a grid bearing and convert it to a magnetic bearing which you will need to follow if you can't see your destination because physical features obscure it, or because of poor visibility at night or in bad weather.", "How to take a grid bearing from the map and convert it to a magnetic bearing on the ground.", "Lesson 12 - How to take a grid bearing from your map" },
                    { 13, 1, "In this lesson we explore how to walk along and follow a magnetic compass bearing to reach your destination point or target at night or in poor visibility. You may recall we converted this magnetic bearing from a grid bearing we took from the map in the last lesson.", "If you can't see your destination you will need to follow a compass bearing to get there.", "Lesson 13 - How to follow a compass bearing" },
                    { 14, 1, "In this lesson we explore how to use a compass to take a magnetic bearing to a feature you can see on the ground.", "Using your compass to take a magnetic bearing to a feature you can see on the ground.", "Lesson 14 - How to take a magnetic bearing" },
                    { 15, 1, "In this lesson we explore how to convert magnetic bearings into back bearings in preparation for a resection to fix your position.", "Back bearings are 180 degree reversed magnetic bearings important for resections to fix your position.", "Lesson 15 - How to convert magnetic bearings into back bearings" },
                    { 16, 1, "In this lesson we explore how to use two or three bearings to fix any position and two to three back bearings to fix your current position on the map and on the ground.", "How to use bearings to fix any position and back bearings to fix your current position both on the map and on the ground", "Lesson 16 - How to do an intersection to fix any position and a resection to fix your current position." },
                    { 17, 1, "In this lesson we explore the idea of map memory and using your thumb to mark where you are on the map, and thus the ground, at all times, mentally ticking off prominent collecting features as you go and identify a catching feature to make sure you don’t overshoot and miss your destination point for the current leg of your route.", "Thumbing the map means keeping your thumb continuously on your current location and mentally ticking off prominent man-made and physical collecting features as you go.", "Lesson 17 - How to use collecting features and map memory to thumb a map" },
                    { 18, 1, "In this lesson we explore how you can navigate by walking along linear man-made and physical features on the ground using them literally like a handrail to guide you on route to you next destination.", "Linear man-made features such as walls, roads and paths or physical features such as rivers and valleys, ridges and coastlines can be used as handrails to navigate by on route to you next destination point.", "Lesson 18 - How to use linear man-made and physical features as handrails to guide you on route" },
                    { 19, 1, "In this lesson we cover your speed over the ground, how you can estimate distance covered and the duration or time to your next target or destination point.", "How far, how fast and what time to your next destination point?", "Lesson 19 - How to calculate time, speed and distance on route" },
                    { 20, 1, "In this lesson we explore the importance of keeping your route sections, or legs, short to avoid compass errors.", "Over short distances, compass errors are small and easily spotted.", "Lesson 20 - How to avoid compass errors by keeping legs short" },
                    { 21, 1, "In this lesson we explore how to plan out the entire route in advance with a route card and the importance of sharing this with a responsible adult in case of emergencies.", "Plan ahead with a route card and share this with others for safety in case of emergencies.", "Lesson 21 - How to produce a route card to plan ahead" },
                    { 22, 1, "In this lesson we explore how to produce the same route card using digital maps.", "It is easier to plan a route with digital maps.", "Lesson 22 - Using digital maps to plan a route" },
                    { 23, 1, "In this lesson we pull everything together with the 10 Qs and the 5 Ds of practical navigation.", "Putting the theory to practice.", "Lesson 23 - How to do practical navigation" },
                    { 24, 1, "In this lesson we give a brief introduction to navigating with digital maps and a GPS.", "Using Digital Maps and GPS.", "Lesson 24 - How to navigate with digital maps and a GPS" },
                    { 25, 1, "In this lesson we explore how to use digital maps and a GPS as a secondary backup to confirm the accuracy of your manual map reading, compass work and navigation.", "Don't rely on GPS Alone.", "Lesson 25 - How to practice hybrid map reading and navigation" },
                    { 26, 1, "In this bonus lesson we explore what options are open to you to further develop your map reading, compass and navigation skills.", "What next?", "Bonus Lesson - Next Steps" }
                });

            migrationBuilder.InsertData(
                table: "Objectives",
                columns: new[] { "Id", "LessonId", "Name", "Objective" },
                values: new object[,]
                {
                    { 1, 1, "Objective 1.1", "By the end of this lesson you will understand and be able to describe precisely what maps are and what they are used for." },
                    { 2, 1, "Objective 1.2", "By the end of this lesson you will understand that maps use graphics and symbols to represent information about physical, man-made and relief features and their relative position and relationship to one another such that they can be used for safely and efficiently navigating over the land." },
                    { 3, 2, "Objective 2.1", "By the end of this lesson you will be able to articulate the advantages and disadvantages of each type of map." },
                    { 4, 2, "Objective 2.2", "By the end of this lesson you will be able to select maps suitable for your outdoor activities." },
                    { 5, 3, "Objective 3.1", "By the end of this lesson you will understand and be able to explain what map scales are." },
                    { 6, 3, "Objective 3.2", "By the end of this lesson you will be able to explain what 1:25,000, 1:50,000 and 1:250,000 map scales are." },
                    { 7, 4, "Objective 4.1", "By the end of this lesson you will know what scale of maps are good for planning and which for are good to take into the outdoors for specific pursuits and activities; walking, hiking, running, cycling and canoeing or even sailing." },
                    { 8, 4, "Objective 4.2", "By the end of this lesson you will be able to select suitable scales of maps appropriate for your outdoor activities." },
                    { 9, 5, "Objective 5.1", "By the end of this lesson you will understand and be able to use the information in the margins of the map to help you read and interpret the map for navigation purposes." },
                    { 10, 5, "Objective 5.2", "By the end of this lesson you will understand and be able find other sources of information to help with navigation in your local area." },
                    { 11, 6, "Objective 6.1", "By the end of this lesson you will understand and be able to explain what four, six and eight figure grid references are." },
                    { 12, 6, "Objective 6.2", "the end of this lesson you will understand and be able to explain what latitude and longitude coordinates are." },
                    { 13, 6, "Objective 6.3", "By the end of this lesson you will be able use a romer or ruler to measure four, six and eight figure grid references to give your current location or another location on 1:25,000 and 1:50,000 scale maps." },
                    { 14, 7, "Objective 7.1", "By the end of this lesson you will understand be able to explain how direction is measured as bearings from North and appreciate the difference between the three Norths, Grid North, True North and Magnetic North." },
                    { 15, 7, "Objective 7.2", "By the end of this lesson you will understand and describe various direction measuring tools such as baseplate compasses, prismatic and lensatic sighting compasses, rulers and protractors." },
                    { 16, 8, "Objective 8.1", "By the end of this lesson you will know how to work out the GMA for your local area." },
                    { 17, 8, "Objective 8.2", "By the end of this lesson you will convert magnetic bearings into grid bearings and grid bearings into magnetic bearings by adding or subtracting the GMA for your local area." },
                    { 18, 9, "Objective 9.1", "By the end of this lesson you will understand and be able to explain how contour lines join up points of equal height on the land." },
                    { 19, 9, "Objective 9.2", "By the end of this lesson you will be able to interpret the three A's of contour lines and relief; Aspect (the direction of a slope), Altitude (height of the land) and Angle (the steepness of a slope). All this information helps you to visualise the shape of the land before you get there, and how easy or difficulty it is to traverse and how long it may take to get to you next destination point." },
                    { 20, 9, "Objective 9.3", "By the end of this lesson you will be able to recognise and navigate by natural features in the landscape such as spot heights, cols, ridges, rivers and valleys, spurs and reentrants, all very useful features we can use to safely and efficiently navigate over the land." },
                    { 21, 10, "Objective 10.1", "By the end of this lesson you will be able to orient your map using man-made and physical features on the ground." },
                    { 22, 10, "Objective 10.2", "By the end of this lesson you will be able to orient your map using your compass." },
                    { 23, 11, "Objective 11.1", "By the end of this lesson you will be able to measure distance on a 1:25,000 map and convert it accurately to distance on the ground." },
                    { 24, 11, "Objective 11.2", "By the end of this lesson you will be able to measure distance on a 1:50,000 map and convert it accurately to distance on the ground." },
                    { 25, 12, "Objective 12.1", "By the end of this lesson you will be able to take a grid bearing from your current location to your next destination point" },
                    { 26, 12, "Objective 12.2", "By the end of this lesson you will be able to convert a grid bearing to a magnetic bearing using the current Grid Magnetic Angle (GMA) for your area." },
                    { 27, 13, "Objective 13.1", "By the end of this lesson you will be able to identify prominent features on your magnetic compass bearing that you can walk towards as reference points and thus stay on track to reach your destination." },
                    { 28, 13, "Objective 13.2", "By the end of this lesson you will be able to walk along your compass bearing by taking back bearings to last known positions behind you thus checking you are still on track to reach your destination." },
                    { 29, 13, "Objective 13.3", "By the end of this lesson you will be able to walk along your compass bearing by positioning a member of your group ahead of you on that bearing and then leap frogging them using back bearings and so on until you reach your destination." },
                    { 30, 14, "Objective 14.1", "By the end of this lesson you will be able to select an appropriate sighting compass to take a magnetic bearing.\n\n" },
                    { 31, 14, "Objective 14.2", "By the end of this lesson you will be able to line up your compass sight with a feature on the ground and read off the magnetic bearing from your current location to the feature you can see on the ground." },
                    { 32, 15, "Objective 15.1", "By the end of this lesson you will be able to convert a magnetic bearing into a back bearing (i.e. the bearing from that feature to your location) by adding 180 degrees where the bearing is less than 180 degree.\n\n" },
                    { 33, 15, "Objective 15.2", "By the end of this lesson you will be able to convert a magnetic bearing into a back bearing (i.e. the bearing from that feature to your location) by subtracting 180 degrees where the bearing is more than 180 degree." },
                    { 34, 16, "Objective 16.1", "By the end of this lesson you will be able to take a magnetic bearing from your current known position to a feature on the ground whose position you want to fix." },
                    { 35, 16, "Objective 16.2", "By the end of this lesson you will be able to move to another known position to take another magnetic bearing to the same feature on the ground whose position you wish to fix, and repeat for a third if necessary." },
                    { 36, 16, "Objective 16.3", "By the end of this lesson you will be able to convert these magnetic bearings into grid bearings using the current Grid Magnetic Angle for your area." },
                    { 37, 16, "Objective 16.4", "By the end of this lesson you will be able to plot each of these grid bearings on the map from their known positions revealing the position of the feature on the map where they intersect." },
                    { 38, 16, "Objective 16.5", "By the end of this lesson you will be able to take two to three magnetic bearings to prominent features you can see both on the ground and on your map." },
                    { 39, 16, "Objective 16.6", "By the end of this lesson you will be able to convert the two to three magnetic bearings into back bearings, i.e. the bearings from the two to three prominent features to your location." },
                    { 40, 16, "Objective 16.7", "By the end of this lesson you will be able to convert the two to three back bearings into grid bearings by adjusting for the current Grid Magnetic Angle (GMA) in your area." },
                    { 41, 16, "Objective 16.8", "By the end of this lesson you will be able to plot the two to three grid bearings from the two to three prominent features on the map to reveal your location where the lines intersect and thus fix your position." },
                    { 42, 17, "Objective 17.1", "By the end of this lesson you will be able to identify and memorise a series of prominent collecting features on your route from the map." },
                    { 43, 17, "Objective 17.2", "By the end of this lesson you will be able to recognise and tick off each collecting feature as you navigate your route and move your thumb to mark where you are on the map as you go." },
                    { 44, 17, "Objective 17.3", "By the end of this lesson, if you have missed your destination point, you will recognise your catching feature, realise you have missed your destination point, and retrace your steps to find it." },
                    { 45, 18, "Objective 18.1", "By the end of this lesson you will be able to identify linear man-made and physical features on the map together with collecting features and catch points on route to your destination." },
                    { 46, 18, "Objective 18.2", "By the end of this lesson you will be able to follow linear man-made and physical features on the ground together with collecting features and catch points on route to your destination." },
                    { 47, 19, "Objective 19.1", "By the end of this lesson you will know how many steps or paces you walk over a 100m distance and at what speed." },
                    { 48, 19, "Objective 19.2", "By the end of this lesson you will know the number of minutes to add per 10m of elevation gained or 30m of elevation lost." },
                    { 49, 19, "Objective 19.3", "By the end of this lesson you will be able to estimate how long it will take to walk to your next destination, taking into consideration the distance, your speed and the elevation gained or lost on route." },
                    { 50, 19, "Objective 19.4", "By the end of this lesson you will be able to estimate distance walked by pacing and keeping track of each 100m section of ground covered based on your personal and known measure of the number of steps you walk over a 100m distance." },
                    { 51, 20, "Objective 20.1", "By the end of this lesson you will be able to calculate the effect of compass errors over various distances." },
                    { 52, 20, "Objective 20.2", "By the end of this lesson you will be able to assess the risk of errors over short distances and whether to accept or mitigate such errors." },
                    { 53, 21, "Objective 21.1", "By the end of this lesson you will be able to plan out and draw up a route card with waypoints/destination points, bearings, distances, elevation gained and lost and timings for each leg." },
                    { 54, 21, "Objective 21.2", "By the end of this lesson you will understand the importance of sharing your route card with a responsible adult in case of emergencies." },
                    { 55, 21, "Objective 21.3", "By the end of this lesson you will understand the importance of sticking to your planned route so, in case emergencies, the alarm can be raised and emergency services have a fighting chance of finding you." },
                    { 56, 22, "Objective 22.1", "By the end of this lesson you will be able to set waypoints and plan a route with distances and bearings, elevation gained and lost together with timings.\n\n" },
                    { 57, 22, "Objective 22.2", "By the end of this lesson you will be able to export your route plan as a GPX file and import this file into other GPS devices." },
                    { 58, 22, "Objective 22.3", "By the end of this lesson you will be able print off route card to share with others in case of emergencies." },
                    { 59, 23, "Objective 23.1", "By the end of this lesson you will know the 10 Qs or questions you need to ask as you move from one location, your start point to another location, your destination point, for each leg of your route." },
                    { 60, 23, "Objective 23.2", "By the end of this lesson you will know the 5 Ds of navigation, Destination, Distance, Duration, Direction and Description and how to apply them to navigate safely and efficiently." },
                    { 61, 23, "Objective 23.3", "By the end of this lesson you will be able to pull together into a coherent whole all the skills learned so far and apply them effectively to navigate safely and efficiently in lowland landscapes in good visibility." },
                    { 62, 24, "Objective 24.1", "By the end of this lesson you will be able to select an appropriate digital map and GPS device." },
                    { 63, 24, "Objective 24.2", "By the end of this lesson you will be able to use a digital map and navigate by GPS." },
                    { 64, 25, "Objective 25.1", "By the end of this lesson you will be able to navigate first and foremost using a paper, laminated or fabric map and compass." },
                    { 65, 25, "Objective 25.2", "By the end of this lesson you will be able to check your manual map reading and navigation efforts using your GPS thus setting up a positive reinforcement loop to further develop your skills as a competent navigator." },
                    { 66, 26, "Objective", "By the end of this lesson you will know where to go and how to further develop your newly acquired manual map reading, compass and navigation skills to navigate in more challenging environments such as upland areas and in reduced visibility conditions." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enrolments_CourseId",
                table: "Enrolments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrolments_StudentId",
                table: "Enrolments",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_CourseId",
                table: "Lessons",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Objectives_LessonId",
                table: "Objectives",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Progress_LessonId",
                table: "Progress",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Progress_StudentId",
                table: "Progress",
                column: "StudentId");
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
                name: "Enrolments");

            migrationBuilder.DropTable(
                name: "Objectives");

            migrationBuilder.DropTable(
                name: "Progress");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Sudents");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
