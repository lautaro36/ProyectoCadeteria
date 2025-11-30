using ProyectoCadeteria.Repositories;
using ProyectoCadeteria.Options;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DatabaseOptions>(
    builder.Configuration.GetSection("DatabaseOptions"));

builder.Services.AddScoped<ICadeteriaRepository>(provider =>
{
    var options = provider.GetRequiredService<IOptions<DatabaseOptions>>();
    return new CadeteriaRepository(options);
});

builder.Services.AddScoped<ICadeteRepository>(provider =>
{
    var options = provider.GetRequiredService<IOptions<DatabaseOptions>>();
    return new CadeteRepository(options);
});

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
