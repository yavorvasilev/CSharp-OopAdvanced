namespace _08MilitaryElite
{
    using System;
    using System.Linq;
    using Interfaces;
    using Entities;
    using System.Collections.Generic;

    public class Startup
    {
        private static List<ISoldier> militaries = new List<ISoldier>();

        public static void Main()
        {
            string soldierInfo;

            while ((soldierInfo = Console.ReadLine()) != "End")
            {
                var soldierTokens = soldierInfo.Split().ToList();
                var soldierType = soldierTokens.FirstOrDefault();

                int id;
                string firstName;
                string lastName;
                double salary;
                string corps;

                switch (soldierType)
                {
                    case "Private":
                        id = int.Parse(soldierTokens[1]);
                        firstName = soldierTokens[2];
                        lastName = soldierTokens[3];
                        salary = double.Parse(soldierTokens[4]);
                        ISoldier privateSoldier = new Private(id, firstName, lastName, salary);
                        militaries.Add(privateSoldier);
                        break;

                    case "LeutenantGeneral":
                        id = int.Parse(soldierTokens[1]);
                        firstName = soldierTokens[2];
                        lastName = soldierTokens[3];
                        salary = double.Parse(soldierTokens[4]);
                        ILeutenantGeneral leutenantGeneral = new LeutenantGeneral(id, firstName, lastName, salary);
                        var privatesIds = soldierTokens.Skip(5).ToList();
                        TakeSoldiersUnerCommand(leutenantGeneral, privatesIds);
                        militaries.Add(leutenantGeneral);
                        break;

                    case "Engineer":
                        id = int.Parse(soldierTokens[1]);
                        firstName = soldierTokens[2];
                        lastName = soldierTokens[3];
                        salary = double.Parse(soldierTokens[4]);
                        corps = soldierTokens[5];

                        if (corps == "Airforces" || corps == "Marines")
                        {
                            IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);
                            var repairs = soldierTokens.Skip(6).ToList();
                            TakeRepairs(engineer, repairs);
                            militaries.Add(engineer);
                        }
                        break;

                    case "Commando":
                        id = int.Parse(soldierTokens[1]);
                        firstName = soldierTokens[2];
                        lastName = soldierTokens[3];
                        salary = double.Parse(soldierTokens[4]);
                        corps = soldierTokens[5];

                        if (corps == "Airforces" || corps == "Marines")
                        {
                            ICommando commando = new Commando(id, firstName, lastName, salary, corps);
                            var missions = soldierTokens.Skip(6).ToList();
                            TakeMissions(commando, missions);
                            militaries.Add(commando);
                        }
                        break;

                    case "Spy":
                        id = int.Parse(soldierTokens[1]);
                        firstName = soldierTokens[2];
                        lastName = soldierTokens[3];
                        var codeNumber = int.Parse(soldierTokens[4]);
                        ISoldier spy = new Spy(id, firstName, lastName, codeNumber);
                        militaries.Add(spy);
                        break;

                    default:
                        break;
                }
            }

            foreach (var soldier in militaries)
            {
                Console.WriteLine(soldier);
            }
           
        }

        private static void TakeMissions(ICommando commando, List<string> missions)
        {
            for (int i = 0; i < missions.Count; i += 2)
            {
                var missionName = missions[i];
                var state = missions[i + 1];
                if (state == "inProgress" || state == "Finished")
                {
                    var mission = new Mission(missionName, state);
                    commando.Missions.Add(mission);
                }
            }
        }

        private static void TakeRepairs(IEngineer engineer, List<string> repairs)
        {
            for (int i = 0; i < repairs.Count; i += 2)
            {
                var part = repairs[i];
                var hours = int.Parse(repairs[i + 1]);
                var repair = new Repair(part, hours);
                engineer.Repairs.Add(repair);
            }
        }

        private static void TakeSoldiersUnerCommand(ILeutenantGeneral leutenantGeneral, List<string> privatesIds)
        {
            foreach (var privateId in privatesIds)
            {
                var id = int.Parse(privateId);
                var soldier = militaries.Where(s => s.Id == id && s.GetType().Name == "Private").FirstOrDefault();
                leutenantGeneral.Soldiers.Add(soldier);
            }
        }
    }
}
