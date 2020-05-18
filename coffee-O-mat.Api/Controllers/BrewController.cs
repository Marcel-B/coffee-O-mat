using System.Collections.Generic;
using System.Threading.Tasks;
using com.b_velop.coffee_O_mat.Application.Brew;
using com.b_velop.coffee_O_mat.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace com.b_velop.coffee_O_mat.Api.Controllers
{
    public class BrewController : MediatRController
    {
        private readonly ILogger<BrewController> _logger;

        public BrewController(ILogger<BrewController> logger) : base()
        {
            _logger = logger;
        }
        
        [HttpPost]
        public async Task<ActionResult<Unit>> PostBrew(Create.Command brew)
        {
            return await Mediator.Send(brew);
        }

        [HttpGet]
        public async Task<List<Brew>> List([FromQuery]int seconds)
        {
            return await Mediator.Send(new List.Query{Seconds = seconds});
        }
    } 
}