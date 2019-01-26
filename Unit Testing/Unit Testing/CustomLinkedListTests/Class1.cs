using CustomLinkedList;
using NUnit.Framework;
using System;

namespace CustomLinkedListTests
{
    [TestFixture]
    public class LinkedListTests
    {
        private const int InitialCount = 0;
        [Test]
        public void ConstructorShouldSetCountToZero()
        {
            DynamicList<int> list = new DynamicList<int>();

            Assert.That(list.Count, Is.EqualTo(InitialCount));
        }

        [Test]
        public void IndexOperatorShouldReturnValue()
        {
            DynamicList<int> list = new DynamicList<int>();

            list.Add(11);

            int element = list[0];

            Assert.That(element, Is.EqualTo(11));
        }

        [Test]
        public void IndexOperatorShouldSetValue()
        {
            DynamicList<int> list = new DynamicList<int>();

            list.Add(11);

            list[0] = 46;

            Assert.That(list[0], Is.EqualTo(46));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(int.MaxValue)]
        [TestCase(100)]
        public void IndexOperatorShouldThrowExeption(int index)
        {
            DynamicList<int> list = new DynamicList<int>();

            for (int i = 0; i < 10; i++)
            {
                list.Add(i);

            }

            int returnValue = 0;
            Assert.Throws<ArgumentOutOfRangeException>(() => returnValue = list[index]);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(int.MaxValue)]
        [TestCase(100)]
        public void IndexOperatorShouldThrowExeptionWhenSetingInvalidIndex(int index)
        {
            DynamicList<int> list = new DynamicList<int>();

            for (int i = 0; i < 10; i++)
            {
                list.Add(i);

            }

            Assert.Throws<ArgumentOutOfRangeException>(() => list[index] = 69);
        }
    }
}
