using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP1_ORM_AccessData.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DNI = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.ProductoId);
                });

            migrationBuilder.CreateTable(
                name: "Carrito",
                columns: table => new
                {
                    CarritoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrito", x => x.CarritoId);
                    table.ForeignKey(
                        name: "FK_Carrito_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarritoProducto",
                columns: table => new
                {
                    CarritoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarritoProducto", x => new { x.CarritoId, x.ProductoId });
                    table.ForeignKey(
                        name: "FK_CarritoProducto_Carrito_CarritoId",
                        column: x => x.CarritoId,
                        principalTable: "Carrito",
                        principalColumn: "CarritoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarritoProducto_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orden",
                columns: table => new
                {
                    OrdenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarritoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(15,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orden", x => x.OrdenId);
                    table.ForeignKey(
                        name: "FK_Orden_Carrito_CarritoId",
                        column: x => x.CarritoId,
                        principalTable: "Carrito",
                        principalColumn: "CarritoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Producto",
                columns: new[] { "ProductoId", "Codigo", "Descripcion", "Imagen", "Marca", "Nombre", "Precio" },
                values: new object[,]
                {
                    { 1, "20923", "Es una chomba de mangas cortas, de caida recta, totalmente ideada para que luzcas nuestra marca con tu mejor potencial.", "https://acdn.mitiendanube.com/stores/987/679/products/11147033-j-6c9e20ce32654e059616944705014965-1024-1024.jpg", "Billabong", "Remera Space Wave", 15999m },
                    { 2, "20924", "Big Wave es una remera básica con estampa de marca de lado del frente. Novedad de esta temporada Winter22. Realizada con algodón sustentable", "https://d3ugyf2ht6aenh.cloudfront.net/stores/987/679/products/11137062-j-61-5fdbd4b4f6d758f7cf16675871404328-640-0.jpg", "Billabong", "Remera New Wave HS", 13999m },
                    { 3, "92364", " Remera Rip Curl. Relaxed Fit. Estampa frente y espalda. Estampa interna de marca y logo. Grifa logo. 100% Algodón. Jersey 16/1.", "https://www.cristobalcolon.com/fullaccess/item23284foto100240.jpg", "Rip Curl", "Remera Rip Curl Crecent", 17999m },
                    { 4, "3084", "Reloj Rip Curl Detroit.CUADRANTE: 3 agujas. CARCASA: Acero inoxidable de calidad marina. Lente de cristal mineral Enchapado Iónico. Sumergible hasta 100m. Ancho:48mm. MALLA:Cuero", "https://www.cristobalcolon.com/fullaccess/item7252foto80160.jpg", "Rip Curl", "Reloj Rip Curl Detroit", 89999m },
                    { 5, "3097", "Billetera Rip Curl 2 en 1.  100% cuero. Protección RFID. Nota gemela. Moneda con cremallera. Varias ranuras para tarjetas. Cartera delgada extraíble. Ventana de identificación.", "https://www.cristobalcolon.com/fullaccess/item12729foto102760.jpg", "Rip Curl", "Billetera Rip Curl 2 en 1", 18999m },
                    { 6, "3065", "Jogging Rip Curl Logo. Rustico invisible Jogging. Standard fit. Cintura y punos con elastico. Heattransfers logo. Cordon de ajuste al tono. Multietiquetas. 100% Algodon.", "https://www.cristobalcolon.com/fullaccess/item23364foto100473.jpg", "Rip Curl", "Jogging Rip Curl Logo", 27999m },
                    { 7, "102034", "Remera manga corta, Tela: Jersey 30.1, Fit: Regular, TELA: 100% Algodón", "https://cdn.quiksilver.com.ar/media/catalog/product/cache/58de367b3bfe9e60ffd377a75f209f56/2/2/2232102218-10_1.jpg", "Quiksilver", "Remera Mc Small Chest Logo", 12249m },
                    { 8, "108115", "HILADO: 100% Algodón, Sweater, Fit: Regular, Cuello redondo, Logo bordado en el frente", "https://cdn.quiksilver.com.ar/media/catalog/product/cache/58de367b3bfe9e60ffd377a75f209f56/2/2/2241111001-10_1.jpg", "Quiksilver", "Sweater Perennials", 34799m },
                    { 9, "112007", "Zapatilla Bota de caña baja realizada en cuero vacuno descarne y textil. Suela de eva inyectada para mayor confort", "https://cdn.quiksilver.com.ar/media/catalog/product/cache/58de367b3bfe9e60ffd377a75f209f56/2/2/2222112007-35_1.jpg", "Quiksilver", "Zapatillas Fujia Olv", 54299m },
                    { 10, "92753", "El Core Crew es un buzo básico de escote redondo con una etiqueta grifa de Billabong en el pecho que traemos y mejoramos todas las temporadas.", "https://acdn.mitiendanube.com/stores/987/679/products/mbcrefunj-11-f09dd67aac000be36716762289971567-1024-1024.jpg", "Billabong", "Buzo Core Crew", 22999m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carrito_ClienteId",
                table: "Carrito",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_CarritoProducto_ProductoId",
                table: "CarritoProducto",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_CarritoId",
                table: "Orden",
                column: "CarritoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarritoProducto");

            migrationBuilder.DropTable(
                name: "Orden");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Carrito");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
