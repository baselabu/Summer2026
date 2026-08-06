using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookstoreApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangedidToId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Books",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Books",
                newName: "id");
        }
    }
}
