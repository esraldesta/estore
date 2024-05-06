using Estore.Services.CouponAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace Estore.Services.CouponAPI.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 
            
        }

        public DbSet<Coupon> Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 1,
                CouponCode="sdjfls",
                DiscountAmount = 20,
                MinAmount=40
            }            
            );

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 2,
                CouponCode = "fnskd",
                DiscountAmount = 10,
                MinAmount = 50
            }
);
        }
    }
}
