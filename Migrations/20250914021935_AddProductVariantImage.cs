using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfinityBack.Migrations
{
    /// <inheritdoc />
    public partial class AddProductVariantImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductVariantImage_ProductVariants_ProductVariantId",
                table: "ProductVariantImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductVariantImage",
                table: "ProductVariantImage");

            migrationBuilder.RenameTable(
                name: "ProductVariantImage",
                newName: "ProductVariantImages");

            migrationBuilder.RenameIndex(
                name: "IX_ProductVariantImage_ProductVariantId",
                table: "ProductVariantImages",
                newName: "IX_ProductVariantImages_ProductVariantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductVariantImages",
                table: "ProductVariantImages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVariantImages_ProductVariants_ProductVariantId",
                table: "ProductVariantImages",
                column: "ProductVariantId",
                principalTable: "ProductVariants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductVariantImages_ProductVariants_ProductVariantId",
                table: "ProductVariantImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductVariantImages",
                table: "ProductVariantImages");

            migrationBuilder.RenameTable(
                name: "ProductVariantImages",
                newName: "ProductVariantImage");

            migrationBuilder.RenameIndex(
                name: "IX_ProductVariantImages_ProductVariantId",
                table: "ProductVariantImage",
                newName: "IX_ProductVariantImage_ProductVariantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductVariantImage",
                table: "ProductVariantImage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVariantImage_ProductVariants_ProductVariantId",
                table: "ProductVariantImage",
                column: "ProductVariantId",
                principalTable: "ProductVariants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
