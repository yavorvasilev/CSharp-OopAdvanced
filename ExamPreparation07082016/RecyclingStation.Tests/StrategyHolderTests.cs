namespace RecyclingStation.Tests
{
    using BusinessLayer.Attributes;
    using BusinessLayer.Strategies;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using WasteDisposal;
    using WasteDisposal.Attributes;
    using WasteDisposal.Interfaces;

    [TestFixture]
    public class StrategyHolderTests
    {
        [Test]
        public void TestPropertyForReadOnlyCollection()
        {
            //Arrange
            IGarbageDisposalStrategy ds = new BurnableGarbageDisposalStrategy();
            Type disType = typeof(DisposableAttribute);
            IDictionary<Type, IGarbageDisposalStrategy> strategies = new Dictionary<Type, IGarbageDisposalStrategy>();
            IStrategyHolder sut = new StrategyHolder(strategies);

            //Act
            Type type = sut.GetDisposalStrategies.GetType();

            //Assert
            var test = type.GetInterfaces();
            Assert.IsTrue(type.GetInterfaces().Contains(typeof(System.Collections.Generic.IReadOnlyCollection<>)));
        }

        [Test]
        public void AddingStrategy()
        {
            //Arrange
            IGarbageDisposalStrategy ds = new BurnableGarbageDisposalStrategy();
            Type disType = typeof(DisposableAttribute);
            IDictionary<Type, IGarbageDisposalStrategy> strategies = new Dictionary<Type, IGarbageDisposalStrategy>();
            IStrategyHolder sut = new StrategyHolder(strategies);

            //Act
            bool type = sut.AddStrategy(disType, ds);

            //Assert
            Assert.IsTrue(type);
        }

        [Test]
        public void AddSameStrategies()
        {
            //Arrange
            IGarbageDisposalStrategy ds = new BurnableGarbageDisposalStrategy();
            Type disType = typeof(DisposableAttribute);
            IDictionary<Type, IGarbageDisposalStrategy> strategies = new Dictionary<Type, IGarbageDisposalStrategy>();
            IStrategyHolder sut = new StrategyHolder(strategies);

            //Act
            bool reult = sut.AddStrategy(disType, ds);
            bool reult1 = sut.AddStrategy(disType, ds);
            bool reult2 = sut.AddStrategy(disType, ds);

            //Assert
            Assert.AreEqual(1, sut.GetDisposalStrategies.Count);
        }

        [Test]
        public void RemoveStrategies()
        {
            //Arrange
            IGarbageDisposalStrategy ds = new BurnableGarbageDisposalStrategy();
            Type disType = typeof(DisposableAttribute);
            IDictionary<Type, IGarbageDisposalStrategy> strategies = new Dictionary<Type, IGarbageDisposalStrategy>();
            IStrategyHolder sut = new StrategyHolder(strategies);

            //Act
            bool reult2 = sut.AddStrategy(disType, ds);

            //Assert
            Assert.IsTrue(sut.RemoveStrategy(disType));
        }

        [Test]
        public void RemoveStrategiesAndCheckCount()
        {
            //Arrange
            IGarbageDisposalStrategy ds = new BurnableGarbageDisposalStrategy();
            Type disType = typeof(DisposableAttribute);
            IDictionary<Type, IGarbageDisposalStrategy> strategies = new Dictionary<Type, IGarbageDisposalStrategy>();
            IStrategyHolder sut = new StrategyHolder(strategies);

            //Act
            bool reult = sut.AddStrategy(disType, ds);
            bool reult1 = sut.AddStrategy(disType, ds);
            bool reult2 = sut.AddStrategy(disType, ds);

            bool removeResult = sut.RemoveStrategy(disType);

            //Assert
            Assert.AreEqual(0, sut.GetDisposalStrategies.Count);
        }

        [Test]
        public void AddDifferentStrategiesAndCheckCount()
        {
            //Arrange
            IGarbageDisposalStrategy ds = new BurnableGarbageDisposalStrategy();
            Type disType = typeof(StorableStrategyAttribute);
            Type disType1 = typeof(BurnableStrategyAttribute);
            Type disType2 = typeof(RecyclableStrategyAttribute);
            IDictionary<Type, IGarbageDisposalStrategy> strategies = new Dictionary<Type, IGarbageDisposalStrategy>();
            IStrategyHolder sut = new StrategyHolder(strategies);

            //Act
            bool reult = sut.AddStrategy(disType, ds);
            bool reult1 = sut.AddStrategy(disType1, ds);
            bool reult2 = sut.AddStrategy(disType2, ds);
            

            //Assert
            Assert.AreEqual(3, sut.GetDisposalStrategies.Count);
        }
    }
}
