using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using coffee_O_mat.Data.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace com.b_velop.coffee_O_mat.Application.Brew
{
    public class List
    {
        public class Query : IRequest<List<Domain.Models.Brew>>
        {
            public int Seconds { get; set; }
        }

        public class Handler : IRequestHandler<Query, List<Domain.Models.Brew>>
        {
            private readonly ICoffeeOMatRepository _repo;

            public Handler(ICoffeeOMatRepository repo)
            {
                _repo = repo;
            }

            public async Task<List<Domain.Models.Brew>> Handle(Query request, CancellationToken cancellationToken)
            {
                var dt = request.Seconds == 0 ? DateTime.Now.AddHours(-12) : DateTime.Now.AddSeconds(-request.Seconds);
                return await _repo.Brews().Where(b => b.Created > dt).ToListAsync(cancellationToken);
            }
        }
    }
}