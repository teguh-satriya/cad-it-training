using ListAsset.ServerApp.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System;
using ListAsset.DataAccess.Data;
using ListAsset.BusinessAccess.Services;
using ListAsset.DataAccess.Contracts;
using ListAsset.DataAccess.Models;
using ListAsset.DataAccess.Repositories;

namespace ListAsset.ServerApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();
            services.AddSingleton<IRepository<Asset>, RepositoryAsset>();
            services.AddSingleton<IRepository<Country>, RepositoryCountry>();
            services.AddSingleton(x => new AssetService(x.GetRequiredService<IRepository<Asset>>()));
            services.AddSingleton(x => new CountryService(x.GetRequiredService<IRepository<Country>>()));

            #region Connection String
            services.AddDbContext<AssetDbContext>(item => item.UseSqlServer(Configuration.GetConnectionString("AssetDbConn")));
            #endregion

        }

        public void Configure(IApplicationBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        }
    }
}
