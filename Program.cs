using ClientesBlazorApp.Components;
using ClientesBlazorApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<ClienteApiService>(client =>
{
    var apiBaseUrl = builder.Configuration["ApiBaseUrl"] ?? "http://localhost:5000/";
    client.BaseAddress = new Uri(apiBaseUrl);
});

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Oculta el header "Server: Kestrel"
builder.WebHost.ConfigureKestrel(o => o.AddServerHeader = false);

var app = builder.Build();

// Headers de seguridad (OnStarting corre al final y pisa el CSP por defecto de Blazor)
app.Use(async (context, next) =>
{
    context.Response.OnStarting(() =>
    {
        var host = context.Request.Host.Value;
        var h = context.Response.Headers;

        h["X-Content-Type-Options"] = "nosniff";
        h["Referrer-Policy"] = "no-referrer";
        h["Permissions-Policy"] = "geolocation=(), camera=(), microphone=()";
        h["Content-Security-Policy"] =
            "default-src 'self'; " +
            "script-src 'self'; " +
            "style-src 'self'; " +
            "img-src 'self' data:; " +
            "font-src 'self'; " +
            $"connect-src 'self' ws://{host} wss://{host}; " +
            "object-src 'none'; " +
            "base-uri 'self'; " +
            "form-action 'self'; " +
            "frame-ancestors 'none'";

        return Task.CompletedTask;
    });
    await next();
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();