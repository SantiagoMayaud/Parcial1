using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Parcial1SM.Data;
using Parcial1SM.data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ModelMakerContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("ModelMakerContext") ?? throw new InvalidOperationException("Connection string 'ModelMakerContext' not found.")));
builder.Services.AddDbContext<ModelKitContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("ModelKitContext") ?? throw new InvalidOperationException("Connection string 'ModelKitContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

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
