using System.Text;

namespace Binary_Serialization
{
	internal class Initialize
	{
		private const string FileName = "binary_data";
		
		private static void Main(string[] args)
		{
			Save();
			
			Load();
		}

		private static void Save()
		{			
			using (File.Open(FileName, FileMode.Create));

			SaveData("Lorem ipsum dolor sit amet,");
			SaveData("consectetur adipiscing elit.");
			SaveData("Etiam nec metus quis eros vulputate aliquam!!");
			SaveData("15.40 29-11-25");
		}

		private static void SaveData(string input)
		{
			using (var stream = File.Open(FileName, FileMode.Append))
			{
				using (var writer = new BinaryWriter(stream, Encoding.UTF8, false))
				{
					foreach (int num in Coding.Encode(input))
					{
						writer.Write(num);
					}
				}
			}
		}
		
		private static void Load()
		{
			if(!File.Exists(FileName))
			{
				Console.WriteLine("No saved data found!"); return;
			}
			
			using (var stream = File.Open(FileName, FileMode.Open))
			{
				using (var reader = new BinaryReader(stream, Encoding.UTF8, false))
				{
					while (reader.BaseStream.Position != reader.BaseStream.Length)
					{
						int offset = reader.ReadInt32();
						int length = offset - reader.ReadInt32();
						string data = ""; 
					
						for (int i = 0; i < length; i++)
						{
							data += (char)(offset - reader.ReadInt32());
						}

						Console.WriteLine(data);
					}
				}
			}
		}
	}
}