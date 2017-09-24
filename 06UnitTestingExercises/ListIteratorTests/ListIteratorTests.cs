namespace ListIteratorTests
{
    using _03Iterator;
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class ListIteratorTests
    {
        private ListIterator listIterator;

        [SetUp]
        public void TestInitialize()
        {
            //Arrange
            this.listIterator = new ListIterator();
        }

        [Test]
        public void ConstructorShouldeInitializeCollectionWithGicenNonEmptyCollecition()
        {
            //Act
            var strings = new List<string>() { "Pesho" };
            this.listIterator = new ListIterator(strings);

            //Assert
            CollectionAssert.AreEqual(strings, this.listIterator.Collection, "Collections are not equal!");
        }
    }
}
