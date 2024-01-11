using Microsoft.EntityFrameworkCore;
using PostgreSQL.Data; // Ajustează la spațiul de nume corect al AppDbContext


var builder = WebApplication.CreateBuilder(args);

// Adăugarea și configurarea serviciilor
builder.Services.AddRazorPages();

// Configurarea DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("WebApiDatabase")));

var app = builder.Build();

// Configurarea pipeline-ului de request-uri HTTP
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    // Configurări suplimentare pentru producție
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
