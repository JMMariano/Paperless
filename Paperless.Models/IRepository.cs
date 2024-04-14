using System.Collections;
using System.Collections.Generic;

// TODO : Temporary storage for initial testings
namespace Paperless.Models
{
    public interface IRepository
    {
        void AddColor(string color, string hexCode);
        //ColorTimer UpsertDescription(int index, string description);
        IEnumerable<ColorTimer> ColorTimers { get; }
        void UpdateFile();
    }
}
