using System.Diagnostics.CodeAnalysis;

namespace Paperless.Models
{
    // TODO: Figure out getters and setters, if needed
    public class ColorTimer : IEqualityComparer<ColorTimer>
    {

        #region Properties
        public string? Name { get; set; }

        public string? ColorHexCode { get; set; }

        public long TotalTimeElapsed { get; set; }

        public DateTime LastTimeSynced { get; set; }

        public bool IsRunning { get; set; }

        public int UserId { get; set; }

        #endregion

        #region Constructors

        public ColorTimer() {}

        public ColorTimer(string name, string hexCode, int userId)
        {
            Name = name;
            ColorHexCode = hexCode;
            TotalTimeElapsed = 0;
            LastTimeSynced = DateTime.Now;
            IsRunning = false;
            UserId = userId;
        }

        #endregion

        #region Methods

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

            return x.Name == y.Name;
        }

        public int GetHashCode([DisallowNull] ColorTimer obj)
        {
            if (obj == null)
            {
                return 0;
            }

            return obj.Name.GetHashCode();
        }

        #endregion
    }
}