using Blazored.LocalStorage;
using Blazored.Modal;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Morris.Blazor.Validation;
using Radzen;
using RentACar.Application.DTOs;
using RentACar.Client;
using RentACar.Client.Utils;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddRadzenComponents();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<ModalManager>();
builder.Services.AddScoped<NotificationService>();

builder.Services.AddBlazoredModal();
builder.Services.AddFormValidation(config => config.AddFluentValidation(typeof(CarDTO).Assembly));
builder.Services.AddFormValidation(config => config.AddFluentValidation(typeof(ReservationDTO).Assembly));
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
builder.Services.AddRadzenComponents();
await builder.Build().RunAsync();
