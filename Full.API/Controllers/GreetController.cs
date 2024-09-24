namespace Full.API.Controllers;

using Microsoft.AspNetCore.Mvc;

[Route("greet")]
public class GreetController : ControllerBase
{
    [HttpGet]
    public IActionResult Greet() => this.Ok("Hello, world!");

    [HttpGet("{name}")]
    public IActionResult Greet(string name) => this.Ok($"Hello, {name}!");
}