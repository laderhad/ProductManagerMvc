using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebApplication4.Web.Helper;
using WebApplication4.Web.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



builder.Services.AddDbContext<AppDbContext>(options =>
{   //dbcontext
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlCon"));
});

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

//builder.Services.AddSingleton<IHelper,Helper>();
//builder.Services.AddTransient<IHelper, Helper>();

//builder.Services.AddScoped<Helper>(sp=>new Helper());




var app = builder.Build();

//builder.Services.AddDbContext<AppDbContext>(options =>
//{

	//options.UseSqlServer(builder.Configuration.GetConnectionString("SqlCon"));

//}); 


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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
