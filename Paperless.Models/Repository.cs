using System.Collections.Generic;
using System.Linq;

namespace Paperless.Models
{
    public class Repository : IRepository
    {
        private readonly IList<ColorTimer> _items;
        private readonly TemporaryStorage database;

        public Repository()
        {
            database = new TemporaryStorage();
            _items = database.ReadFromFile().ToList();
            //_items = new Dictionary<string, ColorTimer>();
        }

        public void AddColor(string color, string hexCode)
        {
            if (!_items.Select(i => i.Color).Contains(color))
            {
                ColorTimer colorTimer = new ColorTimer(color, hexCode);
                _items.Add(colorTimer);
                database.WriteToFile(ColorTimers);
            }
        }

        // Fake method to simulate updating to database.
        public void UpdateFile()
        {
            database.WriteToFile(ColorTimers);
        }

        public IEnumerable<ColorTimer> ColorTimers
        {
            get { return _items; }
        }

        ~Repository()
        {
            database.WriteToFile(ColorTimers);
        }
    }
}
