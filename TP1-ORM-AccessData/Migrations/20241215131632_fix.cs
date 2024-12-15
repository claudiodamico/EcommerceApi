using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP1_ORM_AccessData.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 1,
                columns: new[] { "Descripcion", "Imagen", "Nombre", "Precio" },
                values: new object[] { "La remera Rotor Camo Ss te ofrece un estilo informal perfecto para un día activo.", "https://acdn.mitiendanube.com/stores/987/679/products/11157020-f-23-08b22ac57398b8db7317255612299220-1024-1024.jpg", "Remera Rotor Camo Ss", 38999m });

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 2,
                column: "Precio",
                value: 33999m);

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 3,
                columns: new[] { "Descripcion", "Imagen", "Marca", "Nombre", "Precio" },
                values: new object[] { "La Journey Ligth es una bermuda diseñada para ofrecerte el máximo confort y un look relajado. ", "https://acdn.mitiendanube.com/stores/987/679/products/11157009-a-12-cd6a6ca40691a91b4117255446442464-1024-1024.jpg", "Billabong", "Bermuda Journey Light", 49999m });

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 4,
                column: "Precio",
                value: 109999m);

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 5,
                column: "Precio",
                value: 48999m);

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 6,
                columns: new[] { "Descripcion", "Imagen", "Marca", "Nombre", "Precio" },
                values: new object[] { "Descubre nuestra bermuda Straight Black denim de 5 bolsillos, diseñadas para ofrecerte la combinación perfecta de estilo y funcionalidad", "https://acdn.mitiendanube.com/stores/987/679/products/11147714-j-1-ae84da740eb2e4784d17274489145431-1024-1024.jpg", "Billabong", "Bermuda Straight Black", 64999m });

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 7,
                columns: new[] { "Codigo", "Descripcion", "Imagen", "Marca", "Nombre", "Precio" },
                values: new object[] { "101119", "La All Day Shoulder Bag es un morral con reguladores y etiqueta de marca en el delantero, posee tres bolsillos.", "https://acdn.mitiendanube.com/stores/987/679/products/12148009-2024-08-27t115320-477-973b18be0c5d293c5217247704544550-1024-1024.png", "Billabong", "Bolso All Day Shoulder Bag", 59999m });

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 8,
                columns: new[] { "Descripcion", "Imagen", "Marca", "Nombre", "Precio" },
                values: new object[] { "La Sumergible Suftrek Journey es una de esas prendas que no pueden faltar en tu ropero.", "https://acdn.mitiendanube.com/stores/987/679/products/abyws00166-a-4-7c6a09eccb3223337b16971430118872-1024-1024.jpg", "Billabong", "Bermuda Surftrek", 99999m });

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 9,
                columns: new[] { "Descripcion", "Imagen", "Marca", "Nombre", "Precio" },
                values: new object[] { "La Dagger es una musculosa con calce relaxed, con cuello redondo y con una estampa en el pecho para combinarla con cualquier outfit.", "https://acdn.mitiendanube.com/stores/987/679/products/11157504-b-1-088c4f9427fd158c1817238185572589-1024-1024.jpg", "Billabong", "Musculosa Dagger", 31999m });

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 10,
                columns: new[] { "Descripcion", "Imagen", "Nombre", "Precio" },
                values: new object[] { "Fresca para usarla en cualquier situacion, la camisa manga corta Sundays Mini Wave es la indicada.", "https://acdn.mitiendanube.com/stores/987/679/products/19147202-p-23-5d10eae836d8f5e96417309842388819-1024-1024.jpg", "Camisa Sundays", 59999m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 1,
                columns: new[] { "Descripcion", "Imagen", "Nombre", "Precio" },
                values: new object[] { "Es una chomba de mangas cortas, de caida recta, totalmente ideada para que luzcas nuestra marca con tu mejor potencial.", "https://acdn.mitiendanube.com/stores/987/679/products/11147033-j-6c9e20ce32654e059616944705014965-1024-1024.jpg", "Remera Space Wave", 15999m });

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 2,
                column: "Precio",
                value: 13999m);

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 3,
                columns: new[] { "Descripcion", "Imagen", "Marca", "Nombre", "Precio" },
                values: new object[] { " Remera Rip Curl. Relaxed Fit. Estampa frente y espalda. Estampa interna de marca y logo. Grifa logo. 100% Algodón. Jersey 16/1.", "https://www.cristobalcolon.com/fullaccess/item23284foto100240.jpg", "Rip Curl", "Remera Rip Curl Crecent", 17999m });

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 4,
                column: "Precio",
                value: 89999m);

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 5,
                column: "Precio",
                value: 18999m);

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 6,
                columns: new[] { "Descripcion", "Imagen", "Marca", "Nombre", "Precio" },
                values: new object[] { "Jogging Rip Curl Logo. Rustico invisible Jogging. Standard fit. Cintura y punos con elastico. Heattransfers logo. Cordon de ajuste al tono. Multietiquetas. 100% Algodon.", "https://www.cristobalcolon.com/fullaccess/item23364foto100473.jpg", "Rip Curl", "Jogging Rip Curl Logo", 27999m });

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 7,
                columns: new[] { "Codigo", "Descripcion", "Imagen", "Marca", "Nombre", "Precio" },
                values: new object[] { "102034", "Remera manga corta, Tela: Jersey 30.1, Fit: Regular, TELA: 100% Algodón", "https://cdn.quiksilver.com.ar/media/catalog/product/cache/58de367b3bfe9e60ffd377a75f209f56/2/2/2232102218-10_1.jpg", "Quiksilver", "Remera Mc Small Chest Logo", 12249m });

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 8,
                columns: new[] { "Descripcion", "Imagen", "Marca", "Nombre", "Precio" },
                values: new object[] { "HILADO: 100% Algodón, Sweater, Fit: Regular, Cuello redondo, Logo bordado en el frente", "https://cdn.quiksilver.com.ar/media/catalog/product/cache/58de367b3bfe9e60ffd377a75f209f56/2/2/2241111001-10_1.jpg", "Quiksilver", "Sweater Perennials", 34799m });

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 9,
                columns: new[] { "Descripcion", "Imagen", "Marca", "Nombre", "Precio" },
                values: new object[] { "Zapatilla Bota de caña baja realizada en cuero vacuno descarne y textil. Suela de eva inyectada para mayor confort", "https://cdn.quiksilver.com.ar/media/catalog/product/cache/58de367b3bfe9e60ffd377a75f209f56/2/2/2222112007-35_1.jpg", "Quiksilver", "Zapatillas Fujia Olv", 54299m });

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 10,
                columns: new[] { "Descripcion", "Imagen", "Nombre", "Precio" },
                values: new object[] { "El Core Crew es un buzo básico de escote redondo con una etiqueta grifa de Billabong en el pecho que traemos y mejoramos todas las temporadas.", "https://acdn.mitiendanube.com/stores/987/679/products/mbcrefunj-11-f09dd67aac000be36716762289971567-1024-1024.jpg", "Buzo Core Crew", 22999m });
        }
    }
}
