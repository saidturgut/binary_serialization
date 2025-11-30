namespace Binary_Serialization;

public static class Encoding
{
    public static int[] Encode(string input)
    {
        int offset = new Random().Next(256, 512);

        List<int> sector = [offset, offset - input.Length];
        
        foreach (char character in input)
        {
            sector.Add(sector[0] - character);
        }

        return sector.ToArray();
    }
}