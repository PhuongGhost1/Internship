using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BE.Migrations
{
    /// <inheritdoc />
    public partial class Database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    paymentMethod = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    paymendCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    date = table.Column<DateTime>(type: "datetime", nullable: true),
                    total = table.Column<float>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(255)", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    phone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    createAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    isVisible = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    username = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedUserName = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedEmail = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "Permisson",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    roleId = table.Column<int>(type: "int", nullable: true),
                    resourcesId = table.Column<int>(type: "int", nullable: true),
                    lastUpdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    create = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    delete = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    update = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    view = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "Permisson_ibfk_1",
                        column: x => x.roleId,
                        principalTable: "Role",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "Permisson_ibfk_2",
                        column: x => x.resourcesId,
                        principalTable: "Resources",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    userId = table.Column<string>(type: "varchar(255)", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    paymentId = table.Column<int>(type: "int", nullable: true),
                    dateCreated = table.Column<DateTime>(type: "datetime", nullable: true),
                    total = table.Column<float>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "Cart_ibfk_1",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "Cart_ibfk_2",
                        column: x => x.paymentId,
                        principalTable: "Payment",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    createAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    price = table.Column<float>(type: "float", nullable: true),
                    ownerId = table.Column<string>(type: "varchar(255)", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    status = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    isVisible = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    rating = table.Column<float>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "Course_ibfk_1",
                        column: x => x.ownerId,
                        principalTable: "User",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    userId = table.Column<string>(type: "varchar(255)", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    title = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "Feedback_ibfk_1",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "Follow",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    followerId = table.Column<string>(type: "varchar(255)", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    followedId = table.Column<string>(type: "varchar(255)", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "Follow_ibfk_1",
                        column: x => x.followerId,
                        principalTable: "User",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "Follow_ibfk_2",
                        column: x => x.followedId,
                        principalTable: "User",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    receivedId = table.Column<string>(type: "varchar(255)", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    senderId = table.Column<string>(type: "varchar(255)", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    title = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    dateUp = table.Column<DateTime>(type: "datetime", nullable: true),
                    isRead = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "Notification_ibfk_1",
                        column: x => x.senderId,
                        principalTable: "User",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "Notification_ibfk_2",
                        column: x => x.receivedId,
                        principalTable: "User",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "RoleUser",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    roleId = table.Column<int>(type: "int", nullable: true),
                    userId = table.Column<string>(type: "varchar(255)", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    updateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "RoleUser_ibfk_1",
                        column: x => x.roleId,
                        principalTable: "Role",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "RoleUser_ibfk_2",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "Affiliate",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    createAt = table.Column<int>(type: "int", nullable: true),
                    commissionPercent = table.Column<float>(type: "float", nullable: true),
                    createBy = table.Column<string>(type: "varchar(255)", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    courseId = table.Column<int>(type: "int", nullable: true),
                    totalCommission = table.Column<float>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "Affiliate_ibfk_1",
                        column: x => x.createBy,
                        principalTable: "User",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "Affiliate_ibfk_2",
                        column: x => x.courseId,
                        principalTable: "Course",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "CategoryCourse",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    categoryId = table.Column<int>(type: "int", nullable: true),
                    courseId = table.Column<int>(type: "int", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "CategoryCourse_ibfk_1",
                        column: x => x.courseId,
                        principalTable: "Course",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "CategoryCourse_ibfk_2",
                        column: x => x.categoryId,
                        principalTable: "Category",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "Certification",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    courseId = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "Certification_ibfk_1",
                        column: x => x.courseId,
                        principalTable: "Course",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "Chapter",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    index = table.Column<int>(type: "int", nullable: true),
                    courseId = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    createAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    status = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "Chapter_ibfk_1",
                        column: x => x.courseId,
                        principalTable: "Course",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    courseId = table.Column<int>(type: "int", nullable: true),
                    userId = table.Column<string>(type: "varchar(255)", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    rating = table.Column<int>(type: "int", nullable: true),
                    comment = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    isVisible = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "Comment_ibfk_1",
                        column: x => x.courseId,
                        principalTable: "Course",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "Comment_ibfk_2",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "EnrollCourse",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    userId = table.Column<string>(type: "varchar(255)", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    courseId = table.Column<int>(type: "int", nullable: true),
                    date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "EnrollCourse_ibfk_1",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "EnrollCourse_ibfk_2",
                        column: x => x.courseId,
                        principalTable: "Course",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "SaveCourse",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    courseId = table.Column<int>(type: "int", nullable: true),
                    userId = table.Column<string>(type: "varchar(255)", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "SaveCourse_ibfk_1",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "SaveCourse_ibfk_2",
                        column: x => x.courseId,
                        principalTable: "Course",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "CartCourse",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    cartId = table.Column<int>(type: "int", nullable: true),
                    courseId = table.Column<int>(type: "int", nullable: true),
                    affiliateId = table.Column<int>(type: "int", nullable: true),
                    total = table.Column<float>(type: "float", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "CartCourse_ibfk_1",
                        column: x => x.cartId,
                        principalTable: "Cart",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "CartCourse_ibfk_2",
                        column: x => x.courseId,
                        principalTable: "Course",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "CartCourse_ibfk_3",
                        column: x => x.affiliateId,
                        principalTable: "Affiliate",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "UserCertification",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    userId = table.Column<string>(type: "varchar(255)", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    certificationId = table.Column<int>(type: "int", nullable: true),
                    datePass = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "UserCertification_ibfk_1",
                        column: x => x.certificationId,
                        principalTable: "Certification",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "UserCertification_ibfk_2",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "Lecture",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    index = table.Column<int>(type: "int", nullable: true),
                    chapterId = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    timeVideo = table.Column<TimeOnly>(type: "time", nullable: true),
                    videoUrl = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    creatAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "Lecture_ibfk_1",
                        column: x => x.chapterId,
                        principalTable: "Chapter",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "Quiz",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    index = table.Column<int>(type: "int", nullable: true),
                    chapterId = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    passPercent = table.Column<int>(type: "int", nullable: true),
                    createAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    numberOfQuestions = table.Column<int>(type: "int", nullable: true),
                    totalMark = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "Quiz_ibfk_1",
                        column: x => x.chapterId,
                        principalTable: "Chapter",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    courseId = table.Column<int>(type: "int", nullable: true),
                    commentId = table.Column<int>(type: "int", nullable: true),
                    reportedUserId = table.Column<string>(type: "varchar(255)", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    reporterId = table.Column<string>(type: "varchar(255)", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    title = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    message = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "Report_ibfk_1",
                        column: x => x.reportedUserId,
                        principalTable: "User",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "Report_ibfk_2",
                        column: x => x.commentId,
                        principalTable: "Comment",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "Report_ibfk_3",
                        column: x => x.courseId,
                        principalTable: "Course",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "Report_ibfk_4",
                        column: x => x.reporterId,
                        principalTable: "User",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    base64Code = table.Column<string>(type: "mediumtext", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    userId = table.Column<string>(type: "varchar(255)", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    courseId = table.Column<int>(type: "int", nullable: true),
                    lectureId = table.Column<int>(type: "int", nullable: true),
                    feedbackId = table.Column<int>(type: "int", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "Image_ibfk_1",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "Image_ibfk_2",
                        column: x => x.courseId,
                        principalTable: "Course",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "Image_ibfk_3",
                        column: x => x.lectureId,
                        principalTable: "Lecture",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "Image_ibfk_4",
                        column: x => x.feedbackId,
                        principalTable: "Feedback",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "Processing",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    userId = table.Column<string>(type: "varchar(255)", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    lectureId = table.Column<int>(type: "int", nullable: true),
                    quizId = table.Column<int>(type: "int", nullable: true),
                    createAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "Processing_ibfk_1",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "Processing_ibfk_2",
                        column: x => x.lectureId,
                        principalTable: "Lecture",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "Processing_ibfk_3",
                        column: x => x.quizId,
                        principalTable: "Quiz",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    quizId = table.Column<int>(type: "int", nullable: true),
                    text = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    mark = table.Column<int>(type: "int", nullable: true),
                    type = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    createAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "Question_ibfk_1",
                        column: x => x.quizId,
                        principalTable: "Quiz",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "Submission",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    quizzId = table.Column<int>(type: "int", nullable: true),
                    userId = table.Column<string>(type: "varchar(255)", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    grade = table.Column<double>(type: "double", nullable: true),
                    date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "Submission_ibfk_1",
                        column: x => x.quizzId,
                        principalTable: "Quiz",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "Submission_ibfk_2",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "Answear",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    questionId = table.Column<int>(type: "int", nullable: true),
                    text = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    status = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "Answear_ibfk_1",
                        column: x => x.questionId,
                        principalTable: "Question",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateIndex(
                name: "courseId",
                table: "Affiliate",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "unique_user_course",
                table: "Affiliate",
                columns: new[] { "createBy", "courseId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "questionId",
                table: "Answear",
                column: "questionId");

            migrationBuilder.CreateIndex(
                name: "paymentId",
                table: "Cart",
                column: "paymentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "userId",
                table: "Cart",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "affiliateId",
                table: "CartCourse",
                column: "affiliateId");

            migrationBuilder.CreateIndex(
                name: "cartId",
                table: "CartCourse",
                column: "cartId");

            migrationBuilder.CreateIndex(
                name: "courseId1",
                table: "CartCourse",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "categoryId",
                table: "CategoryCourse",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "courseId2",
                table: "CategoryCourse",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "courseId3",
                table: "Certification",
                column: "courseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "courseId4",
                table: "Chapter",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "courseId5",
                table: "Comment",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "userId1",
                table: "Comment",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "ownerId",
                table: "Course",
                column: "ownerId");

            migrationBuilder.CreateIndex(
                name: "courseId6",
                table: "EnrollCourse",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "userId2",
                table: "EnrollCourse",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "userId3",
                table: "Feedback",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "followedId",
                table: "Follow",
                column: "followedId");

            migrationBuilder.CreateIndex(
                name: "followerId",
                table: "Follow",
                column: "followerId");

            migrationBuilder.CreateIndex(
                name: "courseId7",
                table: "Image",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "feedbackId",
                table: "Image",
                column: "feedbackId");

            migrationBuilder.CreateIndex(
                name: "lectureId",
                table: "Image",
                column: "lectureId");

            migrationBuilder.CreateIndex(
                name: "userId4",
                table: "Image",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "chapterId",
                table: "Lecture",
                column: "chapterId");

            migrationBuilder.CreateIndex(
                name: "receivedId",
                table: "Notification",
                column: "receivedId");

            migrationBuilder.CreateIndex(
                name: "senderId",
                table: "Notification",
                column: "senderId");

            migrationBuilder.CreateIndex(
                name: "resourcesId",
                table: "Permisson",
                column: "resourcesId");

            migrationBuilder.CreateIndex(
                name: "roleId",
                table: "Permisson",
                column: "roleId");

            migrationBuilder.CreateIndex(
                name: "lectureId1",
                table: "Processing",
                column: "lectureId");

            migrationBuilder.CreateIndex(
                name: "quizId",
                table: "Processing",
                column: "quizId");

            migrationBuilder.CreateIndex(
                name: "userId5",
                table: "Processing",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "quizId1",
                table: "Question",
                column: "quizId");

            migrationBuilder.CreateIndex(
                name: "chapterId1",
                table: "Quiz",
                column: "chapterId");

            migrationBuilder.CreateIndex(
                name: "commentId",
                table: "Report",
                column: "commentId");

            migrationBuilder.CreateIndex(
                name: "courseId8",
                table: "Report",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "reportedUserId",
                table: "Report",
                column: "reportedUserId");

            migrationBuilder.CreateIndex(
                name: "reporterId",
                table: "Report",
                column: "reporterId");

            migrationBuilder.CreateIndex(
                name: "roleId1",
                table: "RoleUser",
                column: "roleId");

            migrationBuilder.CreateIndex(
                name: "userId6",
                table: "RoleUser",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "courseId9",
                table: "SaveCourse",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "userId7",
                table: "SaveCourse",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "quizzId",
                table: "Submission",
                column: "quizzId");

            migrationBuilder.CreateIndex(
                name: "userId8",
                table: "Submission",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "certificationId",
                table: "UserCertification",
                column: "certificationId");

            migrationBuilder.CreateIndex(
                name: "userId9",
                table: "UserCertification",
                column: "userId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answear");

            migrationBuilder.DropTable(
                name: "CartCourse");

            migrationBuilder.DropTable(
                name: "CategoryCourse");

            migrationBuilder.DropTable(
                name: "EnrollCourse");

            migrationBuilder.DropTable(
                name: "Follow");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "Permisson");

            migrationBuilder.DropTable(
                name: "Processing");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "RoleUser");

            migrationBuilder.DropTable(
                name: "SaveCourse");

            migrationBuilder.DropTable(
                name: "Submission");

            migrationBuilder.DropTable(
                name: "UserCertification");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Affiliate");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "Lecture");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Certification");

            migrationBuilder.DropTable(
                name: "Quiz");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Chapter");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
