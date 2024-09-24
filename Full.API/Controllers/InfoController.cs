namespace Full.API.Controllers;

using Core.Contracts;
using Full.API.Models;
using Microsoft.AspNetCore.Mvc;

[Route("info")]
public class InfoController : ControllerBase
{
    [HttpGet("request-analysis")]
    public IActionResult RequestAnalysis()
        => this.Ok($"{this.Request.Method} {this.Request.Path}, Content Length: {this.Request.ContentLength ?? 0}");

    [HttpPost("log")]
    public async Task<IActionResult> Log([FromBody] LogRequest request, [FromServices] ILogWriter logWriter, CancellationToken cancellationToken)
    {
        var logId = await logWriter.WriteAsync(request.Severity, request.Message, cancellationToken);
        return this.Ok(logId);
    }
}