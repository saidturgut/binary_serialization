using System;

namespace Binary_Serialization;

public abstract class Example : Framework
{
    private static void Main()
    {
        Init();
        
        // SAVE
        
        SaveData("Lorem ipsum dolor sit amet,");
        SaveData("consectetur adipiscing elit.");
        SaveData("15.40 29-11-25");

        // LOAD
        
        foreach (string data in LoadData())
        {
            Console.WriteLine(data);
        }
    }
}