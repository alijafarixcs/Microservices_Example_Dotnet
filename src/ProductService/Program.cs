using Microsoft.EntityFrameworkCore;
using ProductService.Persistance;
using ProductService.Models; // Replace with your actual namespace

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSqlConnection")));

// Add Swagger for API documentation (optional)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUi(options =>
    {
        options.DocumentPath = "openapi/v1.json";
        options.Path = "/swagger";
    });
}

app.UseHttpsRedirection();
app.MapControllers();
try
{
   DbInitializer.Initialize(app);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

app.Run();
