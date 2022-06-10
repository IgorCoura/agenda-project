using Agenda.API.Configuration;
using Agenda.API.Filters;
using Agenda.Application.Mappers;
using Agenda.Application.Options;
using Agenda.Infrastructure.Context;
using Agenda.Infrastructure.Storage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.Configure<JsonStorageOptions>(config =>
{
    config.FilePath = "\\default_storage.json";
});

builder.Services.Configure<TokenGeneratorOptions>(builder.Configuration.GetSection("Jwt"));

builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options
        .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
        .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution)
        .EnableDetailedErrors()
        .EnableSensitiveDataLogging();

});

builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.ReportApiVersions = true;
});

builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});


builder.Services.AddAuthConfig(builder.Configuration);

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddAutoMapper(typeof(EntityToModelProfile), typeof(ModelToEntityProfile), typeof(ModelToModelProfile));


builder.Services.ResolveDependencies();

builder.Services.AddControllers(opts =>
{
    opts.Filters.Add(new ApplicationExceptionFilter());
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerConfig();


var app = builder.Build();
var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();


app.UseSwaggerConfig(apiVersionDescriptionProvider);


app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
