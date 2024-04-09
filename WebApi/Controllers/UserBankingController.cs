using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Interfaces;

namespace WebApi.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class UserBankingController : ControllerBase
{
    private readonly IBankingService _bankingService;

    public UserBankingController(IBankingService bankingService)
    {
        _bankingService = bankingService;
    }

    [HttpPost("CreateDebit")]
    public async Task<ActionResult> Debit([FromBody] TransactionRequest request)
    {
        try
        {
            await _bankingService.Debit(request.UserId, request.Amount);
            return Ok();
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost("CreateCredit")]
    public async Task<ActionResult> Credit([FromBody] TransactionRequest request)
    {
        try
        {
            await _bankingService.Credit(request.UserId, request.Amount);
            return Ok();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}
