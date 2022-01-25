using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PMAprojekt.DbModels
{
    public partial class ClosetContext : DbContext
    {
        public ClosetContext()
        {
        }

        public ClosetContext(DbContextOptions<ClosetContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<TypeOfProduct> TypeOfProduct { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(" Server=LAPTOP-1N35SPBB\\SQLEXPRESS01;Database=Closet;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(e => e.IdPost);

                entity.Property(e => e.IdPost)
                    .HasColumnName("ID_Post")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Link)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.IdProduct);

                entity.Property(e => e.IdProduct)
                    .HasColumnName("ID_Product")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdTypeOfProduct).HasColumnName("ID_TypeOfProduct");

                entity.Property(e => e.Link)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdTypeOfProductNavigation)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.IdTypeOfProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Type_Of_Product");
            });

            modelBuilder.Entity<TypeOfProduct>(entity =>
            {
                entity.HasKey(e => e.IdTypeOfProduct);

                entity.ToTable("Type_Of_Product");

                entity.Property(e => e.IdTypeOfProduct)
                    .HasColumnName("ID_TypeOfProduct")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
