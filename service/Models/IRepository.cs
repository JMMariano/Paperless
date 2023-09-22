using System.Collections;
using System.Collections.Generic;

// TODO : Temporary storage for initial testings
namespace service.Models
{
    public interface IRepository
    {
        IEnumerable<ColorTimer> ColorTimers { get; }
        ColorTimer? this[string color] { get; }
        void AddColor(string color);
        //ColorTimer UpsertDescription(int index, string description);
        void DeleteColor(string color);
    }
}
