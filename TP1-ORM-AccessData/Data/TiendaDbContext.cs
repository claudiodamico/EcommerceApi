
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
                Nombre = "Remera Rotor Camo Ss",
                Descripcion = "La remera Rotor Camo Ss te ofrece un estilo informal perfecto para un día activo.",
                Marca = "Billabong",
                Codigo = "20923",
                Precio = 38999,
                Imagen = "https://acdn.mitiendanube.com/stores/987/679/products/11157020-f-23-08b22ac57398b8db7317255612299220-1024-1024.jpg",
            },
            new Producto
            {
                ProductoId = 2,
                Nombre = "Remera New Wave HS",
                Descripcion = "Big Wave es una remera básica con estampa de marca de lado del frente. Novedad de esta temporada Winter22. Realizada con algodón sustentable",
                Marca = "Billabong",
                Codigo = "20924",
                Precio = 33999,
                Imagen = "https://d3ugyf2ht6aenh.cloudfront.net/stores/987/679/products/11137062-j-61-5fdbd4b4f6d758f7cf16675871404328-640-0.jpg",
            },
            new Producto
            {
                ProductoId = 3,
                Nombre = "Bermuda Journey Light",
                Descripcion = "La Journey Ligth es una bermuda diseñada para ofrecerte el máximo confort y un look relajado. ",
                Marca = "Billabong",
                Codigo = "92364",
                Precio = 49999,
                Imagen = "https://acdn.mitiendanube.com/stores/987/679/products/11157009-a-12-cd6a6ca40691a91b4117255446442464-1024-1024.jpg",
            },
            new Producto
            {
                ProductoId = 4,
                Nombre = "Reloj Rip Curl Detroit",
                Descripcion = "Reloj Rip Curl Detroit.CUADRANTE: 3 agujas. CARCASA: Acero inoxidable de calidad marina. Lente de cristal mineral Enchapado Iónico. Sumergible hasta 100m. Ancho:48mm. MALLA:Cuero",
                Marca = "Rip Curl",
                Codigo = "3084",
                Precio = 109999,
                Imagen = "https://www.cristobalcolon.com/fullaccess/item7252foto80160.jpg",
            },
            new Producto
            {
                ProductoId = 5,
                Nombre = "Billetera Rip Curl 2 en 1",
                Descripcion = "Billetera Rip Curl 2 en 1.  100% cuero. Protección RFID. Nota gemela. Moneda con cremallera. Varias ranuras para tarjetas. Cartera delgada extraíble. Ventana de identificación.",
                Marca = "Rip Curl",
                Codigo = "3097",
                Precio = 48999,
                Imagen = "https://www.cristobalcolon.com/fullaccess/item12729foto102760.jpg",
            },
            new Producto
            {
                ProductoId = 6,
                Nombre = "Bermuda Straight Black",
                Descripcion = "Descubre nuestra bermuda Straight Black denim de 5 bolsillos, diseñadas para ofrecerte la combinación perfecta de estilo y funcionalidad",
                Marca = "Billabong",
                Codigo = "3065",
                Precio = 64999,
                Imagen = "https://acdn.mitiendanube.com/stores/987/679/products/11147714-j-1-ae84da740eb2e4784d17274489145431-1024-1024.jpg",
            },
            new Producto
            {
                ProductoId = 7,
                Nombre = "Bolso All Day Shoulder Bag",
                Descripcion = "La All Day Shoulder Bag es un morral con reguladores y etiqueta de marca en el delantero, posee tres bolsillos.",
                Marca = "Billabong",
                Codigo = "101119",
                Precio = 59999,
                Imagen = "https://acdn.mitiendanube.com/stores/987/679/products/12148009-2024-08-27t115320-477-973b18be0c5d293c5217247704544550-1024-1024.png",
            },
            new Producto
            {
                ProductoId = 8,
                Nombre = "Bermuda Surftrek",
                Descripcion = "La Sumergible Suftrek Journey es una de esas prendas que no pueden faltar en tu ropero.",
                Marca = "Billabong",
                Codigo = "108115",
                Precio = 99999,
                Imagen = "https://acdn.mitiendanube.com/stores/987/679/products/abyws00166-a-4-7c6a09eccb3223337b16971430118872-1024-1024.jpg",
            },
            new Producto
            {
                ProductoId = 9,
                Nombre = "Musculosa Dagger",
                Descripcion = "La Dagger es una musculosa con calce relaxed, con cuello redondo y con una estampa en el pecho para combinarla con cualquier outfit.",
                Marca = "Billabong",
                Codigo = "112007",
                Precio = 31999,
                Imagen = "https://acdn.mitiendanube.com/stores/987/679/products/11157504-b-1-088c4f9427fd158c1817238185572589-1024-1024.jpg",
            },
            new Producto
            {
                ProductoId = 10,
                Nombre = "Camisa Sundays",
                Descripcion = "Fresca para usarla en cualquier situacion, la camisa manga corta Sundays Mini Wave es la indicada.",
                Marca = "Billabong",
                Codigo = "92753",
                Precio = 59999,
                Imagen = "https://acdn.mitiendanube.com/stores/987/679/products/19147202-p-23-5d10eae836d8f5e96417309842388819-1024-1024.jpg",
            });
        }
    }
}
