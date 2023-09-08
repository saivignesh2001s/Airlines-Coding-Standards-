using Airlines.AirDbContext;
using Airlines.Automap;
using Airlines.Model;
using Airlines.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

 var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
 builder.Services.AddControllersWithViews(cfg =>
            {
                cfg.Filters.Add(typeof(CustomException));
            });
  builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
           
  string? connectionString = builder.Configuration.GetConnectionString("default").ToString();
  builder.Services.AddDbContext<AirlineDbContext>(options=>options.UseSqlServer(connectionString));
  builder.Services.AddTransient<IRepository<Airline>, Repository<Airline>>();

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

app.MapControllerRoute(
          name: "default",
          pattern: "{controller=Airlines}/{action=Index}/{id?}");

app.Run();
       