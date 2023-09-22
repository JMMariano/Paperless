using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace service.Models
{
    public class ColorTimer
    {
        #region Properties
        public required string Color { get; set; }

        public double TotalTime { get; set; }
        public IList<ColorTimerDescription> Descriptions { get; set; }

        #endregion

        #region Constructors

        [SetsRequiredMembers]
        public ColorTimer(string color)
        {
            Color = color;
            TotalTime = 0;
            Descriptions = new List<ColorTimerDescription>();
        }

        #endregion

    }

    // TODO: Figure out getters and setters, if needed
    public class ColorTimerDescription
    {
        #region Properties
        public string? Description { get; set; }

        public float? Time { get; set; }

        #endregion

        #region Constructors

        public ColorTimerDescription(string description)
        {
            Description = description;
            Time = 0;
        }

        #endregion
    }
}