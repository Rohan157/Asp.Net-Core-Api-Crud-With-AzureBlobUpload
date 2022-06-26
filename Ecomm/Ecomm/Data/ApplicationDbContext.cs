using Ecomm.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecomm.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Category>().HasData(

        //        new Category
        //        {
        //            Id = 10,
        //            Title= "Apple",
        //            DisplayOrder = 1
        //        },
        //        new Category
        //        {
        //        Id = 11,
        //            Title = "Lenove",
        //            DisplayOrder = 2
        //        }
        //        );
        //}
    }
}
