using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Paperless.Data;
using Paperless.Models;

namespace Paperless.Controllers
{
    // TODO : Add exception handling
    // TODO : Add formal logging
    [ApiController]
    [Route("api/[controller]")]
    public class ColorTimerController : ControllerBase
    {
        #region Fields

        private ColorTimerContext _colorTimerContext;

        private readonly ILogger<ColorTimerController> _logger;

        #endregion

        #region Constructors

        public ColorTimerController(ColorTimerContext colorTimerContext)
        {
            _colorTimerContext = colorTimerContext;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Inserts a new color timer to the database and throws an error if the name already exists on the user's id
        /// </summary>
        /// <param name="name"></param>
        /// <param name="userId"></param>
        /// <param name="hexCode"></param>
        /// <returns></returns>
        [HttpPost("create/{name}")]
        public async Task CreateColor(string name, [FromBody] int userId, [FromQuery] string hexCode)
        {
            // Check if color already exists on the user's id.
            var res = await _colorTimerContext.ColorTimers
                .SingleOrDefaultAsync(i => string.Equals(i.Name, name) && i.UserId == userId);

            if (res ==  null)
            {
                var newColorTimer = new ColorTimer(name, hexCode, userId);
                // TODO: Get result first before saving
                await _colorTimerContext.AddAsync(newColorTimer);
                await _colorTimerContext.SaveChangesAsync();
            }
            else
            {
                //Return an error and log details when the name already exists.
            }
        }

        // TODO: Add LastTimeSynced as a query parameter
        // TODO: Do not use FromBody for user id
        // TODO: Change return type to also return the Color Timer
        /// <summary>
        /// Sets the IsRunning property to <see langword="true"/> for the ColorTimer based on the name and current user's id.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPost("start-timer/{name}")]
        public async Task StartTimer(string name, [FromBody] int userId)
        {
            var res = await _colorTimerContext.ColorTimers
                .SingleOrDefaultAsync(i => string.Equals(i.Name, name) && i.UserId == userId);

            if (res == null)
            {
                return;
            }

            res.IsRunning = true;
            _colorTimerContext.Update(res);
            // TODO: Get result after saving and log any errors that occured
            await _colorTimerContext.SaveChangesAsync();
        }

        // TODO: Add LastTimeSynced as a query parameter
        // TODO: Do not use FromBody for user id
        // TODO: Change return type to also return the Color Timer
        /// <summary>
        /// Sets the IsRunning property to <see langword="false"/> and adds the time elapsed from the client timer to the current Color Timer based on the name and current user's id.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="userId"></param>
        /// <param name="timeElapsed"></param>
        /// <returns></returns>
        [HttpPost("stop-timer/{name}")]
        public async Task StopTimer(string name, [FromBody] int userId, [FromQuery] int timeElapsed)
        {
            var res = await _colorTimerContext.ColorTimers
                .SingleOrDefaultAsync(i => string.Equals(i.Name, name) && i.UserId == userId);

            if (res == null)
            {
                return;
            }

            res.IsRunning = false;
            // TODO: Fix TotalTimeElapsed computation by referencing the last time synced (i.e. check if the LastTimeSynced from client and server match)
            res.TotalTimeElapsed += timeElapsed;
            _colorTimerContext.Update(res);
            // TODO: Get result after saving and log any errors that occured
            await _colorTimerContext.SaveChangesAsync();
        }

        /// <summary>
        /// Returns all color timers of the current user.
        /// </summary>
        /// <returns></returns>
        [HttpGet("getAllColorsTimers")]
        public async Task<IList<ColorTimer>> GetAllColorTimers()
        {
            var result = await _colorTimerContext.ColorTimers.ToListAsync();
            return result;
        }

        #endregion
    }
}