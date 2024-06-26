using Hotel.Application;
using Hotel.Extensions;
using Hotel.Infrastructure;
using Hotel.Infrastructure.Persistence;
using Hotel.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddValidationServices();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCorsService();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    await using var scope = app.Services.CreateAsyncScope();
    var initializer = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitializer>();
    await initializer.InitAsync();
}

app.UseMiddleware<ExceptionMiddleware>();
app.UseCors("DefaultPolicy");
app.MapControllers();

app.Run();