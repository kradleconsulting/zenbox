using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using zenbox.data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();

var app = builder.Build();

ApplicationDbContext dbcontext = app.Services.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
dbcontext.Database.EnsureCreated();

var userManager = app.Services.CreateScope().ServiceProvider.GetService<UserManager<IdentityUser>>();

if (userManager != null)
    ApplicationDbInitializer.SeedUsers(userManager);

app.Services.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>().Database.Migrate();

app.MapGet("/tasks", async (HttpContext context) => await context.Response.WriteAsync("Tasks"));
app.MapGet("/task/{id}", async (HttpContext context) => await context.Response.WriteAsync($"Task #{context.Request.RouteValues["id"]}"));


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

app.Run();
