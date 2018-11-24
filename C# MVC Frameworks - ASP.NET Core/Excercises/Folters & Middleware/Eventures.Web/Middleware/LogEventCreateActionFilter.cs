namespace Eventures.Web.Middleware
{
    using Eventures.Services.Models;
    using Eventures.Web.Controllers;
    using Eventures.Web.Extensions;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.Logging;
    using System;

    public class LogEventCreateActionFilter : ActionFilterAttribute
    {
        private readonly ILogger logger;

        public LogEventCreateActionFilter(ILogger<EventsController> logger)
        {
            this.logger = logger;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            ///Console and file Logger used, the log for me is in the .Web project root directory. 
            ///Everything is logged, not only the custom message here.
            ///The log gets lost in other logs search for "Administrator"
            
            var eventCreateModel = new EventCreate
            {
                End = DateTime.Parse(context.HttpContext.Request.Form["End"]),
                Start = DateTime.Parse(context.HttpContext.Request.Form["Start"]),
                Name = context.HttpContext.Request.Form["Name"],
                Place = context.HttpContext.Request.Form["Place"],
                PricePerTicket = decimal.Parse(context.HttpContext.Request.Form["PricePerTicket"]),
                TotalTickets = int.Parse(context.HttpContext.Request.Form["TotalTickets"])
            };

            if (!context.ModelState.IsValid)
            {
                logger.LogInformation($"Event \"{eventCreateModel.Name}\" was not created because of invalid data!");
                return;
            }

            logger.LogInformation($"[{DateTime.UtcNow.ToEventuresFormat()}] " +
                $"Administrator {context.HttpContext.User.Identity.Name} create " +
                $"event {eventCreateModel.Name} ({eventCreateModel.Start.ToEventuresFormat()} /" +
                $" {eventCreateModel.End.ToEventuresFormat()}).");
            base.OnActionExecuted(context);
        }
    }
}
