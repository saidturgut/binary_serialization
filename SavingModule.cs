namespace Binary_Serialization;

public static class SavingModule
{		
    public static void SaveData(string input)
    {	
        WriteData(input);
    }

    public static void SaveData(string[] input)
    {		        
        foreach (var element in input)
        {
            WriteData(element);
        }
    }
    
    private static void WriteData(string input)
    {			
        using var stream = File.Open(Framework.FileName, FileMode.Append);
        using var writer = new BinaryWriter(stream, System.Text.Encoding.UTF8, false);

        foreach (int num in Encoding.Encode(input))
        {
            writer.Write(num);
        }
    }
}