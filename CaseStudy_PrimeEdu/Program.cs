using CaseStudy_PrimeEdu.Data;
using CaseStudy_PrimeEdu.Data.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext configuration
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));
// Add services to the container.
builder.Services.AddScoped<IStudentsService, StudentsService>();
builder.Services.AddScoped<ITeachersService, TeachersService>();
builder.Services.AddScoped<ICoursesService, CoursesService>();
builder.Services.AddScoped<ITestsService, TestsService>();

//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//    .AddCookie(options => {
//        options.LoginPath = "/Account/Login"; //TODO
//        options.LogoutPath = "/Account/Logout"; //TODO
//        options.Cookie.Name = "CaseStudy_PrimeEdu"; //TODO
//        options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
//    });


builder.Services.AddControllersWithViews();

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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//Seed Database
AppDbInitializer.Seed(app);

app.Run();
