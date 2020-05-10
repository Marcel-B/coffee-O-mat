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
            _logger.LogInformation($"Incoming data:\nTemperature: {brew.Temp}\nTarget: {brew.Solltemp}\nOutput: {brew.Output}\nP: {brew.KP}\nI: {brew.KI}\nD: {brew.KD}");
            return await Mediator.Send(brew);
        }

        [HttpGet]
        public async Task<List<Brew>> List()
        {
            return await Mediator.Send(new List.Query());
        }
    }
}