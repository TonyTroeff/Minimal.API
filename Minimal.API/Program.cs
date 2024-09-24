using System.Reflection;
using Core;
using Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Minimal.API.Models;

var builder = WebApplication.CreateSlimBuilder(args);

// builder.Services.ConfigureHttpJsonOptions(options => options.SerializerOptions.TypeInfoResolverChain.Insert(0, ApiJsonContext.Default));
builder.Services.AddSingleton<ICalculator, Calculator>();
builder.Services.AddSingleton<ILogWriter, LogWriter>();

var app = builder.Build();

app.MapGet("greet", () => "Hello, world!");
app.MapGet("greet/{name}", (string name) => $"Hello, {name}!");

var calcGroup = app.MapGroup("calc");
calcGroup.MapGet("add", ([FromQuery] int a, [FromQuery] int b, [FromServices] ICalculator calculator) => calculator.Add(a, b));
calcGroup.MapGet("subtract", ([FromQuery] int a, [FromQuery] int b, [FromServices] ICalculator calculator) => calculator.Subtract(a, b));
calcGroup.MapGet("multiply", ([FromQuery] int a, [FromQuery] int b, [FromServices] ICalculator calculator) => calculator.Multiply(a, b));
calcGroup.MapGet("divide", ([FromQuery] int a, [FromQuery] int b, [FromServices] ICalculator calculator) => calculator.Divide(a, b));
calcGroup.MapGet("primes", ([FromQuery] int max, [FromServices] ICalculator calculator) => calculator.FindAllPrimes(max));

var asyncCalcGroup = app.MapGroup("calc-async");
asyncCalcGroup.MapGet("add", async ([FromQuery] int a, [FromQuery] int b, [FromServices] ICalculator calculator, CancellationToken cancellationToken) =>
{
    var result = await calculator.AddAsync(a, b, cancellationToken);
    return Results.Ok(result);
});
asyncCalcGroup.MapGet("subtract", async ([FromQuery] int a, [FromQuery] int b, [FromServices] ICalculator calculator, CancellationToken cancellationToken) =>
{
    var result = await calculator.SubtractAsync(a, b, cancellationToken);
    return Results.Ok(result);
});
asyncCalcGroup.MapGet("multiply", async ([FromQuery] int a, [FromQuery] int b, [FromServices] ICalculator calculator, CancellationToken cancellationToken) =>
{
    var result = await calculator.MultiplyAsync(a, b, cancellationToken);
    return Results.Ok(result);
});
asyncCalcGroup.MapGet("divide", async ([FromQuery] int a, [FromQuery] int b, [FromServices] ICalculator calculator, CancellationToken cancellationToken) =>
{
    var result = await calculator.DivideAsync(a, b, cancellationToken);
    return Results.Ok(result);
});

var infoGroup = app.MapGroup("info");
infoGroup.MapGet("request-analysis", (HttpRequest request) => $"{request.Method} {request.Path}, Content Length: {request.ContentLength ?? 0}");
infoGroup.MapPost("log", async ([FromBody] LogRequest request, [FromServices] ILogWriter logWriter, CancellationToken cancellationToken) =>
{
    var logId = await logWriter.WriteAsync(request.Severity, request.Message, cancellationToken);
    return Results.Ok(logId);
});
infoGroup.MapGet("reflection", () =>
{
    var type = Assembly.GetExecutingAssembly().GetType("Minimal.API.LoadDynamically");
    return type is not null;
});

app.Run();

// [JsonSerializable(typeof(string)), JsonSerializable(typeof(string[])), JsonSerializable(typeof(int)), JsonSerializable(typeof(int[])), JsonSerializable(typeof(bool))]
// [JsonSerializable(typeof(LogRequest))]
// internal partial class ApiJsonContext : JsonSerializerContext;