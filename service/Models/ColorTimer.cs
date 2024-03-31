using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace service.Models
{
    // TODO: Figure out getters and setters, if needed
    public class ColorTimer
    {

        #region Properties
        public required string Color { get; set; }

        public double TotalTimeElapsed { get; set; }
        // public IList<ColorTimerDescription> Descriptions { get; set; }
        // private Stopwatch Timer { get; set; } = new Stopwatch();

        #endregion

        #region Constructors

        public ColorTimer() {}

        [SetsRequiredMembers]
        public ColorTimer(string color)
        {
            Color = color;
            TotalTimeElapsed = 0;
            // Descriptions = new List<ColorTimerDescription>();
        }

        #endregion

        #region Methods

        public void StartTimer()
        {
            // TODO: Do timer stuff
            // this.Timer.Start();
        }

        public void StopTimer()
        {
            // TODO: Do timer stuff
            // this.Timer.Stop();
            // double ts = Timer.Elapsed.TotalSeconds;
            // TotalTime += ts;
        }

        #endregion
    }

    // TODO: Figure out getters and setters, if needed
    public class ColorTimerDescription
    {
        #region Properties
        public string? Description { get; set; }

        public float? TimeElapsed { get; set; }

        #endregion

        #region Constructors

        public ColorTimerDescription(string description)
        {
            Description = description;
            TimeElapsed = 0;
        }

        #endregion
    }
}