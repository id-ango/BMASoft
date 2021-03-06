using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BMASoft.Areas.Identity;
using BMASoft.Data;
using Syncfusion.Blazor;
using BMASoft.Services;

namespace BMASoft
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection2")));
            services.AddDbContext<BmaDbContext>(options =>
               options.UseSqlServer(
                   Configuration.GetConnectionString("DefaultConnection2")));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
            services.AddSingleton<WeatherForecastService>();
            services.AddSingleton<SeedDataService>();
            services.AddSyncfusionBlazor();
            services.AddTransient<IKasBankService, KasBankService>();
            services.AddTransient<IReceivableService, ReceivableService>();
            services.AddTransient<IPaymentArService, PaymentArService>();
            services.AddTransient<IPaymentArDpService, PaymentArDpService>();
            services.AddTransient<IPayableService, PayableService>();
            services.AddTransient<IPaymentApService, PaymentApService>();
            services.AddTransient<IPaymentApDpService, PaymentApDpService>();
            services.AddTransient<ILedgerService, LedgerService>();
            services.AddTransient<IInventoryService, InventoryService>();
            services.AddTransient<IPurchaseService, PurchaseService>();
            services.AddTransient<ISalesService, SalesService>();
            services.AddSingleton<ExportService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzQ5NzcwQDMxMzgyZTMzMmUzMFIvY2poVnV5Ym5OTGVPK0Y5emxDMk5jUlZsbUJDRjN4MmtpZTNrNldCS0k9");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
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
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
