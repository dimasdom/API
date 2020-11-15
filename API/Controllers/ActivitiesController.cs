using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Context;
using API.Models;
using MediatR;
using API.Application;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private IMediator _mediator;

        public ActivitiesController(IMediator mediator)
        {
            _mediator = mediator;
        }   

        // GET: api/Activities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Activity>>> GetActivities()
        {
            return await _mediator.Send(new List.Query());
        }

        // GET: api/Activities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            var activity = await _mediator.Send(new Details.Query{Id=id });

            if (activity == null)
            {
                return NotFound();
            }

            return activity;
        }
        
        // PUT: api/Activities/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> PutActivity(Guid id, Edit.Command command)
        {
            command.Id = id;
            return await _mediator.Send(command);
        }
        // POST: api/Activities
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Unit>> Create(Create.Command command)
        {
            return await _mediator.Send(command);
        }
        /*
        // DELETE: api/Activities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Activity>> DeleteActivity(Guid id)
        {
            var activity = await _context.Activities.FindAsync(id);
            if (activity == null)
            {
                return NotFound();
            }

            _context.Activities.Remove(activity);
            await _context.SaveChangesAsync();

            return activity;
        }

        private bool ActivityExists(Guid id)
        {
            return _context.Activities.Any(e => e.Id == id);
        }
        */
    }
}
