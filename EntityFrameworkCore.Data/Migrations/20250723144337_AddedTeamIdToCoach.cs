using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedTeamIdToCoach : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Coaches",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "League",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 23, 14, 43, 36, 614, DateTimeKind.Utc).AddTicks(7662));

            migrationBuilder.UpdateData(
                table: "League",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 23, 14, 43, 36, 614, DateTimeKind.Utc).AddTicks(7666));

            migrationBuilder.UpdateData(
                table: "League",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 23, 14, 43, 36, 614, DateTimeKind.Utc).AddTicks(7667));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 23, 14, 43, 36, 614, DateTimeKind.Utc).AddTicks(9751));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 23, 14, 43, 36, 614, DateTimeKind.Utc).AddTicks(9755));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 23, 14, 43, 36, 614, DateTimeKind.Utc).AddTicks(9756));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Coaches");

            migrationBuilder.UpdateData(
                table: "League",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 23, 14, 0, 40, 824, DateTimeKind.Utc).AddTicks(7277));

            migrationBuilder.UpdateData(
                table: "League",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 23, 14, 0, 40, 824, DateTimeKind.Utc).AddTicks(7280));

            migrationBuilder.UpdateData(
                table: "League",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 23, 14, 0, 40, 824, DateTimeKind.Utc).AddTicks(7281));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 23, 14, 0, 40, 824, DateTimeKind.Utc).AddTicks(8632));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 23, 14, 0, 40, 824, DateTimeKind.Utc).AddTicks(8634));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 23, 14, 0, 40, 824, DateTimeKind.Utc).AddTicks(8635));
        }
    }
}
