using System.Globalization;
using Microsoft.AspNetCore.Server.IIS;
using Smkas.Core.Settings;
using Smkas.Mvc.Configurations;

var builder = WebApplication.CreateBuilder(args);
var cultureInfo = new CultureInfo("pt-BR");

IConfiguration configurations = builder.Configuration;

var appSettings = configurations.Get<AppSettings>();
builder.Services.AddDependencies(appSettings);


cultureInfo.NumberFormat.NumberDecimalSeparator = ".";
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

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
