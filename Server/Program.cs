using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using ProStellar.Server.Data;
using ProStellar.Server.Models;
using ProStellar.Server.Services.CantidadService;
using ProStellar.Server.Services.EmpleadoServices;
using ProStellar.Server.Services.NominaService;
using ProStellar.Server.Services.ProyectoService;
using ProStellar.Server.Services.TipoPagoServices;
using ProStellar.Server.Services.TrabajoServices;
using ProStellar.Server.Services.EstadoService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddIdentityServer()
    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

builder.Services.AddAuthentication()
    .AddIdentityServerJwt();





builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//servicios del programas//
// builder.Services.AddScoped<ITrabajoService, TrabajoService>();
// builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();
// builder.Services.AddScoped<ICantidadService, CantidadService>();
// builder.Services.AddScoped<INominaService, NominaService>();
// builder.Services.AddScoped<IProyectoService, ProyectoService>();
// builder.Services.AddScoped<ITipoPagoServices, TipoPagoService>();
// builder.Services.AddScoped<IEstadoService, EstadoService>();

var app = builder.Build();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseIdentityServer();
app.UseAuthorization();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
