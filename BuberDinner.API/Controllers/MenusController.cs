using BuberDinner.Application.Authentication.Commands;
using BuberDinner.Application.Services.Authentication.Command;
using BuberDinner.Contracts.Authentication;
using BuberDinner.Contracts.Menus;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.API.Controllers
{
    [Route("hosts/{hostId}/menus")]
    public class MenusController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public MenusController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpPost("createMenu")]
        public IActionResult CreateMenu(CreateMenuRequest request, string hostId)
        {
            return Ok(request);
        }
    }
}
