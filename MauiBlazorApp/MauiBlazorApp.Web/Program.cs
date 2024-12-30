using MauiBlazorApp.Shared.Services;
using MauiBlazorApp.Web.Components;
using MauiBlazorApp.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

// Add device-specific services used by the MauiBlazorApp.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();

//+>>20241229
builder.Services.AddHttpClient("API", client =>
{
    client.BaseAddress = new Uri("http://localhost:7048");
});
builder.Services.AddScoped<DeutschAdjSuffixService>();
//+<<20241229

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(
        typeof(MauiBlazorApp.Shared._Imports).Assembly,
        typeof(MauiBlazorApp.Web.Client._Imports).Assembly);

app.Run();
