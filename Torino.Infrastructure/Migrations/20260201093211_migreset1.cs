using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Torino.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class migreset1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Tours_TourId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservatioans_AspNetUsers_UserId",
                table: "Reservatioans");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservatioans_Tours_TourId",
                table: "Reservatioans");

            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_AspNetUsers_UserId",
                table: "Surveys");

            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_Tours_TourId",
                table: "Surveys");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetUsers_UserId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Reservatioans_ReservatioanID",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Tours_TourId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_TourImages_Tours_TourId",
                table: "TourImages");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavourites_AspNetUsers_UserId",
                table: "UserFavourites");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavourites_Tours_TourId",
                table: "UserFavourites");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_UserId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "ReservatioanID",
                table: "Tickets",
                newName: "ReservatioanId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_ReservatioanID",
                table: "Tickets",
                newName: "IX_Tickets_ReservatioanId");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Tickets",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Tickets",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserId1",
                table: "Tickets",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Tours_TourId",
                table: "Comments",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservatioans_AspNetUsers_UserId",
                table: "Reservatioans",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservatioans_Tours_TourId",
                table: "Reservatioans",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Surveys_AspNetUsers_UserId",
                table: "Surveys",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Surveys_Tours_TourId",
                table: "Surveys",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AspNetUsers_UserId1",
                table: "Tickets",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Reservatioans_ReservatioanId",
                table: "Tickets",
                column: "ReservatioanId",
                principalTable: "Reservatioans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Tours_TourId",
                table: "Tickets",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TourImages_Tours_TourId",
                table: "TourImages",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavourites_AspNetUsers_UserId",
                table: "UserFavourites",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavourites_Tours_TourId",
                table: "UserFavourites",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Tours_TourId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservatioans_AspNetUsers_UserId",
                table: "Reservatioans");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservatioans_Tours_TourId",
                table: "Reservatioans");

            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_AspNetUsers_UserId",
                table: "Surveys");

            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_Tours_TourId",
                table: "Surveys");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetUsers_UserId1",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Reservatioans_ReservatioanId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Tours_TourId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_TourImages_Tours_TourId",
                table: "TourImages");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavourites_AspNetUsers_UserId",
                table: "UserFavourites");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavourites_Tours_TourId",
                table: "UserFavourites");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_UserId1",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "ReservatioanId",
                table: "Tickets",
                newName: "ReservatioanID");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_ReservatioanId",
                table: "Tickets",
                newName: "IX_Tickets_ReservatioanID");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Tickets",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserId",
                table: "Tickets",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Tours_TourId",
                table: "Comments",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservatioans_AspNetUsers_UserId",
                table: "Reservatioans",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservatioans_Tours_TourId",
                table: "Reservatioans",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Surveys_AspNetUsers_UserId",
                table: "Surveys",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Surveys_Tours_TourId",
                table: "Surveys",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AspNetUsers_UserId",
                table: "Tickets",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Reservatioans_ReservatioanID",
                table: "Tickets",
                column: "ReservatioanID",
                principalTable: "Reservatioans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Tours_TourId",
                table: "Tickets",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TourImages_Tours_TourId",
                table: "TourImages",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavourites_AspNetUsers_UserId",
                table: "UserFavourites",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavourites_Tours_TourId",
                table: "UserFavourites",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
