using EventsManagement.Domain.Users;
using EventsManagement.Persistence.Context;
using EventsManagement.Web.Core.Constants;
using EventsManagement.Web.Infrastructure.Extensions;
using EventsManagement.Web.Infrastructure.Mappings;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("EventsManagementWebContextConnection");

builder.Services.AddDbContext<EventsManagementContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<DbContext, EventsManagementContext>();

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole<int>>()
    .AddEntityFrameworkStores<EventsManagementContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddServices();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(Constants.Policies.RequireAdmin, policy => policy.RequireRole(Constants.Roles.Admin));
    options.AddPolicy(Constants.Policies.RequireModerator, policy => policy.RequireRole(Constants.Roles.Moderator));
});


builder.Services.RegisterMaps();

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

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    "default",
    "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

//using (var scope = app.Services.CreateScope())
//{
//    var roleManager = scope.ServiceProvider.GetService<RoleManager<IdentityRole<int>>>();
//    await roleManager.CreateAsync(new IdentityRole<int>(Roles.Admin.ToString()));
//    await roleManager.CreateAsync(new IdentityRole<int>(Roles.User.ToString()));
//    await roleManager.CreateAsync(new IdentityRole<int>(Roles.Moderator.ToString()));
//}

app.Run();
