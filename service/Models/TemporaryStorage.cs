using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using service.Models;

public class TemporaryStorage
{
    private readonly string _filePath = "temporary_storage.txt";

    public void WriteToFile(IEnumerable<ColorTimer> colorTimers)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(_filePath))
            {
                foreach (var colorTimer in colorTimers)
                {
                    writer.WriteLine($"{colorTimer.Color},{colorTimer.TotalTimeElapsed}");
                }
            }

            Console.WriteLine("Successfully wrote to file");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error writing to file");
        }
    }

    public IEnumerable<ColorTimer> ReadFromFile()
    {
        try
        {
            IList<ColorTimer> colorTimers = new List<ColorTimer>();

            if (!File.Exists(_filePath))
            {
                Console.WriteLine("File does not exist yet");
            }
            else
            {
                string[] data = File.ReadAllLines(_filePath);

                for (var i = 0; i < data.Length; i++)
                {
                    var timerProperties = data[i].Split(',');

                    var timer = new ColorTimer
                    {
                        Color = timerProperties[0],
                        TotalTimeElapsed = int.Parse(timerProperties[1])
                    };

                    colorTimers.Add(timer);
                }

                Console.WriteLine("Successfully read from file");
            }

            return colorTimers;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error reading from file");
            return Enumerable.Empty<ColorTimer>();
        }
    }
}