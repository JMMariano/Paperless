using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Paperless.Models
{
    // TODO: Figure out getters and setters, if needed
    public class ColorTimer : IEqualityComparer<ColorTimer>
    {

        #region Properties
        // TODO: Rename to name
        public string Color { get; set; }

        public string ColorHexCode { get; set; }

        public int TotalTimeElapsed { get; set; }
        // public IList<ColorTimerDescription> Descriptions { get; set; }
        // private Stopwatch Timer { get; set; } = new Stopwatch();

        #endregion

        #region Constructors

        public ColorTimer() {}

        public ColorTimer(string color, string hexCode)
        {
            Color = color;
            ColorHexCode = hexCode;
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

        public bool Equals(ColorTimer? x, ColorTimer? y)
        {
            if (object.ReferenceEquals(x, y))
            {
                return true;
            }

            if (object.ReferenceEquals(x, null) ||
                object.ReferenceEquals(y, null))
            { 
                return false;
            }

            return x.Color == y.Color;
        }

        public int GetHashCode([DisallowNull] ColorTimer obj)
        {
            if (obj == null)
            {
                return 0;
            }

            return obj.Color.GetHashCode();
        }

        #endregion
    }

    // TODO: Figure out getters and setters, if needed
    public class ColorTimerDescription
    {
        #region Properties
        public string? Description { get; set; }

        public int? TimeElapsed { get; set; }

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