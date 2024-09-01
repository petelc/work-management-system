using Persistence;
using Microsoft.EntityFrameworkCore;
using wmsApi.Extensions;
using wmsApi.Middleware;
using Domain;
using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers();
// ! Extensions
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.Use(async (context, next) =>
    {
        context.Response.Headers.Add("Strict-Transport-Security", "max-age=31536000");
        await next.Invoke();
    });
}

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.UseDefaultFiles();
app.UseStaticFiles();
app.MapControllers();

app.MapFallbackToController("Index", "Fallback");

using var scoped = app.Services.CreateScope();
var services = scoped.ServiceProvider;

try
{
    var context = services.GetRequiredService<DataContext>();
    var userManager = services.GetRequiredService<UserManager<AppUser>>();
    await context.Database.MigrateAsync();
    await Seed.SeedData(context, userManager);
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An Error occurred in Program");

}


app.Run();


