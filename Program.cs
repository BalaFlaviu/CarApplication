using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CarApplication.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();
// Add DbContext configuration for SQLite
builder.Services.AddDbContext<CarApplicationContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("CarApplicationContext")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.MapRazorPages();

app.Run();