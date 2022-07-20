
using System.Text.Unicode;
using Advert.Infrastructer;
using Advert.View;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<AppDbContext>(opt => { opt.SetSqlServerOptions(builder.Configuration); });
builder.Services.AddScoped<IAppDbContext, AppDbContext>();
builder.Services.AddInfrastructures(builder.Configuration);
IocConfiguration.RegisterAllDependencies(builder.Services, builder.Configuration);

builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;

}).AddCookie(options =>
{
    options.AccessDeniedPath = new PathString("/Login/login/");
    options.LoginPath = new PathString("/Login/login/");
    options.LogoutPath = new PathString("/Login/logout/");
    options.Cookie.Name = "webcookies";
    options.Cookie.IsEssential = true;
});


builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromDays(1);
    options.Cookie.IsEssential = true;
    options.Cookie.HttpOnly = true;
});


builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
});

builder.Services.AddWebEncoders(o =>
{
    o.TextEncoderSettings = new System.Text.Encodings.Web.TextEncoderSettings(UnicodeRanges.All);
});
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

}

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetService<AppDbContext>();
    if (context != null) {
        await context.Database.MigrateAsync();
        await DataSeeding.Seed(context);
    }
}


app.UseStaticFiles();

app.UseRouting();
app.UseCookiePolicy();



app.UseAuthentication();

app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=MainPage}/{action=index}/{id?}");
app.Run();
