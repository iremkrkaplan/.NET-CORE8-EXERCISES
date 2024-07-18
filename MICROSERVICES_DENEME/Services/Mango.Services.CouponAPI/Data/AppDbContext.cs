using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mango.Services.CouponAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.CouponAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Coupon> Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
                    modelBuilder.Entity<Coupon>().HasData(new Coupon{
                        CouponId=1,
                        CouponCode="ABC",
                        DiscountAmount=10,
                        MinAmount=5
                        
        });       
            base.OnModelCreating(modelBuilder);
                    modelBuilder.Entity<Coupon>().HasData(new Coupon{
                        CouponId=2,
                        CouponCode="DEF",
                        DiscountAmount=900,
                        MinAmount=100
                        

            });

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Coupon>().HasData(new Coupon{
                        CouponId=3,
                        CouponCode="XYZ",
                        DiscountAmount=200,
                        MinAmount=50
            });

        }

    }

}