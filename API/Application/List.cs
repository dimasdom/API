﻿using API.Context;
using API.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application
{
    public class List
    {
        public class Query : IRequest<List<Activity>> { };

        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            private DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                var activities = await  _context.Activities.ToListAsync();

                return activities;

            }
        }
    }
}
