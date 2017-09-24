namespace _03BarracksFactory.Core.Factories
{
    using System;
    using Contracts;
    using Models.Units;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            string fullName = "_03BarracksFactory.Models.Units." + unitType;
            Type baseType = Type.GetType(fullName);
            var classInstance = (IUnit)Activator.CreateInstance(baseType);
            return classInstance;
        }
    }
}
