namespace Binary_Serialization;

public abstract class Example : Framework
{
    private static void Main()
    {
        Init();
        
        // SAVE

        SavingModule.SaveData(["a", "b", "c"]);
        SavingModule.SaveData("Lorem ipsum dolor sit amet,");
        SavingModule.SaveData("consectetur adipiscing elit.");
        SavingModule.SaveData("15.40 29-11-25");

        // LOAD
        
        foreach (string data in LoadingModule.LoadAllData())
        {
            Console.WriteLine(data);
        }
    }
}