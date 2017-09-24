namespace DatabaseTests
{
    using System;
    using _01Database;
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        private Database db;

        [SetUp]
        public void TestInitialize()
        {
            //Arange
            this.db = new Database(new int[] { 1, 2, 3, 4});
        }

        [Test]
        public void TestDatabaseCapacity()
        {
            //Assert
            Assert.AreEqual(16, this.db.Capacity, "Database capacity is not 16");
        }

        [Test]
        public void TestAddOnElement()
        {
            //Act
            this.db.Add(10);

            //Assert
            Assert.AreEqual(5, this.db.Count);
            Assert.AreEqual(10, this.db.Elements[4]);
        }

        [Test]
        public void TestAddSeveralElements()
        {
            //Act
            this.db.Add(16);
            this.db.Add(17);

            //Assert
            Assert.AreEqual(6, this.db.Count);
        }

        [Test]
        public void TestAddMoreElementsThanCapacity()
        {
            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                for (int i = 0; i < 20; i++)
                {
                    this.db.Add(i);
                }
            });
        }

        [Test]
        public void TestRemoveOneElement()
        {
            //Act
            this.db.Remove();

            //Assert
            Assert.AreEqual(3, this.db.Count);
        }

        [Test]
        public void TestRemoveSeveralElements()
        {
            //Act
            this.db.Remove();
            this.db.Remove();
            this.db.Remove();

            //Assert
            Assert.AreEqual(1, this.db.Count);
        }

        [Test]
        public void TestConstructorValidParameters()
        {
            //Arrange
            var numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8};
            db = new Database(numbers);

            //Assert
            Assert.AreEqual(numbers, this.db.Elements);
        }

        [Test]
        public void TestConstructorInvalidParametersShouldThrow()
        {
            //Assert
            Assert.Throws<InvalidOperationException>(() => new Database(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 1, 2, 3, 4, 5, 6, 7, 81, 2, 3, 4, 5,
                6, 7, 81, 2, 3, 4, 5, 6, 7, 81, 2, 3, 4, 5, 6, 7, 81, 2, 3, 4, 5, 6, 7, 8}));
        }

        [Test]
        public void TestConstructorDoesntAcceptNullObject()
        {
            //Assert
            Assert.Throws<ArgumentNullException>(() => new Database(null), "Database cannot be initialized with null");
        }
    }
}
