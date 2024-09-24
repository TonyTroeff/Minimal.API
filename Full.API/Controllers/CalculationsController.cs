namespace Full.API.Controllers;

using Core.Contracts;
using Microsoft.AspNetCore.Mvc;

[Route("calc")]
public class CalculationsController(ICalculator calculator) : ControllerBase
{
    private readonly ICalculator _calculator = calculator ?? throw new ArgumentNullException(nameof(calculator));

    [HttpGet("add")]
    public IActionResult Add([FromQuery] int a, [FromQuery] int b)
    {
        var result = this._calculator.Add(a, b);
        return this.Ok(result);
    }
    
    [HttpGet("subtract")]
    public IActionResult Subtract([FromQuery] int a, [FromQuery] int b)
    {
        var result = this._calculator.Subtract(a, b);
        return this.Ok(result);
    }
    
    [HttpGet("multiply")]
    public IActionResult Multiply([FromQuery] int a, [FromQuery] int b)
    {
        var result = this._calculator.Multiply(a, b);
        return this.Ok(result);
    }
    
    [HttpGet("divide")]
    public IActionResult Divide([FromQuery] int a, [FromQuery] int b)
    {
        var result = this._calculator.Divide(a, b);
        return this.Ok(result);
    }
    
    [HttpGet("primes")]
    public IActionResult Primes([FromQuery] int max)
    {
        var result = this._calculator.FindAllPrimes(max);
        return this.Ok(result);
    }
}