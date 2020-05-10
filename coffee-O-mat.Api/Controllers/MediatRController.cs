using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace com.b_velop.coffee_O_mat.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediatRController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());
    }
}