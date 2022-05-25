using Agenda.API.Configuration;
using Agenda.Application.Mappers;
using Agenda.Infrastructure.Context;
using Agenda.Infrastructure.Storage;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.Configure<JsonStorageOptions>(config =>
{
    config.FilePath = "\\default_storage.json";
});

builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options
        .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AgendaDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution)
        .EnableDetailedErrors()
        .EnableSensitiveDataLogging();

});

builder.Services.AddAutoMapper(typeof(EntityToModelProfile), typeof(ModelToEntityProfile), typeof(ModelToModelProfile));


builder.Services.ResolveDependencies();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
