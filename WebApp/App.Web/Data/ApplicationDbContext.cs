using App.Web.Models.Domain;
using App.Web.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<WebAppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }  
        public virtual DbSet<ProductInShoppingCart> ProductInShoppingCarts { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<Product>()
              .Property(c => c.Id)
              .ValueGeneratedOnAdd();

            builder.Entity<ShoppingCart>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<ProductInShoppingCart>()
                .HasKey(z=> new {z.ProductId,z.ShoppingCartId});

            builder.Entity<ProductInShoppingCart>()
             .HasOne(z => z.Product)
             .WithMany(z => z.ProductInShoppingCarts)
             .HasForeignKey(z => z.ProductId);

            builder.Entity<ProductInShoppingCart>()
                .HasOne(z => z.ShoppingCart)
                .WithMany(z => z.ProductInShoppingCarts)
                .HasForeignKey(z => z.ShoppingCartId);


            builder.Entity<ShoppingCart>()
                .HasOne<WebAppUser>(z => z.Owner)
                .WithOne(z => z.UserCart)
                .HasForeignKey<ShoppingCart>(z=>z.OwnerId);
        }
    }
}
