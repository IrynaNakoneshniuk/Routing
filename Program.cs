using System;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews(

    mvcOptions =>
    {
        mvcOptions.EnableEndpointRouting = false;
    });

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
   
app.UseMvc(route =>
{
    route.MapRoute(
        "Default",
                "{controller}/{action}",                     
                new { controller = "Gettimesuniversal", action = "Utc"}
        );
    route.MapRoute(
       "DefaultTime",
               "gettime/time/{id?}",
               new { controller = "Gettimesuniversal", action = "Time",id=" " }
       );
});

app.Run();
