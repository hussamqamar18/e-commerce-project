using Microsoft.EntityFrameworkCore;
using e_commerce_project.Models;
namespace e_commerce_project.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
       public DbSet<Items> Items { get; set; }
         public DbSet<Supplier> Suppliers { get; set; }
        




    }
}
