using BeautyCoursesPlace.Infrastructure.Data;
using BeautyCoursesPlace.Infrastructure.Data.Models;
using BeautyCoursesPlace.ModelBinders;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("BeautyCoursesDbContextConnection") ?? throw new InvalidOperationException("Connection string 'BeautyCoursesDbContextConnection' not found.");


builder.Services.AddApplicationDbContext(builder.Configuration);
builder.Services.AddApplicationIdentity(builder.Configuration);



builder.Services.AddControllersWithViews(option =>
{
    option.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
    option.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
})
    .AddViewLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization();


builder.Services.AddApplicationService();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error/500");
    app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "Course Details",
      pattern: "/Course/Details/{id}/{information}",
      defaults: new { Controller = "Course", Action = "Details" }
  );

   

    endpoints.MapControllerRoute(
           name: "areas",
           pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
   );


    endpoints.MapDefaultControllerRoute();
    endpoints.MapRazorPages();
});

await app.CreateAdminRoleAsync();

await app.RunAsync();
