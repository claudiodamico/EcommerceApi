
using Microsoft.EntityFrameworkCore;
using TP1_ORM_Domain.Entities;

namespace TP1_ORM_AccessData.Data
{
    public class TiendaDbContext : DbContext
    {
        public TiendaDbContext() { }

        public TiendaDbContext(DbContextOptions<TiendaDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=DbTiendita;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        public virtual DbSet<Carrito> Carritos { get; set; } = null!;
        public virtual DbSet<CarritoProducto> CarritoProductos { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Orden> Ordenes { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carrito>(entity =>
            {
                entity.ToTable("Carrito");

                entity.Property(e => e.CarritoId).ValueGeneratedNever();

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Carritos)
                    .HasForeignKey(d => d.ClienteId);
            });

            modelBuilder.Entity<CarritoProducto>(entity =>
            {
                entity.HasKey(e => new { e.CarritoId, e.ProductoId });

                entity.ToTable("CarritoProducto");

                entity.HasOne(d => d.Carrito)
                    .WithMany(p => p.CarritoProductos)
                    .HasForeignKey(d => d.CarritoId);

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.CarritoProductos)
                    .HasForeignKey(d => d.ProductoId);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");

                entity.Property(e => e.Apellido).HasMaxLength(25);

                entity.Property(e => e.Dni)
                    .HasMaxLength(10)
                    .HasColumnName("DNI");

                entity.Property(e => e.Nombre).HasMaxLength(25);

                entity.Property(e => e.Telefono).HasMaxLength(13);
            });

            modelBuilder.Entity<Orden>(entity =>
            {
                entity.ToTable("Orden");

                entity.HasIndex(e => e.CarritoId)
                    .IsUnique();

                entity.Property(e => e.OrdenId).ValueGeneratedNever();

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Total).HasColumnType("decimal(15, 2)");

                entity.HasOne(d => d.Carrito)
                    .WithOne(p => p.Orden)
                    .HasForeignKey<Orden>(d => d.CarritoId);
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("Producto");

                entity.Property(e => e.ProductoId);

                entity.Property(e => e.Codigo).HasMaxLength(25);

                entity.Property(e => e.Marca).HasMaxLength(25);

                entity.Property(e => e.Precio).HasColumnType("decimal(15, 2)");
            });

            //INSERTS

            modelBuilder.Entity<Producto>().HasData(
            new Producto
            {
                ProductoId = 1,
                Nombre = "Remera Space Wave",
                Descripcion = "Es una chomba de mangas cortas, de caida recta, totalmente ideada para que luzcas nuestra marca con tu mejor potencial.",
                Marca = "Billabong",
                Codigo = "20923",
                Precio = 15999,
                Imagen = "https://acdn.mitiendanube.com/stores/987/679/products/11147033-j-6c9e20ce32654e059616944705014965-1024-1024.jpg",
            },
            new Producto
            {
                ProductoId = 2,
                Nombre = "Remera New Wave HS",
                Descripcion = "Big Wave es una remera básica con estampa de marca de lado del frente. Novedad de esta temporada Winter22. Realizada con algodón sustentable",
                Marca = "Billabong",
                Codigo = "20924",
                Precio = 13999,
                Imagen = "https://d3ugyf2ht6aenh.cloudfront.net/stores/987/679/products/11137062-j-61-5fdbd4b4f6d758f7cf16675871404328-640-0.jpg",
            },
            new Producto
            {
                ProductoId = 3,
                Nombre = "Remera Rip Curl Crecent",
                Descripcion = " Remera Rip Curl. Relaxed Fit. Estampa frente y espalda. Estampa interna de marca y logo. Grifa logo. 100% Algodón. Jersey 16/1.",
                Marca = "Rip Curl",
                Codigo = "92364",
                Precio = 17999,
                Imagen = "https://www.cristobalcolon.com/fullaccess/item23284foto100240.jpg",
            },
            new Producto
            {
                ProductoId = 4,
                Nombre = "Reloj Rip Curl Detroit",
                Descripcion = "Reloj Rip Curl Detroit.CUADRANTE: 3 agujas. CARCASA: Acero inoxidable de calidad marina. Lente de cristal mineral Enchapado Iónico. Sumergible hasta 100m. Ancho:48mm. MALLA:Cuero",
                Marca = "Rip Curl",
                Codigo = "3084",
                Precio = 89999,
                Imagen = "https://www.cristobalcolon.com/fullaccess/item7252foto80160.jpg",
            },
            new Producto
            {
                ProductoId = 5,
                Nombre = "Billetera Rip Curl 2 en 1",
                Descripcion = "Billetera Rip Curl 2 en 1.  100% cuero. Protección RFID. Nota gemela. Moneda con cremallera. Varias ranuras para tarjetas. Cartera delgada extraíble. Ventana de identificación.",
                Marca = "Rip Curl",
                Codigo = "3097",
                Precio = 18999,
                Imagen = "https://www.cristobalcolon.com/fullaccess/item12729foto102760.jpg",
            },
            new Producto
            {
                ProductoId = 6,
                Nombre = "Jogging Rip Curl Logo",
                Descripcion = "Jogging Rip Curl Logo. Rustico invisible Jogging. Standard fit. Cintura y punos con elastico. Heattransfers logo. Cordon de ajuste al tono. Multietiquetas. 100% Algodon.",
                Marca = "Rip Curl",
                Codigo = "3065",
                Precio = 27999,
                Imagen = "https://www.cristobalcolon.com/fullaccess/item23364foto100473.jpg",
            },
            new Producto
            {
                ProductoId = 7,
                Nombre = "Remera Mc Small Chest Logo",
                Descripcion = "Remera manga corta, Tela: Jersey 30.1, Fit: Regular, TELA: 100% Algodón",
                Marca = "Quiksilver",
                Codigo = "102034",
                Precio = 12249,
                Imagen = "https://cdn.quiksilver.com.ar/media/catalog/product/cache/58de367b3bfe9e60ffd377a75f209f56/2/2/2232102218-10_1.jpg",
            },
            new Producto
            {
                ProductoId = 8,
                Nombre = "Sweater Perennials",
                Descripcion = "HILADO: 100% Algodón, Sweater, Fit: Regular, Cuello redondo, Logo bordado en el frente",
                Marca = "Quiksilver",
                Codigo = "108115",
                Precio = 34799,
                Imagen = "https://cdn.quiksilver.com.ar/media/catalog/product/cache/58de367b3bfe9e60ffd377a75f209f56/2/2/2241111001-10_1.jpg",
            },
            new Producto
            {
                ProductoId = 9,
                Nombre = "Zapatillas Fujia Olv",
                Descripcion = "Zapatilla Bota de caña baja realizada en cuero vacuno descarne y textil. Suela de eva inyectada para mayor confort",
                Marca = "Quiksilver",
                Codigo = "112007",
                Precio = 54299,
                Imagen = "https://cdn.quiksilver.com.ar/media/catalog/product/cache/58de367b3bfe9e60ffd377a75f209f56/2/2/2222112007-35_1.jpg",
            },
            new Producto
            {
                ProductoId = 10,
                Nombre = "Buzo Core Crew",
                Descripcion = "El Core Crew es un buzo básico de escote redondo con una etiqueta grifa de Billabong en el pecho que traemos y mejoramos todas las temporadas.",
                Marca = "Billabong",
                Codigo = "92753",
                Precio = 22999,
                Imagen = "https://acdn.mitiendanube.com/stores/987/679/products/mbcrefunj-11-f09dd67aac000be36716762289971567-1024-1024.jpg",
            });
        }
    }
}
