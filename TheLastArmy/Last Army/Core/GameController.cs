using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class GameController
{
    //private Dictionary<string, List<Soldier>> army;
    //private Dictionary<string, List<Ammunition>> wearHouse;
    private ISoldierFactory soldierFactory;
    private IAmmunitionFactory ammunitionFactory;
    private IMissionFactory missionFactory;
    private IArmy army;
    private IWareHouse wareHouse;
    private IWriter writer;
    private MissionController missionControllerField;

    public GameController(IArmy army, IWareHouse wareHouse, ISoldierFactory soldierFactory, IAmmunitionFactory ammunitionFactory, IMissionFactory missionFactory, IWriter writer)
    {
        this.army = army;
        this.wareHouse = wareHouse;
        this.soldierFactory = soldierFactory;
        this.ammunitionFactory = ammunitionFactory;
        this.missionFactory = missionFactory;
        this.MissionControllerField = new MissionController(this.army, this.wareHouse);
        this.writer = writer;
    }

    //public IArmy Army { get; set; }
    //public IWareHouse WareHouse { get; set; }

    //public Dictionary<string, List<Soldier>> Army
    //{
    //    get { return army; }
    //    set { army = value; }
    //}

    //public Dictionary<string, List<Ammunition>> WearHouse
    //{
    //    get { return wearHouse; }
    //    set { wearHouse = value; }
    //}

    public MissionController MissionControllerField
    {
        get { return missionControllerField; }
        set { missionControllerField = value; }
    }

    public void GiveInputToGameController(string input)
    {
        var data = input.Split().First();
        //var regenerate = input.Split()[1];

        if (data == "Soldier")
        {
            var inputTokens = input.Split();
            if (input.Contains("Regenerate"))
            {
                inputTokens = input.Split();
                var typeOfSoldier = inputTokens[2];
                this.army.RegenerateTeam(typeOfSoldier);
            }
            else
            {
                var type = inputTokens[1];
                var soldierName = inputTokens[2];
                var age = int.Parse(inputTokens[3]);
                var experience = double.Parse(inputTokens[4]);
                var endurance = double.Parse(inputTokens[5]);

                ISoldier soldier = soldierFactory.CreateSoldier(type, soldierName, age, experience, endurance);

                if (this.wareHouse.TryEquipSoldier(soldier))
                {
                    this.army.AddSoldier(soldier);
                }
                else
                {
                    throw new ArgumentException(string.Format(OutputMessages.NoWeaponsForSoldierType, type, soldierName));
                }
            }
        }
        else if (data == "WareHouse")
        {
            var inputTokens = input.Split();
            var name = inputTokens[1];
            var number = int.Parse(inputTokens[2]);
            //IAmmunition amunition = ammunitionFactory.CreateAmmunition(name);
            this.wareHouse.AddAmmunitions(name, number);
            //AddAmmunitions(ammunition);

        }
        else if (data == "Mission")
        {
            var inputTokens = input.Split();
            var typeOfMission = inputTokens[1];
            var neededPoints = double.Parse(inputTokens[2]);
            var mission = missionFactory.CreateMission(typeOfMission, neededPoints);
            this.writer.WriteLine(this.MissionControllerField.PerformMission(mission).Trim());
        }
        //else if (regenerate == "Regenerate")
        //{
        //    var inputTokens = input.Split();
        //    var typeOfSoldier = inputTokens[2];
        //    this.army.RegenerateTeam(typeOfSoldier);
        //}
    }

    public string RequestResult()
    {
        var sb = new StringBuilder();
        MissionControllerField.FailMissionsOnHold();
        sb.AppendLine($"Results:");
        sb.AppendLine($"Successful missions - {this.MissionControllerField.SuccessMissionCounter}");
        sb.AppendLine($"Failed missions - {this.MissionControllerField.FailedMissionCounter}");

        sb.AppendLine($"Soldiers:");
        foreach (var soldier in this.army.Soldiers.OrderByDescending(s => s.OverallSkill))
        {
            sb.AppendLine(soldier.ToString());
        }

        return sb.ToString().Trim();
        //return Output.GiveOutput(result, army, wearHouse, this.MissionControllerField.MissionQueue.Count);
    }

    //private void AddAmmunitions(IAmmunition ammunition)
    //{
    //    if (!this.wareHouse.ContainsKey(ammunition.Name))
    //    {
    //        this.WearHouse[ammunition.Name] = new List<Ammunition>();
    //        this.WearHouse[ammunition.Name].Add(ammunition);
    //    }
    //    else
    //    {
    //        this.WearHouse[ammunition.Name][0].Number += ammunition.Number;
    //    }
    //}

    //private void AddSoldierToArmy(Soldier soldier, string type)
    //{
    //    if (!soldier.CheckIfSoldierCanJoinTeam())
    //    {
    //        throw new ArgumentException($"The soldier {soldier.Name} is not skillful enough {type} team");
    //    }

    //    if (!this.Army.ContainsKey(type))
    //    {
    //        this.Army[type] = new List<Soldier>();
    //    }
    //    this.Army[type].Add(soldier);
    //}
}