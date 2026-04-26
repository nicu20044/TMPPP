using Microsoft.EntityFrameworkCore;
using TMPPP.Decorator;
using TMPPP.Flyweight;
using TMPPP.Infrastructure.Data;
using TMPPP.Proxy;
using TMPPP.Flyweight;
using TMPPP.Decorator;
using TMPPP.Bridge;
using TMPPP.Proxy;

var builder = WebApplication.CreateBuilder(args);

// 1. Încărcarea string-ului de conexiune din appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 2. Înregistrarea DbContext în containerul de servicii
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// 3. Înregistrarea Pattern-urilor pentru a fi folosite în UI
// Folosim Scoped pentru ca DbContext să fie gestionat corect pe durata unei cereri
builder.Services.AddScoped<IMedicalAccess, SecurityProxy>();
builder.Services.AddSingleton<ExerciseLibrary>(); // Singleton pentru că Flyweight e un cache global

var app = builder.Build();

// --- LOGICA DE DEMONSTRARE PENTRU WEB UI ---

// Endpoint pentru PROXY (Securitate Medicală)
app.MapGet("/api/medical/{id}", (int id, string role, AppDbContext db, IMedicalAccess proxy) =>
{
    var athlete = db.Athletes.Find(id);
    if (athlete == null) return Results.NotFound("Sportivul nu există.");
    
    // Proxy-ul va decide dacă rolul are acces
    var details = proxy.GetDetails(athlete, role);
    return Results.Ok(new { message = details });
});

// Endpoint pentru DECORATOR (Calcul Abonament)
app.MapPost("/api/subscription/calculate", (bool wantMassage, bool wantTrainer) =>
{
    IService sub = new BaseSubscription();
    
    if (wantMassage) sub = new MassageDecorator(sub);
    // Poți adăuga și alți decoratori aici
    
    return Results.Ok(new { 
        description = sub.GetInfo(), 
        total = sub.CalculateCost() 
    });
});

// Endpoint pentru FLYWEIGHT (Obținere Exercițiu din Cache/DB)
app.MapGet("/api/exercises/{name}", (string name, ExerciseLibrary library) =>
{
    // Factory-ul verifică în cache, apoi în DB
    var exercise = library.GetExercise(name, "Necunoscut", "Nespecificat");
    return Results.Ok(exercise);
});

app.UseStaticFiles(); // Permite servirea fișierelor din WebUI (index.html)
app.Run();