namespace _03CreateAttribute
{
    [SoftUni("Ventsi")]
    public class Startup
    {
        [SoftUni("Gosho")]
        public static void Main(string[] args)
        {
            var tracker = new Tracker();
            tracker.PrintMethodsByAuthor();

        }
    }
}
