namespace _03GenericScale
{
    public class StartUp
    {
        public static void Main()
        {
            Scale<int> intArray = new Scale<int>(3,2);
            System.Console.WriteLine(intArray.GetHavier());
        }
    }
}
