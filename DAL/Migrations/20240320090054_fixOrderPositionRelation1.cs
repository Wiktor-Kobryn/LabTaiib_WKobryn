using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class fixOrderPositionRelation1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "ORDER_POSITIONS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_POSITIONS_ProductID",
                table: "ORDER_POSITIONS",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_ORDER_POSITIONS_PRODUCTS_ProductID",
                table: "ORDER_POSITIONS",
                column: "ProductID",
                principalTable: "PRODUCTS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ORDER_POSITIONS_PRODUCTS_ProductID",
                table: "ORDER_POSITIONS");

            migrationBuilder.DropIndex(
                name: "IX_ORDER_POSITIONS_ProductID",
                table: "ORDER_POSITIONS");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "ORDER_POSITIONS");
        }
    }
}
