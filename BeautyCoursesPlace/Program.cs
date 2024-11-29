using BeautyCoursesPlace.Infrastructure.Data;
using BeautyCoursesPlace.ModelBinders;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddApplicationDbContext(builder.Configuration);
builder.Services.AddApplicationIdentity(builder.Configuration);

builder.Services.AddControllersWithViews(option =>
{ 
   option.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
});

builder.Services.AddApplicationService();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
   
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapDefaultControllerRoute();

app.MapRazorPages();

await app.RunAsync();
