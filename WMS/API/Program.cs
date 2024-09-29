using API.Extensions;
using API.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Add Application Service Extensions services
builder.Services.AddApplicationServices(builder.Configuration);

// TODO - Add Identity Extension Service here

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






await app.RunAsync();


