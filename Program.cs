using HRMSApp.Interfaces;
using HRMSApp.Services;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<IDashboardService, DashboardService>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "User_Schema";
})
.AddCookie("User_Schema", options =>
{
    options.LoginPath = "/login/signin";
    options.LogoutPath = "/login/signout";
    options.AccessDeniedPath = "/login/accessdenied";
});
builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews().AddSessionStateTempDataProvider();
builder.Services.AddRazorPages().AddSessionStateTempDataProvider();
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/login/error");
}
app.Use(async (context, next) =>
{
    var principal = new ClaimsPrincipal();
    var result1 = await context.AuthenticateAsync("User_Schema");
    if (result1?.Principal != null)
    {
        principal.AddIdentities(result1.Principal.Identities);
    }
    context.User = principal;
    await next();
});

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.Run();
