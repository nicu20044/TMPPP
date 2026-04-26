using Microsoft.EntityFrameworkCore;
using TMPPP.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Adăugare DB Context
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// CONFIGURARE RUTĂ: Acum pleacă de la Home/Index (Dashboard-ul tău)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Migrații automate la pornire (opțional, dar recomandat)
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try {
        var context = services.GetRequiredService<AppDbContext>();
        context.Database.Migrate();
    } catch (Exception ex) {
        Console.WriteLine("Eroare la baza de date: " + ex.Message);
    }
}

app.Run();