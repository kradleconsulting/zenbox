using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using zenbox.core.Interface;
using zenbox.data;
using zenbox.service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Identity/Account/Login"; // or your custom login path
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
});

builder.Services.AddRazorPages();

builder.Services.AddTransient<ITaskListService, TaskListService>();
builder.Services.AddTransient<ITaskService, TaskService>();

var app = builder.Build();

ApplicationDbContext dbcontext = app.Services.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
dbcontext.Database.EnsureCreated();

var userManager = app.Services.CreateScope().ServiceProvider.GetService<UserManager<IdentityUser>>();
var roleManager = app.Services.CreateScope().ServiceProvider.GetService<RoleManager<IdentityRole>>();

if (userManager != null)
    ApplicationDbInitializer.SeedUsers(userManager, roleManager);

app.Services.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>().Database.Migrate();

//app.MapGet("/tasklist/index", async (HttpContext context) => await context.Response.WriteAsync("Tasks"));
//app.MapGet("/task/{id}", async (HttpContext context) => await context.Response.WriteAsync($"Task #{context.Request.RouteValues["id"]}"));

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
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
app.UseAuthorization();
app.MapRazorPages();

#pragma warning disable ASP0014
app.UseEndpoints(routes =>
{
    routes.MapControllerRoute("default", "{controller=Dashboard}/{action=Index}");
});
#pragma warning restore ASP0014

app.Run();
