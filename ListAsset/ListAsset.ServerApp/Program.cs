using ListAsset.BusinessAccess.Services;
using ListAsset.DataAccess.Contracts;
using ListAsset.DataAccess.Data;
using ListAsset.DataAccess.Models;
using ListAsset.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

#region Connection String
var connectionString = builder.Configuration.GetConnectionString("AssetDbConn");
builder.Services.AddDbContext<AssetDbContext>(item => item.UseSqlServer(connectionString));
#endregion

builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<IRepository<Asset>, RepositoryAsset>();
builder.Services.AddScoped<AssetService>();

builder.Services.AddScoped<IRepository<Country>, RepositoryCountry>();
builder.Services.AddScoped<CountryService>();

builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
