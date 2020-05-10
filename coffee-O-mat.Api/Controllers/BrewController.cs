using System.Collections.Generic;
using System.Threading.Tasks;
using com.b_velop.coffee_O_mat.Application.Brew;
using com.b_velop.coffee_O_mat.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace com.b_velop.coffee_O_mat.Api.Controllers
{
    public class BrewController : MediatRController
    {
        [HttpPost]
        public async Task<ActionResult<Unit>> PostBrew(Create.Command brew)
        {
            return await Mediator.Send(brew);
        }

        [HttpGet]
        public async Task<List<Brew>> List()
        {
            return await Mediator.Send(new List.Query());
        }
    }
}