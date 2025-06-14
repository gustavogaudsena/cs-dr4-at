using DR3_AT.Context;
using DR3_AT.Data;
using DR3_AT.Interfaces;
using DR3_AT.Models;
using DR3_AT.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddAuthentication("CookieAuthentication")
    .AddCookie("CookieAuthentication", options =>
    {
        options.Cookie.Name = "AgenciaTurismo.Auth";
        options.LoginPath = "/Login";
    });

builder.Services.AddDbContext<AgenciaTurismoContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("LibraryConnection"));
});
builder.Services.AddDbContext<MyDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("LibraryConnection"));
});

builder.Services.AddScoped<IReservaService, ReservaService>();
builder.Services.AddScoped<IPacoteTuristicoService, PacoteTuristicoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); 
app.UseAuthorization();  

app.MapRazorPages();

app.Run();