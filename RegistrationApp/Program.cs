using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add EF Core DbContext
var defaultConn = builder.Configuration.GetConnectionString("DefaultConnection");
var sqliteConn = builder.Configuration.GetConnectionString("SqliteConnection");
if (!string.IsNullOrEmpty(defaultConn))
{
    builder.Services.AddDbContext<RegistrationApp.Models.RegistrationContext>(options =>
        options.UseSqlServer(defaultConn));
}
else if (!string.IsNullOrEmpty(sqliteConn))
{
    builder.Services.AddDbContext<RegistrationApp.Models.RegistrationContext>(options =>
        options.UseSqlite(sqliteConn));
}
else
{
    // Fallback to SQLite file in project directory if nothing is configured
    builder.Services.AddDbContext<RegistrationApp.Models.RegistrationContext>(options =>
        options.UseSqlite("Data Source=Registration.db"));
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
