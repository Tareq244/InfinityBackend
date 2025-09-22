using InfinityBack.dataBase.Model;
using Microsoft.EntityFrameworkCore;

// تأكد من أن هذا الـ namespace يطابق مسار مجلد النماذج (Models) لديك
// على سبيل المثال: using InfinityBack.Models;
// أو أيًا كان المسار الصحيح
// using YourProjectName.Models; 

namespace InfinityBack.dataBase
{
    public class InfinityDBContext : DbContext
    {
        public InfinityDBContext(DbContextOptions<InfinityDBContext> options) : base(options) { }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<PaymentDetail> PaymentDetails { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<TargetAudience> TargetAudiences { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<ProductVariantImage> ProductVariantImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .HasOne(c => c.ParentCategory)
                .WithMany(c => c.SubCategories)
                .HasForeignKey(c => c.ParentCategoryId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Cart>()
                .HasOne(c => c.User)
                .WithOne(u => u.Cart)
                .HasForeignKey<Cart>(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade); 

           
            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict); 

            
            modelBuilder.Entity<Order>()
                .HasOne(o => o.ShippingAddress)
                .WithMany() 
                .HasForeignKey(o => o.ShippingAddressId)
                .OnDelete(DeleteBehavior.Restrict); 

            
            modelBuilder.Entity<ProductReview>()
                .HasOne(pr => pr.User)
                .WithMany(u => u.ProductReviews)
                .HasForeignKey(pr => pr.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Attachment>()
        .HasOne(a => a.Product)
        .WithMany(p => p.Attachments) 
        .HasForeignKey(a => a.ProductId)
        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>()
        .HasOne(p => p.CreatedByUser) 
        .WithMany(u => u.CreatedProducts) 
        .HasForeignKey(p => p.CreatedByUserId)
        .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Product>()
                .HasOne(p => p.UpdatedByUser) 
                .WithMany(u => u.UpdatedProducts) 
                .HasForeignKey(p => p.UpdatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .Property(o => o.TotalAmount)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<OrderDetail>()
                .Property(od => od.PriceAtPurchase)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<PaymentDetail>()
                .Property(p => p.Amount)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<ProductVariant>()
                .Property(pv => pv.Price)
                .HasColumnType("decimal(18, 2)");
        }
    }


}
