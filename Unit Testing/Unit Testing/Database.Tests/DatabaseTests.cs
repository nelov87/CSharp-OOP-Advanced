namespace Database.Tests
{
    using NUnit.Framework;
    using DatabaseExample;
    using System;
    using System.Reflection;
    using System.Linq;

    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        public void EmptyConstructorShoulInitialiezedData()
        {
            Database db = new Database();

            Type type = typeof(Database);

            var field = (int[])type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).First(f => f.Name == "data").GetValue(db);
            var actualLength = field.Length;
            int expectedLength = 16;

            Assert.That(actualLength, Is.EqualTo(expectedLength), "neshto");

        }

        [Test]
        public void EmptyConstructorShoulInitialiezedIndexToMinusOne()
        {
            Database db = new Database();



        }

        [Test]
        public void ConstructorShoulThrowInvOperExeptionWithLargerArray()
        {
            int[] arr = new int[17];

            Assert.Throws<InvalidOperationException>(() => new Database(arr));
        }

        [Test]
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void ConstructorShoulSetIndexCorrectly(int[] values)
        {
            Database db = new Database(values);

            Type type = typeof(Database);

            var indexValue = (int)type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).First(f => f.Name == "index").GetValue(db);

            int expextedValue = values.Length - 1;

            Assert.That(indexValue, Is.EqualTo(expextedValue));
        }

        [Test]
        [TestCase(new int[] {1})]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 })]
        public void AddShoulIncreaseIndexCorectly(int[] values)
        {
            Database db = new Database(values);

            Type type = typeof(Database);

            db.Add(16);

            var indexValue = (int)type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).First(f => f.Name == "index").GetValue(db);
            
            int expectedLength = values.Length;

            Assert.That(indexValue, Is.EqualTo(expectedLength));

        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void ShoulThrowInvalidOperationExeptionWhenDBIsFull(int[] values)
        {
            Database db = new Database(values);
            
            Assert.Throws<InvalidOperationException>(() => db.Add(16));
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void ShoulSetIndexCorectlyWhenRemovingItems(int[] values)
        {
            Database db = new Database(values);

            Type type = typeof(Database);

            db.Remove();

            var indexValue = (int)type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).First(f => f.Name == "index").GetValue(db);

            int expectedLength = values.Length - 2;

            Assert.That(indexValue, Is.EqualTo(expectedLength));
        }

        [Test]
        [TestCase(new int[] {})]
        public void ShoulThrowInvalidOperationExeptionWhenRemovingAndDBIsFull(int[] values)
        {
            Database db = new Database(values);
            
            Assert.Throws<InvalidOperationException>(() => db.Remove());
        }

    }
}
