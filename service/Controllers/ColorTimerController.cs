using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using service.Models;
using System.Collections.Generic;
using System.Linq;

namespace service.Controllers
{
    // TODO : Add exception handling
    [ApiController]
    [Route("api/[controller]")]
    public class ColorTimerController : ControllerBase
    {
        private IRepository _repository;

        //TODO: Add formal logging
        private readonly ILogger<ColorTimerController> _logger;

        public ColorTimerController(IRepository repository, ILogger<ColorTimerController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpPost("create/{color}")]
        // POST : api/colortimer
        public void CreateColor(string color)
        {
            _repository.AddColor(color);
        }

        // TODO : Add user id in the future {id}/start-timer/{color}
        // TODO : Add description parameter
        [HttpPost("start-timer/{color}")]
        // POST : api/colortimer
        public ColorTimer? StartTimer(string color)
        {
            ColorTimer? currentColor = _repository.ColorTimers.SingleOrDefault(i => string.Equals(i.Color, color));

            if (currentColor == null)
            {
                // TODO : Add some sort of logging here maybe
                return null;
            }

            return currentColor;
            //currentColor.StartTimer();
        }

        // TODO : Add user id in the future i.e. {id}/stop-timer/{color}
        // TODO : Add description parameter
        [HttpPost("stop-timer/{color}")]
        // POST : api/colortimer
        public ColorTimer? StopTimer(string color)
        {
            ColorTimer? currentColor = _repository.ColorTimers.SingleOrDefault(i => string.Equals(i.Color, color));

            if (currentColor == null)
            {
                // TODO : Add some sort of logging here maybe
                return null;
            }

            //currentColor.StopTimer();
            return currentColor;
        }

        //TODO: Add proper comments
        // GET : api/colortimer
        [HttpGet]
        public IEnumerable<ColorTimer> GetAllColors()
        {
            return _repository.ColorTimers;
        }
    }
}