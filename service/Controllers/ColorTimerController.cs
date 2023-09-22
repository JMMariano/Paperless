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
        private IRepository _repository;

        //TODO: Add formal logging
        private readonly ILogger<ColorTimerController> _logger;

        public ColorTimerController(IRepository repository, ILogger<ColorTimerController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpPost("create")]
        // POST : api/colortimer
        public void CreateColor(string color)
        {
            _repository.AddColor(color);
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