namespace Full.API.Controllers;

using Core.Contracts;
using Microsoft.AspNetCore.Mvc;

[Route("calc-async")]
public class AsyncCalculationsController(ICalculator calculator) : ControllerBase
{
    private readonly ICalculator _calculator = calculator ?? throw new ArgumentNullException(nameof(calculator));

    [HttpGet("add")]
    public async Task<IActionResult> Add([FromQuery] int a, [FromQuery] int b, CancellationToken cancellationToken)
    {
        var result = await this._calculator.AddAsync(a, b, cancellationToken);
        return this.Ok(result);
    }
    
    [HttpGet("subtract")]
    public async Task<IActionResult> Subtract([FromQuery] int a, [FromQuery] int b, CancellationToken cancellationToken)
    {
        var result = await this._calculator.SubtractAsync(a, b, cancellationToken);
        return this.Ok(result);
    }
    
    [HttpGet("multiply")]
    public async Task<IActionResult> Multiply([FromQuery] int a, [FromQuery] int b, CancellationToken cancellationToken)
    {
        var result = await this._calculator.MultiplyAsync(a, b, cancellationToken);
        return this.Ok(result);
    }
    
    [HttpGet("divide")]
    public async Task<IActionResult> Divide([FromQuery] int a, [FromQuery] int b, CancellationToken cancellationToken)
    {
        var result = await this._calculator.DivideAsync(a, b, cancellationToken);
        return this.Ok(result);
    }
}