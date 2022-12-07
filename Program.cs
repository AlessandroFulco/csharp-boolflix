using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using csharp_boolflix.Data;
using csharp_boolflix.Data.Repositories.Film;
using csharp_boolflix.Data.Repositories.MyInterface;
using csharp_boolflix.Data.Repositories.Serie;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("BoolflixDbContext");
builder.Services.AddDbContext<BoolflixDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<BoolflixDbContext>();

builder.Services.AddScoped<IDbMovieRepositories, DbMovieRepositories>();
builder.Services.AddScoped<IDbTvShowRepositories, DbTvShowRepositories>();
builder.Services.AddScoped<IDbActorRepositories, DbActorRepositories>();
builder.Services.AddScoped<IDbCategoryRepositories, DbCategoryRepositories>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Guest}/{action=Index}/{id?}");

app.Run();
