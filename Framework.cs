using System;
using System.Collections.Generic;
using System.IO;

namespace Binary_Serialization
{
	public abstract class Framework
	{
		private const string FileName = "binary_data";
		
		protected static void Init()
		{
			if(File.Exists(FileName)) { File.Delete(FileName);}
			
			using (File.Open(FileName, FileMode.Create));
		}

		protected static void SaveData(string input)
		{
			using var stream = File.Open(FileName, FileMode.Append);
			
			using var writer = new BinaryWriter(stream, System.Text.Encoding.UTF8, false);
			
			foreach (int num in Encoding.Encode(input))
			{
				writer.Write(num);
			}
		}
		
		protected static string[] LoadData()
		{
			List<string> output = new List<string>();
			
			if(!File.Exists(FileName))
			{
				Console.WriteLine("No saved data found!"); return output.ToArray();
			}

			using var stream = File.Open(FileName, FileMode.Open);
			
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
}