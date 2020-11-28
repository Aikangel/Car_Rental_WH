using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Car_Rental_WH.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Complementary_services",
                columns: table => new
                {
                    Service_code = table.Column<int>(type: "INT", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Price = table.Column<double>(type: "FLOAT", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complementary_services", x => x.Service_code);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Client_code = table.Column<int>(type: "INT", nullable: false),
                    Full_name = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Paul = table.Column<string>(type: "CHAR(5)", nullable: false),
                    Date_of_birth = table.Column<DateTime>(type: "DATE", nullable: false),
                    Address = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    Telephone = table.Column<string>(type: "CHAR(11)", nullable: false),
                    Passport_data = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Client_code);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Position_code = table.Column<int>(type: "INT", nullable: false),
                    The_name_of_the_position = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Responsibilities = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    Requirements = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    Salary = table.Column<double>(type: "FLOAT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Position_code);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    Staff_code = table.Column<int>(type: "INT", nullable: false),
                    Full_name = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Age = table.Column<string>(type: "CHAR(5)", nullable: false),
                    Paul = table.Column<string>(type: "CHAR(5)", nullable: false),
                    Address = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Telephone = table.Column<string>(type: "CHAR(11)", nullable: false),
                    Passport_data = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Position_code = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.Staff_code);
                    table.ForeignKey(
                        name: "FK_Staff_Positions_Position_code",
                        column: x => x.Position_code,
                        principalTable: "Positions",
                        principalColumn: "Position_code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Vehicle_code = table.Column<int>(type: "INT", nullable: false),
                    Body_number = table.Column<int>(type: "INT", nullable: false),
                    Engine_number = table.Column<int>(type: "INT", nullable: false),
                    Registration_number = table.Column<int>(type: "INT", nullable: false),
                    Year_of_manufacture = table.Column<DateTime>(type: "DATE", nullable: false),
                    Run = table.Column<int>(type: "INT", nullable: false),
                    Car_price = table.Column<double>(type: "FLOAT", nullable: false),
                    Price_of_the_rental_day = table.Column<double>(type: "FLOAT", nullable: false),
                    Last_TO_date = table.Column<DateTime>(type: "DATE", nullable: false),
                    Special_mark = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Refund_mark = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    The_code_of_the_employee = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Vehicle_code);
                    table.ForeignKey(
                        name: "FK_Cars_Staff_The_code_of_the_employee",
                        column: x => x.The_code_of_the_employee,
                        principalTable: "Staff",
                        principalColumn: "Staff_code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Car_brand",
                columns: table => new
                {
                    Brand_code = table.Column<int>(type: "INT", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Technical_parameters = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    Vehicle_code = table.Column<int>(type: "INT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car_brand", x => x.Brand_code);
                    table.ForeignKey(
                        name: "FK_Car_brand_Cars_Vehicle_code",
                        column: x => x.Vehicle_code,
                        principalTable: "Cars",
                        principalColumn: "Vehicle_code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hire",
                columns: table => new
                {
                    Date_of_issue = table.Column<DateTime>(type: "DATE", nullable: false),
                    Rental_period = table.Column<DateTime>(type: "DATE", nullable: false),
                    Return_date = table.Column<DateTime>(type: "DATE", nullable: false),
                    Vehicle_code = table.Column<int>(type: "INT", nullable: false),
                    Client_code = table.Column<int>(type: "INT", nullable: false),
                    Service_code = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Hire_Cars_Vehicle_code",
                        column: x => x.Vehicle_code,
                        principalTable: "Cars",
                        principalColumn: "Vehicle_code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hire_Complementary_services_Service_code",
                        column: x => x.Service_code,
                        principalTable: "Complementary_services",
                        principalColumn: "Service_code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hire_Customers_Client_code",
                        column: x => x.Client_code,
                        principalTable: "Customers",
                        principalColumn: "Client_code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_brand_Vehicle_code",
                table: "Car_brand",
                column: "Vehicle_code");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_The_code_of_the_employee",
                table: "Cars",
                column: "The_code_of_the_employee");

            migrationBuilder.CreateIndex(
                name: "IX_Hire_Client_code",
                table: "Hire",
                column: "Client_code");

            migrationBuilder.CreateIndex(
                name: "IX_Hire_Service_code",
                table: "Hire",
                column: "Service_code");

            migrationBuilder.CreateIndex(
                name: "IX_Hire_Vehicle_code",
                table: "Hire",
                column: "Vehicle_code");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_Position_code",
                table: "Staff",
                column: "Position_code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Car_brand");

            migrationBuilder.DropTable(
                name: "Hire");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Complementary_services");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}
