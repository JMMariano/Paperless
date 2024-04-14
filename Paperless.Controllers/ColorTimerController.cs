using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Paperless.Models;
using System.Collections.Generic;
using System.Linq;

namespace Paperless.Controllers
{
    // TODO : Add exception handling
    [ApiController]
    [Route("api/[controller]")]
    public class ColorTimerController : ControllerBase
    {
        private IRepository _repository;

        //TODO: Add formal logging
        private readonly ILogger<ColorTimerController> _logger;

        public ColorTimerController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("create/{color}")]
        // POST : api/colortimer
        public void CreateColor(string color, string hexCode)
        {
            _repository.AddColor(color, hexCode);
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
        [HttpPost("stop-timer/{color}/{timeElapsed}")]
        // POST : api/colortimer
        public ColorTimer? StopTimer(string color, int timeElapsed)
        {
            ColorTimer? currentColor = _repository.ColorTimers.SingleOrDefault(i => string.Equals(i.Color, color));

            if (currentColor == null)
            {
                // TODO : Add some sort of logging here maybe
                return null;
            }

            currentColor.TotalTimeElapsed = timeElapsed;
            return currentColor;
        }

        [HttpPost("update-file/")]
        public void UpdateFile()
        {
            _repository.UpdateFile();
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