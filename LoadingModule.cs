namespace Binary_Serialization;

public static class LoadingModule
{
    public static string[] LoadAllData()
    {
        List<string> output = new List<string>();
			
        if(!File.Exists(Framework.FileName))
        {
            Console.WriteLine("No saved data found!"); return output.ToArray();
        }

        using var stream = File.Open(Framework.FileName, FileMode.Open);
			
        using var reader = new BinaryReader(stream, System.Text.Encoding.UTF8, false);
			
        while (reader.BaseStream.Position != reader.BaseStream.Length)
        {
            int offset = reader.ReadInt32();
            int length = offset - reader.ReadInt32();
            string data = ""; 
					
            for (int i = 0; i < length; i++)
            {
                data += (char)(offset - reader.ReadInt32());
            }
				
            output.Add(data);
        }

        return output.ToArray();
    }
}