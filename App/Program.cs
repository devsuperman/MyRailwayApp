using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Contexto>(options =>
    options.UseNpgsql(ConnectionHelper.GetConnectionString(builder.Configuration)));

builder.Services.AddControllersWithViews();

var portVar = Environment.GetEnvironmentVariable("PORT");

if (portVar is { Length: > 0 } && int.TryParse(portVar, out int port))
{
    builder.WebHost.ConfigureKestrel(options =>
    {
        options.ListenAnyIP(port);
    });
}

var app = builder.Build();

var scope = app.Services.CreateScope();
await DataHelper.ManageDataAsync(scope.ServiceProvider);


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
