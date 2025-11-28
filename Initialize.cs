namespace Binary_Serialization
{
	internal class Initialize
	{
		private static readonly char[] Characters =
		{
			' ', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u',
			'v', 'w', 'x', 'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
		};
		
		private static void Main(string[] args)
		{
			foreach (string str in EncryptString("Hello 007"))
			{
				Console.Write(str + " ");
			}
		}

		public static string[] EncryptString(string input)
		{
			//complex aff
			
			input = input.ToLower();

			List<string> binary = new List<string>();
			
			int guide = new Random().Next(100, 127);

			binary.Add(Convert.ToString(guide, 2));

			binary.Add(Convert.ToString(guide - input.Length, 2));

			foreach (char character in input)
			{
				for (int j = 0; j < Characters.Length; j++)
				{
					if (character.Equals(Characters[j]))
					{
						binary.Add(Convert.ToString(guide - j, 2));
					}
				}
			}

			return binary.ToArray();
		}

		public static string DecryptString(string[] input)
		{
			
			
			return "ss";
		}
	}
}