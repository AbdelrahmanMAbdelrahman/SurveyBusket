using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using SurveyBasket.Data;
using SurveyBasket.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
string?ConnectionString = builder.Configuration["ConnectionStrings:ConnectionString"];
builder.Services.AddDbContext<DatabaseContext>(option => option.UseSqlServer(ConnectionString));
builder.Services.AddScoped<IPollService, PollService>();
builder.Services.AddMapster();
var mapConfig = TypeAdapterConfig.GlobalSettings;
mapConfig.Scan(Assembly.GetExecutingAssembly());
builder.Services.AddSingleton<IMapper>(new Mapper(mapConfig));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.MapOpenApi();
}

app.UseHttpsRedirection();//security

app.UseAuthorization();

app.MapControllers();

app.Run();
