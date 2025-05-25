using Avalonia;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace PolygonsLIT;

[Serializable]
public class MyDataClass
{
    public string name;
    public int id;
    public Point MousePoint; 
    [NonSerialized] 
    public int age;
}

public class SaveMenu
{
    private MyDataClass _myDataObject = new MyDataClass();

    [Obsolete("Obsolete")]
    public void SaveState()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream("State.bin", FileMode.Create, FileAccess.Write))
            {
                bf.Serialize(fs, _myDataObject);
            }
            Console.WriteLine("State saved successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving state: {ex.Message}");
        }
    }

    [Obsolete("Obsolete")]
    public void LoadState()
    {
        try
        {
            if (File.Exists("State.bin"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                using (FileStream fs = new FileStream("State.bin", FileMode.Open, FileAccess.Read))
                {
                    _myDataObject = (MyDataClass)bf.Deserialize(fs); 
                }
                Console.WriteLine("State loaded successfully!");
            }
            else
            {
                Console.WriteLine("No saved state found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading state: {ex.Message}");
        }
    }
}
