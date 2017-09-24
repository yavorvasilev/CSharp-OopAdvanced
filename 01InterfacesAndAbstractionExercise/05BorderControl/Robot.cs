using System;

namespace _05BorderControl
{
    class Robot : IIdentifier
    {
        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }
        public string Model { get;}
        public string Id { get;}

        public string Birthdate
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string GetId()
        {
            return this.Id;
        }
    }
}
