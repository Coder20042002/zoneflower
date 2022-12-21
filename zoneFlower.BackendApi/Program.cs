using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using zoneFlower.Application.Catalog.Products;
using zoneFlower.Data.EF;
using zoneFlower.Utilities.Constants;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ZFlowerDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString(SystemConstants.MainConnectionString)
    )) ;
//Declare DI
builder.Services.AddTransient<IPublicProductService, PublicProductService>();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger zoneflower Solution", Version = "v1" }
    );
});
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

app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger zoneflower V1");
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
