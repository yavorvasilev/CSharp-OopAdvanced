namespace _05BorderControl
{
    public interface IIdentifier : IBirthdate
    {
        string Id { get; }

        string GetId();
    }
}
