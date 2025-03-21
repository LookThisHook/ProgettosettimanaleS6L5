using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProgettosettimanaleS6L5.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using ProgettosettimanaleS6L5.Data;



var builder = WebApplication.CreateBuilder(args);

// Configurazione della connessione al database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Configurazione Identity con Entity Framework Core
builder.Services.AddIdentity<Utente, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    // Puoi aggiungere altre configurazioni qui
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();



// Aggiunta dei servizi MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configurazione del middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Abilita autenticazione e autorizzazione
app.UseAuthentication();
app.UseAuthorization();

// Definizione delle rotte
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages(); // Necessario per Identity

app.Run();
