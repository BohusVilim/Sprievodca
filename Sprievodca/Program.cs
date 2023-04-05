using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sprievodca.Data;
using Sprievodca.Models.MainModels;
using Sprievodca.Repositories.Roads;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SprievodcaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SprievodcaDbContext") ?? throw new InvalidOperationException("Connection string 'SprievodcaDbContext' not found.")));

builder.Services.AddSingleton<RoadRepository>();

// Add services to the container.
builder.Services.AddControllersWithViews();
var app = builder.Build();


using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<SprievodcaDbContext>();

//context.Database.EnsureDeleted();
context.Database.EnsureCreated();
DbInitializer.Init(services, context);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
