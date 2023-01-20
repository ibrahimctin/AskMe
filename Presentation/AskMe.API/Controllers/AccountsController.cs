using AskMe.Domain.Application.Features.Identity.Authentication.Login.Requests;
using AskMe.Domain.Application.Features.Identity.Authentication.Register.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AskMe.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginCommand loginCommand, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(loginCommand, cancellationToken);

            return Ok(result);

        } 
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterCommand registerCommand, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(registerCommand, cancellationToken);

            return Ok(result);

        }
    }
}
