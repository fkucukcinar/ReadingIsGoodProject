using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .Sql("INSERT INTO Customer (Name,Address,PhoneNumber,Email,BirthDate) Values ('Fehmi Kucukcinar','Akpinar Valley,832 St. No:5-9 Cankaya, Ankara ','+905438409110','fkucukcinar@yahoo.com',convert(datetime,'25/09/1980', 103))");

            migrationBuilder
                .Sql("INSERT INTO Customer (Name,Address,PhoneNumber,Email,BirthDate) Values ('Ali kucuk','Ahci Valley,8 St. No:2-3 Yenimahalle, Ankara ','+905435558877','alikucuk@yahoo.com',convert(datetime,'25/08/1985', 103))");

            migrationBuilder
                 .Sql("INSERT INTO Customer (Name,Address,PhoneNumber,Email,BirthDate) Values ('Ayse Kucukcinar','Akpinar Valley,832 St. No:5-9 Cankaya, Ankara ','+905558889966','aysekucuk@yahoo.com',convert(datetime,'25/04/1942', 103))");

            migrationBuilder.Sql("INSERT INTO Book (Title,Author,ISBN,Cost,Price,Stock) Values ('1984','George Orwell','438409110',15,20,500)");
            migrationBuilder.Sql("INSERT INTO Book (Title,Author,ISBN,Cost,Price,Stock) Values ('Animal Farm','George Orwell','858409110',10,13,300)");
            migrationBuilder.Sql("INSERT INTO Book (Title,Author,ISBN,Cost,Price,Stock) Values ('Miserable','Victor Hugo','444409110',25,35,200)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
               .Sql("DELETE FROM Customer");

        }
    }
}
