using Microsoft.EntityFrameworkCore;
using ProductService.Models;

namespace ProductService.Persistance

{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Product> Products { get; set; }
    }
}
