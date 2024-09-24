using Core;
using Core.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ICalculator, Calculator>();
builder.Services.AddSingleton<ILogWriter, LogWriter>();
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();