namespace _03Ferrari
{
    public interface ICar
    {
        string Model { get;}
        string Driver { get; }
        string Start();
        string Stop();
    }
}
