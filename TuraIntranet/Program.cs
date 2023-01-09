using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Components.Web;
using TuraIntranet.Authentication;
using TuraIntranet.Data;
using TuraIntranet.Services;
using TuraIntranet.Services.Backoffice;
using TuraIntranet.Services.Claims;
using TuraIntranet.Services.Customers;
using TuraIntranet.Services.Info;
using TuraIntranet.Services.Logistics;
using TuraIntranet.Services.Network;
using TuraIntranet.Services.Orders;

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
        }
    }
}