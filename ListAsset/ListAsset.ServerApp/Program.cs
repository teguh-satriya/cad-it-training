using ListAsset.BusinessAccess.Authentication;
using ListAsset.BusinessAccess.Services;
using ListAsset.DataAccess.Contracts;
using ListAsset.DataAccess.Data;
using ListAsset.DataAccess.Models;
using ListAsset.DataAccess.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Radzen;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("AssetDbConn");

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

//Identity 
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddDbContext<AssetIdentityDbContext>(options =>
{
    options.UseSqlServer(connectionString);
}, ServiceLifetime.Transient);

builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AssetIdentityDbContext>();

builder.Services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>,ApplicationPrincipalFactory>();

#region Connection String

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
builder.Services.AddControllers();
//builder.Services.AddControllersWithViews();

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
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "default",
      pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapControllers();
    endpoints.MapBlazorHub();
    endpoints.MapFallbackToPage("/_Host");
});

app.Run();
