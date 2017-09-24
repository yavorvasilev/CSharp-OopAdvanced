using System;

namespace _03Ferrari
{
    public class Ferrari : ICar
    {
        public Ferrari(string driver)
        {
            this.Driver = driver;
            this.Model = "488-Spider";
        }

        public string Driver{get;}

        public string Model{get;}

        public string Start()
        {
            return "Zadu6avam sA!";
        }

        public string Stop()
        {
            return "Brakes!";
        }

        public override string ToString()
        {
            return $"{this.Model}/{Stop()}/{Start()}/{this.Driver}";
        }
    }
}
