﻿namespace _08MilitaryElite.Entities
{
    using System;
    using Interfaces;

    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(int id, string firstName, string lastName, double salary, string corps) 
            : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }

        public string Corps { get; }
    }
}
