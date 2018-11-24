namespace Eventures.Web.Controllers
{
    using Eventures.Services.Contracts;
    using Eventures.Services.Models;
    using Eventures.Web.Middleware;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class EventsController : Controller
    {
        private readonly IEventsService eventsService;

        public EventsController(IEventsService eventsService)
        {
            this.eventsService = eventsService;
        }

        [Authorize(Roles ="Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [TypeFilter(typeof(LogEventCreateActionFilter))]
        public IActionResult Create(EventCreate model)
        {
            if (ModelState.IsValid)
            {
                eventsService.Create(model);
                return Redirect("/");
            }

            return View(model);
        }

        [Authorize]
        public IActionResult All()
        {
            var model = eventsService.All();
            return View(model);
        }
    }
}