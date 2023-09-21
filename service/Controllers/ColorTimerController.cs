using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using service.Models;
using System;
using System.Collections.Generic;

namespace service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ColorTimerController : ControllerBase
    {
        //TODO: Move to a model
        private static readonly string[] Colors = new[]
        {
            "Red","Blue"
        };

        //TODO : delete after
        private static IList<ColorTimer> _timers = new List<ColorTimer>();

        //TODO: Add formal logging
        private readonly ILogger<ColorTimerController> _logger;

        public ColorTimerController(ILogger<ColorTimerController> logger)
        {
            _logger = logger;
            Console.WriteLine("New Instance");
        }

        [HttpPost("create")]
        // POST : api/colortimer
        public void CreateColor()
        {
            _timers.Add(new ColorTimer("Red"));
            _timers[0].Descriptions.Add(new ColorTimerDescription("Empty"));
        }

        //TODO: Add proper comments
        // GET : api/colortimer
        [HttpGet]
        public IEnumerable<ColorTimer> GetAllColors()
        {
            return _timers;
        }
    }
}