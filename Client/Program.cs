global using System.Net.Http.Json;
global using ProStellar.Shared.Models;
using ProStellar.Client.Services.CantidadServices;
using ProStellar.Client.Services.EmpleadoServices;
using ProStellar.Client.Services.NominaServices;
using ProStellar.Client.Services.ProyectoServices;
using ProStellar.Client.Services.TipoPagoServices;
using ProStellar.Client.Services.TrabajoServices;
using ProStellar.Client.Services.EstadoServices;
// using ProStellar.Client.Services.PagoServices;
using ProStellar.Shared;
using Radzen;
using Radzen.Blazor;
//using blazorStrap
using BlazorStrap;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ProStellar.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("ProStellar.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("ProStellar.ServerAPI"));


//agregamos los servicos
builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();
builder.Services.AddScoped<ICantidadService, CantidadService>();
builder.Services.AddScoped<IEstadoService, EstadoService>();
builder.Services.AddScoped<INominaService, NominaService>();
// builder.Services.AddScoped<IPagoService, PagoService>();
builder.Services.AddScoped<IProyectoService, ProyectoService>();
builder.Services.AddScoped<ITipoPagoService, TipoPagoService>();
builder.Services.AddScoped<ITrabajoService, TrabajoService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<TooltipService>();


//agregamos BlazorStrap
builder.Services.AddBlazorStrap();

builder.Services.AddApiAuthorization();

await builder.Build().RunAsync();
