using System;
using System.Text;

public class Tesla : ICar, IElectricCar
{
    public Tesla(string model, string color, int batteries )
    {
        this.Model = model;
        this.Color = color;
        this.Batteries = batteries;
    }
    public int Batteries { get; private set; }
    public string Color { get; private set; }
    public string Model { get; private set; }
    public string Start()
    {
        return "Engine start";
    }

    public string Stop()
    {
        return "Breaaak!";
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"{this.Color} {GetType().Name} {this.Model} with {this.Batteries} Batteries");
        sb.AppendLine($"{Start()}");
        sb.AppendLine($"{Stop()}");

        return sb.ToString().Trim();
    }
}
