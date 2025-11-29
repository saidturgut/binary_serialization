using System;
using System.Collections.Generic;

namespace Binary_Serialization;

public static class Encoding
{
    public static int[] Encode(string input)
    {
        List<int> sector = new List<int>();

        sector.Add(new Random().Next(256, 512));
        
        sector.Add(sector[0] - input.Length);
        
        foreach (char character in input)
        {
            sector.Add(sector[0] - character);
        }

        return sector.ToArray();
    }
}