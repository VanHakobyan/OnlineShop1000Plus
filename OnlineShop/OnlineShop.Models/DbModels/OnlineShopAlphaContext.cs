using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace OnlineShop.Common
{
    public partial class OnlineShopAlphaContext : DbContext
    {
        public OnlineShopAlphaContext() { }
        public OnlineShopAlphaContext(DbContextOptions<OnlineShopAlphaContext> options) 
            : base(options) { }

        public virtual DbSet<Addresses> Addresses { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<ItemsOrders> ItemsOrders { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-1E9TT7S\\SQL2019;Database=OnlineShopAlpha;Trusted_Connection=True;");
                //optionsBuilder.UseSqlServer("Server=DESKTOP-EL9EH4N\\MSSQLSERVER02;Database=TestDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Addresses>(entity =>
            {
                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Zip)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Items>(entity =>
            {
                entity.Property(e => e.Image)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Items__ProductId__5535A963");
            });

            modelBuilder.Entity<ItemsOrders>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ItemId })
                    .HasName("PK__Items_Or__64B7B3F7B05940D5");

                entity.ToTable("Items_Orders");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemsOrders)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Items_Ord__ItemI__5CD6CB2B");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.ItemsOrders)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Items_Ord__Order__5BE2A6F2");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Orders__UserId__5812160E");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Products__Catego__38996AB5");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Users__A9D10534362A3BC2")
                    .IsUnique();

                entity.HasIndex(e => e.Username)
                    .HasName("UQ__Users__536C85E4A1CEDA3C")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RegistrationDate).HasColumnType("datetime");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK__Users__AddressId__5FB337D6");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
