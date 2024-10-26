using API.Extensions;
using API.Middleware;
using Domain;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers(opt =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    opt.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
//builder.Services.AddValidatorsFromAssemblyContaining<Create>();

// Add Application Service Extensions services
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);


// Configure the HTTP request pipeline.
var app = builder.Build();

// Add Exception Middleware
app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPIv8 v1"));
}
else
{
    // TODO
}

//app.UseHttpsRedirection();

app.UseRouting();
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


using var scope = app.Services.CreateScope();

var services = scope.ServiceProvider;
var context = services.GetRequiredService<WMSContext>();
var userManager = services.GetRequiredService<UserManager<Employee>>();
var logger = services.GetRequiredService<ILogger<Program>>();

try
{
    //var roleManager = services.GetRequiredService<RoleManager<Role>>();
    //await context.Database.MigrateAsync();
    //await Seed.SeedData(context, userManager);
}
catch (Exception ex)
{
    logger.LogError(ex, "An Error Occurred durring Migration");
}



await app.RunAsync();


