namespace Binary_Serialization
{
	public class Framework
	{
		public const string FileName = "binary_data";
		
		protected static void Init()
		{
			if(File.Exists(FileName)) { File.Delete(FileName);}

			using (File.Open(FileName, FileMode.Create))
			{
				Console.WriteLine("Binary data created.");
			}
		}
	}
}