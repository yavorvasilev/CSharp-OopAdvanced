using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MissionControllerTests
{
    private MissionController stu;
    private IArmy army;
    private IWareHouse wareHouse;


    [SetUp]
    public void InitialSetup()
    {
        this.army = new Army();
        this.wareHouse = new WareHouse();
        this.stu = new MissionController(this.army, this.wareHouse);
    }

    [Test]
    public void TestFailedMissionCounter()
    {
        //Act
        this.stu.PerformMission(new Easy(10));

        //Assert
        Assert.AreEqual(0, stu.FailedMissionCounter);
    }

    [Test]
    public void TestFailMissionCounterIfQueueOfMissionHaveMoreMissionThanThree()
    {
        //Act
        this.stu.PerformMission(new Easy(10));
        this.stu.PerformMission(new Easy(20));
        this.stu.PerformMission(new Easy(30));
        this.stu.PerformMission(new Easy(100));

        //Assert
        Assert.AreEqual(1, stu.FailedMissionCounter);
    }

    [Test]
    public void TestReturnStringIfAddedMissionInQueue()
    {
        //Assert
        Assert.AreEqual("Mission on hold - Suppression of civil rebellion\r\n", this.stu.PerformMission(new Easy(150)));
    }

    [Test]
    public void TestReturnStringIfAddedMoreThanThreeMissionInQueue()
    {
        //Act
        this.stu.PerformMission(new Hard(10));
        this.stu.PerformMission(new Hard(20));
        this.stu.PerformMission(new Hard(30));

        //Assert
        Assert.AreEqual("Mission declined - Disposal of terrorists\r\nMission on hold - Disposal of terrorists\r\nMission on hold - Disposal of terrorists\r\nMission on hold - Disposal of terrorists\r\n", this.stu.PerformMission(new Hard(150)));
    }

    [Test]
    public void TestSuccessMissionCounter()
    {
        //Arrange
        //IWareHouse wareHouse = new WareHouse();
        //IArmy army = new Army();
        ISoldierFactory soldierFactory = new SoldierFactory();

        //Act
        this.wareHouse.AddAmmunitions("AutomaticMachine", 4);
        this.wareHouse.AddAmmunitions("Gun", 6);
        this.wareHouse.AddAmmunitions("Helmet", 20);
        var soldier = soldierFactory.CreateSoldier("Ranker", "Ivan", 28, 55, 100);
        this.army.AddSoldier(soldier);
        
        this.stu.PerformMission(new Easy(1));

        //Assert
        Assert.AreEqual(1, this.stu.SuccessMissionCounter);
    }
}