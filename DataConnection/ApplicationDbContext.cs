using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using MultipleSearchApp.Models;

namespace MultipleSearchApp.DataConnection
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ProductModel> tblProduct { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductModel>()
                .Property(p => p.ProductId)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(1, 1); // Start from 1 and increment by 1

            modelBuilder.Entity<ProductModel>().HasKey(p => p.ProductId);
        }


    }
}
