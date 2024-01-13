using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelSchedule.BackService.Data
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Travellers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    DataOfBirth = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    PrimaryAddress = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Travellers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Travels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Destination = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    Purpose = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    TravellerId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Travels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Travels_Travellers_TravellerId",
                        column: x => x.TravellerId,
                        principalTable: "Travellers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CompletedTravels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArrivalDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ArrivalTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CheckIn = table.Column<bool>(type: "INTEGER", nullable: true),
                    TravelId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletedTravels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompletedTravels_Travels_TravelId",
                        column: x => x.TravelId,
                        principalTable: "Travels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accomodations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TypeOfAccomodation = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    Address = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    RoomCondition = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    CompletedTravelId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accomodations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accomodations_CompletedTravels_CompletedTravelId",
                        column: x => x.CompletedTravelId,
                        principalTable: "CompletedTravels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accomodations_CompletedTravelId",
                table: "Accomodations",
                column: "CompletedTravelId");

            migrationBuilder.CreateIndex(
                name: "IX_CompletedTravels_TravelId",
                table: "CompletedTravels",
                column: "TravelId");

            migrationBuilder.CreateIndex(
                name: "IX_Travels_TravellerId",
                table: "Travels",
                column: "TravellerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accomodations");

            migrationBuilder.DropTable(
                name: "CompletedTravels");

            migrationBuilder.DropTable(
                name: "Travels");

            migrationBuilder.DropTable(
                name: "Travellers");
        }
    }
}
