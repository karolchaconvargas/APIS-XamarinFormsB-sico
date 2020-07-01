using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjectCursoXamarin.Entities.Models
{
    public partial class DemoContext : DbContext
    {
        public DemoContext()
        {
        }

        public DemoContext(DbContextOptions<DemoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Amburguesas> Amburguesas { get; set; }
        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<Restaurantes> Restaurantes { get; set; }
        public virtual DbSet<RestaurantesAmburguesas> RestaurantesAmburguesas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=cursokcvargas.database.windows.net;Database=CursoXamarin;User ID=kcvargas;Password=kK40954095.;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Amburguesas>(entity =>
            {
                entity.HasKey(e => e.IdAmburguesa)
                    .HasName("PK__Amburgue__F381039C49D0B092");

                entity.HasIndex(e => e.NombreAmburguesa)
                    .HasName("UQ__Amburgue__A72758BDEA84ACD0")
                    .IsUnique();

                entity.HasIndex(e => e.Precio)
                    .HasName("UQ__Amburgue__E1DD55C8687C3405")
                    .IsUnique();

                entity.Property(e => e.IdAmburguesa).HasColumnName("idAmburguesa");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Favorita).HasColumnName("favorita");

                entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");

                entity.Property(e => e.Imagen)
                    .IsRequired()
                    .HasColumnName("imagen")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.NombreAmburguesa)
                    .IsRequired()
                    .HasColumnName("nombreAmburguesa")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnName("precio");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Amburguesas)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK__Amburgues__idCat__534D60F1");
            });

            modelBuilder.Entity<Categorias>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__Categori__8A3D240CF215F6E6");

                entity.HasIndex(e => e.Categoria)
                    .HasName("UQ__Categori__1179412FE51A455A")
                    .IsUnique();

                entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");

                entity.Property(e => e.Categoria)
                    .IsRequired()
                    .HasColumnName("categoria")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado).HasColumnName("estado");
            });

            modelBuilder.Entity<Restaurantes>(entity =>
            {
                entity.HasKey(e => e.IdRestaurante)
                    .HasName("PK__Restaura__5E9CB8F28C303719");

                entity.HasIndex(e => e.CorreoElectronico)
                    .HasName("UQ__Restaura__ED1E3B6EABC1A85B")
                    .IsUnique();

                entity.HasIndex(e => e.NombreRestaurante)
                    .HasName("UQ__Restaura__0C8203D6C7B20BA4")
                    .IsUnique();

                entity.HasIndex(e => e.Telefono)
                    .HasName("UQ__Restaura__2A16D945E9076B31")
                    .IsUnique();

                entity.Property(e => e.IdRestaurante).HasColumnName("idRestaurante");

                entity.Property(e => e.CorreoElectronico)
                    .IsRequired()
                    .HasColumnName("correoElectronico")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.NombreRestaurante)
                    .IsRequired()
                    .HasColumnName("nombreRestaurante")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono).HasColumnName("telefono");

                entity.Property(e => e.Ubicacion)
                    .IsRequired()
                    .HasColumnName("ubicacion")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RestaurantesAmburguesas>(entity =>
            {
                entity.HasKey(e => new { e.IdRestaurante, e.IdAmburguesa })
                    .HasName("PK__Restaura__81A4A8CBFA0AEB44");

                entity.Property(e => e.IdRestaurante).HasColumnName("idRestaurante");

                entity.Property(e => e.IdAmburguesa).HasColumnName("idAmburguesa");

                entity.HasOne(d => d.IdAmburguesaNavigation)
                    .WithMany(p => p.RestaurantesAmburguesas)
                    .HasForeignKey(d => d.IdAmburguesa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Restauran__idAmb__571DF1D5");

                entity.HasOne(d => d.IdRestauranteNavigation)
                    .WithMany(p => p.RestaurantesAmburguesas)
                    .HasForeignKey(d => d.IdRestaurante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Restauran__idRes__5629CD9C");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
