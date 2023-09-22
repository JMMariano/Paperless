using System.Collections.Generic;

namespace service.Models
{
    public class Repository : IRepository
    {
        private Dictionary<string, ColorTimer> _items;

        public Repository() 
        {
            _items = new Dictionary<string, ColorTimer>();
        }

        public ColorTimer? this[string color] => _items.ContainsKey(color) ? _items[color] : null;

        public IEnumerable<ColorTimer> ColorTimers => _items.Values;

        public void AddColor(string color)
        {
            if (!_items.ContainsKey(color)) 
            {
                ColorTimer colorTimer = new ColorTimer(color);
                _items[color] = colorTimer;
            }
        }

        public void DeleteColor(string color)
        {
            throw new System.NotImplementedException();
        }
    }
}
