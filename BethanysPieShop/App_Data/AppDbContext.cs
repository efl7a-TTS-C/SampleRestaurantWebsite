using BethanysPieShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShop.ViewModels;

namespace BethanysPieShop.App_Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Pie> Pies { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<SubmittedOrder> SubmittedOrders { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //this.Database.EnsureCreated();
        }
        public DbSet<BethanysPieShop.ViewModels.AdminIndexViewModel> AdminIndexViewModel { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    modelBuilder.Entity<Pie>().ToTable("Pies");
        //    Do I need this ???
        //    modelBuilder.Entity<OrderItem>().ToTable("OrderItems");
        //}
    }
}
