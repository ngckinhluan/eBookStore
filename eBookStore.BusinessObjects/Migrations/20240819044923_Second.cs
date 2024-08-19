using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace eBookStore.BusinessObjects.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "author_id", "address", "city", "email", "first_name", "last_name", "phone", "state", "zip" },
                values: new object[,]
                {
                    { "1", "123 Main St", "Anytown", "john.smith@example.com", "John", "Smith", "123-456-7890", "CA", "12345" },
                    { "2", "456 Elm St", "Othertown", "jane.doe@example.com", "Jane", "Doe", "987-654-3210", "NY", "67890" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "pub_id", "city", "country", "publisher_name", "state" },
                values: new object[,]
                {
                    { "1", "Anytown", "USA", "Publisher 1", "CA" },
                    { "2", "Othertown", "USA", "Publisher 2", "NY" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "role_id", "role_desc", "role_name" },
                values: new object[,]
                {
                    { "1", "Administrator", "Admin" },
                    { "2", "Regular User", "User" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "book_id", "advance", "notes", "price", "published_date", "pub_id", "royalty", "ytd_sales", "title", "type" },
                values: new object[,]
                {
                    { "1", "5000", "First Edition", 19.99m, new DateOnly(2024, 1, 15), "1", 10, 50, "The Great Adventure", "Fiction" },
                    { "2", "3000", "Second Edition", 29.99m, new DateOnly(2024, 5, 22), "2", 12, 50, "Learning C#", "Education" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "user_id", "address", "email", "first_name", "hire_date", "last_name", "middle_name", "password", "publisher_id", "role_id", "source" },
                values: new object[,]
                {
                    { "1", "123 Main St", "john.public@example.com", "John", new DateOnly(2023, 1, 1), "Public", "Q", "12345", "1", "1", "Local" },
                    { "2", "456 Elm St", "jane.doe@example.com", "Jane", new DateOnly(2023, 2, 1), "Doe", "A", "67890", "2", "2", "Local" }
                });

            migrationBuilder.InsertData(
                table: "BookAuthors",
                columns: new[] { "author_id", "book_id", "author_order", "royalty_percentage" },
                values: new object[,]
                {
                    { "1", "1", 1, 0.5m },
                    { "2", "2", 2, 0.5m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "author_id", "book_id" },
                keyValues: new object[] { "1", "1" });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "author_id", "book_id" },
                keyValues: new object[] { "2", "2" });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "user_id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "user_id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "author_id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "author_id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "book_id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "book_id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "role_id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "role_id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "pub_id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "pub_id",
                keyValue: "2");
        }
    }
}
