using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using NoteApp;
using NoteApp.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<NoteService>();
builder.Services.AddHttpClient<INoteService, NoteService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7100/");
});
await builder.Build().RunAsync();
