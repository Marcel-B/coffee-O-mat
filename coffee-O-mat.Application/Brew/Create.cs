using System;
using System.Threading;
using System.Threading.Tasks;
using coffee_O_mat.Data.Contracts;
using MediatR;

namespace com.b_velop.coffee_O_mat.Application.Brew
{
    public class Create
    {
        public class Command : IRequest
        {
            public double Temp { get; set; }
            public double Solltemp { get; set; }
            public double Output { get; set; }
            public double KP { get; set; }
            public double KI { get; set; }
            public double KD { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly ICoffeeOMatRepository _repo;

            public Handler(ICoffeeOMatRepository repo)
            {
                _repo = repo;
            }

            public async Task<Unit> Handle(
                Command request,
                CancellationToken cancellationToken)
            {
                var brew = new Domain.Models.Brew
                {
                    Created = DateTime.Now,
                    KD = request.KD,
                    Output = request.Output,
                    KP = request.KP,
                    KI = request.KI,
                    Temperature = request.Temp,
                    TargetTemperature = request.Solltemp
                };
                _repo.AddBrew(brew);
                var result = await _repo.SaveChanges();
                return Unit.Value;
            }
        }
    }
}