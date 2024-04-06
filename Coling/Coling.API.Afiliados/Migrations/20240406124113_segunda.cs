using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coling.API.Afiliados.Migrations
{
    /// <inheritdoc />
    public partial class segunda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Detalle_Pedidos_IdPedido",
                table: "Detalle");

            migrationBuilder.DropForeignKey(
                name: "FK_Detalle_Producto_IdProducto",
                table: "Detalle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Producto",
                table: "Producto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Detalle",
                table: "Detalle");

            migrationBuilder.RenameTable(
                name: "Producto",
                newName: "Productos");

            migrationBuilder.RenameTable(
                name: "Detalle",
                newName: "Detalles");

            migrationBuilder.RenameIndex(
                name: "IX_Detalle_IdProducto",
                table: "Detalles",
                newName: "IX_Detalles_IdProducto");

            migrationBuilder.RenameIndex(
                name: "IX_Detalle_IdPedido",
                table: "Detalles",
                newName: "IX_Detalles_IdPedido");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Productos",
                table: "Productos",
                column: "IdProducto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Detalles",
                table: "Detalles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Detalles_Pedidos_IdPedido",
                table: "Detalles",
                column: "IdPedido",
                principalTable: "Pedidos",
                principalColumn: "IdPedido",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Detalles_Productos_IdProducto",
                table: "Detalles",
                column: "IdProducto",
                principalTable: "Productos",
                principalColumn: "IdProducto",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Detalles_Pedidos_IdPedido",
                table: "Detalles");

            migrationBuilder.DropForeignKey(
                name: "FK_Detalles_Productos_IdProducto",
                table: "Detalles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Productos",
                table: "Productos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Detalles",
                table: "Detalles");

            migrationBuilder.RenameTable(
                name: "Productos",
                newName: "Producto");

            migrationBuilder.RenameTable(
                name: "Detalles",
                newName: "Detalle");

            migrationBuilder.RenameIndex(
                name: "IX_Detalles_IdProducto",
                table: "Detalle",
                newName: "IX_Detalle_IdProducto");

            migrationBuilder.RenameIndex(
                name: "IX_Detalles_IdPedido",
                table: "Detalle",
                newName: "IX_Detalle_IdPedido");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Producto",
                table: "Producto",
                column: "IdProducto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Detalle",
                table: "Detalle",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Detalle_Pedidos_IdPedido",
                table: "Detalle",
                column: "IdPedido",
                principalTable: "Pedidos",
                principalColumn: "IdPedido",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Detalle_Producto_IdProducto",
                table: "Detalle",
                column: "IdProducto",
                principalTable: "Producto",
                principalColumn: "IdProducto",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
