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

        // DbSets for all your models
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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // --- إعدادات العلاقات لمنع الأخطاء ---

            // 1. علاقة الأقسام الفرعية (Self-referencing category)
            // يمنع حذف قسم رئيسي إذا كان يحتوي على أقسام فرعية
            modelBuilder.Entity<Category>()
                .HasOne(c => c.ParentCategory)
                .WithMany(c => c.SubCategories)
                .HasForeignKey(c => c.ParentCategoryId)
                .OnDelete(DeleteBehavior.Restrict); // يمنع الحذف المتتالي

            // 2. علاقة سلة التسوق مع المستخدم (Cart one-to-one with User)
            // بشكل افتراضي، حذف المستخدم سيؤدي لحذف سلة التسوق الخاصة به
            modelBuilder.Entity<Cart>()
                .HasOne(c => c.User)
                .WithOne(u => u.Cart)
                .HasForeignKey<Cart>(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade); // حذف السلة عند حذف المستخدم

            // 3. حل مشكلة الحذف المتتالي للطلبات (THE FIX)
            // نمنع الحذف التلقائي للطلبات عند حذف مستخدم أو عنوان

            // العلاقة بين الطلب والمستخدم
            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict); // <-- الحل: منع الحذف المتتالي

            // العلاقة بين الطلب وعنوان الشحن
            modelBuilder.Entity<Order>()
                .HasOne(o => o.ShippingAddress)
                .WithMany() // لا توجد قائمة طلبات في نموذج العنوان
                .HasForeignKey(o => o.ShippingAddressId)
                .OnDelete(DeleteBehavior.Restrict); // <-- الحل: منع الحذف المتتالي

            // ملاحظة: قد تحتاج أيضاً لضبط علاقات أخرى إذا ظهرت نفس المشكلة معها
            // على سبيل المثال، علاقة مراجعات المنتجات مع المستخدمين
            modelBuilder.Entity<ProductReview>()
                .HasOne(pr => pr.User)
                .WithMany(u => u.ProductReviews)
                .HasForeignKey(pr => pr.UserId)
                .OnDelete(DeleteBehavior.Restrict); // يمنع حذف المستخدم إذا كان لديه مراجعات
        }
    }

    
}
