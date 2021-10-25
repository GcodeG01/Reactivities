using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Activities;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController // endpoint is /activities
    {
        [HttpGet] // activities
        public async Task<IActionResult> GetActivities() // ActionResult needs a certain return or will log out error
        {
            var result = await Mediator.Send(new List.Query());
            return HandleResult(result);
        }

        // [Authorize] // replaced this attribute with added controller opt
        [HttpGet("{id}")] // activities/id
        public async Task<IActionResult> GetActivity(Guid id)
        {
            var result = await Mediator.Send(new Details.Query{Id = id});
            return HandleResult(result);
        }

        [HttpPost] // BaseApiControll [ApiController] knows that objects activity is coming from Body
        public async Task<IActionResult> CreateActivity(Activity activity) //IActionResult gives us access to response types, without specifying type, such as Ok, bad request, not found...
        {
            var result = await Mediator.Send(new Create.Command{Activity = activity});
            return HandleResult(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditActivity(Guid id, Activity activity)
        {
            activity.Id = id;
            var result = await Mediator.Send(new Edit.Command{Activity = activity});
            return HandleResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(Guid id)
        {
            var result = await Mediator.Send(new Delete.Command{Id = id});
            return HandleResult(result);
        }
    }
}