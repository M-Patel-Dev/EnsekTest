using MediatR;
using Microsoft.EntityFrameworkCore;
using MP.EnsekTest.Api.Business.MeterReads;
using MP.EnsekTest.Api.Configuration;
using MP.EnsekTest.Api.Dtos;
using MP.EnsekTest.Data.Database;
using MP.EnsekTest.Data.Repositories;
using MP.EnsekTest.Utilities.Helpers;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var dbOptions = new EnsekDatabaseOptions();

builder.Configuration.GetSection(
    EnsekDatabaseOptions.ConfigurationSectionName)
    .Bind(dbOptions);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddDbContext<EnsekContext>(options => options.UseMySQL(dbOptions.ConnectionString));
builder.Services.AddScoped<EnsekDatabaseCreator>();


builder.Services.AddScoped<IMeterReadingsService, MeterReadingsService>();
builder.Services.AddScoped<IMeterReadingsValidator, MeterReadingsValidator>();
builder.Services.AddScoped<IMeterReadingsPersistor, MeterReadingsPersistor>();
builder.Services.AddScoped<IMeterReadRepository, MeterReadRepository>();
builder.Services.AddSingleton<ICsvParser<MeterReadingDto>, CsvParser<MeterReadingDto>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.CreateEnsekDatabase();
}

app.UseHttpsRedirection();
app.UseHsts();

app.UseAuthorization();

app.MapControllers();

app.Run();
