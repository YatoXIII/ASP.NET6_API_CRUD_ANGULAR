using Microsoft.EntityFrameworkCore;
using SamgauTestTask.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string connectionString = "Host=localhost;Port=5433;" +
                "Database=SamgauTest;Username=postgres;Password=gjxtve12";
builder.Services.AddDbContext<SomeContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
