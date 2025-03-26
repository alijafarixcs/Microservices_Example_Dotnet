using Microsoft.EntityFrameworkCore;
using ProductService.Models;
using ProductService.Persistance;

public static class DbInitializer
{
    public static void Initialize(WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<ApplicationDbContext>();
            DbInitializer.Seed(context);

        }
    }

    private static void Seed(ApplicationDbContext context)
    {
        context.Database.Migrate(); // Ensures that migrations are applied

        // Check if data already exists (seeding only if empty)
        if (context.Products.Any())
        {
            return; // Database already seeded
        }

        // Add initial data
        context.Products.AddRange(

            new Product { Name = "Product 1", Price = 10.99M },
            new Product { Name = "Product 2", Price = 20.99M },
            new Product { Name = "Product 3", Price = 30.99M }
            );

        context.SaveChanges(); // Save changes to the database
    }
}
