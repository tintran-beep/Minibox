using Minibox.Presentation.Core.Data.Extension;
using Minibox.Presentation.Core.Service.Extension;
using Minibox.Presentation.Share.Module.Mapping;
using Minibox.Presentation.Share.Model;

var builder = WebApplication.CreateBuilder(args);
var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

builder.Configuration.AddJsonFile($"appsettings.json", false, true);
builder.Configuration.AddJsonFile($"appsettings.{env}.json", true, true);
builder.Configuration.AddEnvironmentVariables();

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection(nameof(AppSettings)));

// Add services to the container.
builder.Services.AddControllers();

builder.Services
    .AddMainDbContext(builder.Configuration)
    .AddDataAccessLayer()
    .AddBussinessLogicLayer()
    .AddMapper();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Auto Migration
await app.Services.MigrateAsync();
await app.Services.SeedAdministrativeDirectoryDataAsync();

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
