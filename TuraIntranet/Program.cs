using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.FileProviders;
using Serilog;
using System.Net;
using TuraIntranet.Authentication;
using TuraIntranet.Data;
using TuraIntranet.Services;
using TuraIntranet.Services.Backoffice;
using TuraIntranet.Services.Claims;
using TuraIntranet.Services.Customers;
using TuraIntranet.Services.EAN;
using TuraIntranet.Services.Files;
using TuraIntranet.Services.Info;
using TuraIntranet.Services.Logistics;
using TuraIntranet.Services.Network;
using TuraIntranet.Services.Orders;
using TuraIntranet.Services.PriceList;

namespace TuraIntranet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddScoped<ProtectedLocalStorage>();
            builder.Services.AddScoped<ProtectedSessionStorage>();
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            builder.Services.AddSingleton<UserAccountService>();
            builder.Services.AddScoped<PageNavigationService>();
            builder.Services.AddScoped<ShipmentService>();
            builder.Services.AddScoped<CustomersService>();
            builder.Services.AddScoped<InfoService>();
            builder.Services.AddScoped<NetworkService>();
            builder.Services.AddScoped<PdfCollectorService>();
            builder.Services.AddScoped<ClaimsService>();
            builder.Services.AddScoped<OrdersService>();
            builder.Services.AddScoped<FileService>();
            builder.Services.AddScoped<NotificationService>();
            builder.Services.AddScoped<KossService>();
            builder.Services.AddScoped<EmailService>();
            builder.Services.AddScoped<LabelService>();
            builder.Services.AddScoped<RmaInformationService>();
            builder.Services.AddScoped<EANService>();
            builder.Services.AddScoped<DeviceDetectionService>();
            builder.Services.AddScoped<ShipmentsDeviationChecklistService>();
            builder.Services.AddSingleton<VisitorsService>();
            builder.Services.AddScoped<PriceListService>();

            builder.Services.AddHsts(options =>
            {
                options.Preload = true;
                options.IncludeSubDomains = true;
                options.MaxAge = TimeSpan.FromDays(365);
            });

            Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.File(@"logs/log.txt", shared: true)
            .CreateLogger();

            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog();

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

            string networkPath = @"\\dbu-kba-01.tura.local\Intranetshare\Totalfilen";
            NetworkCredential credentials = new NetworkCredential(@"intranetuser", "rocco12!");

            ConnectToSharedFolder ConnectToSharedFolder = new ConnectToSharedFolder(networkPath, credentials);

            app.UseFileServer(new FileServerOptions()
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine("\\\\dbu-kba-01.tura.local\\Intranetshare\\Totalfilen")),
                RequestPath = new PathString("/totalfilen"),
                EnableDirectoryBrowsing = true
            });

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}