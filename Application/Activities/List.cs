using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities // Query
{
    public class List
    {
        // IRequest is for Queries and Commands! Put in a return type ex. List<Activity>
        public class Query : IRequest<Result<List<Activity>>> {} // can use record instead of class, so that the query is immutable.

        // IRequestHandler handles the query or command, optionally, if there's an output you put what the output is ex. List<Activity>.
        public class Handler : IRequestHandler<Query, Result<List<Activity>>> 
        {
            private readonly DataContext _context; // Handler is the only place that knows about data access
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<Activity>>> Handle(Query request, CancellationToken cancellationToken) // CancellationToken optional return
            {
                var activities = await _context.Activities.ToListAsync(cancellationToken);

                return Result<List<Activity>>.Success(activities);
            }
        }
    }
}