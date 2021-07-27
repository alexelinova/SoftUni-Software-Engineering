using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        private Database.Database database;

        [SetUp]
        public void Setup()
        {
            database = new Database.Database();
        }

        [Test]
        public void Ctor_AddsValidItemsToDb()
        {
            int[] elements = new int[] { 1, 2, 3 };
            database = new Database.Database(elements);

            Assert.That(database.Count, Is.EqualTo(elements.Length));
        }

        [Test]
        public void Ctor_ThrowsException_WhenCapacityIsExceeded()
        {
            int[] data = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };

            Assert.Throws<InvalidOperationException>(() => database = new Database.Database(data));
        }

        [Test]
        public void Count_ReturnsZero_WhenDbIsEmpty()
        {
            int expected = 0;

            Assert.That(database.Count, Is.EqualTo(expected));
        }

        [Test]
        public void Add_IncrementCount_WhenAddIsValid()
        {
            int n = 5;
            for (int i = 0; i < n; i++)
            {
                database.Add(i);
            }

            Assert.That(database.Count, Is.EqualTo(n));
        }

        [Test]
        public void Add_ThrowsException_WhenCapacityIsExceeded()
        {
            int n = 16;

            for (int i = 0; i < n; i++)
            {
                database.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() => database.Add(17));
        }

        [Test]
        public void Remove_ThrowsException_WhenEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void Remove_DecreasesDbElements()
        {
            int n = 3;

            for (int i = 0; i < n; i++)
            {
                database.Add(i);
            }
            database.Remove();
            int expectedResultCount = 2;

            Assert.That(database.Count, Is.EqualTo(expectedResultCount));
        }

        [Test]
        public void Remove_RemovesLastElement()
        {
            int n = 3;
            int lastElement = 3;

            for (int i = 0; i < n; i++)
            {
                database.Add(i);
            }
            database.Remove();
            int[] copy = database.Fetch();

            Assert.IsFalse(copy.Contains(lastElement));
        }

        [Test]
        public void Fetch_ReturnsACopyOfDatabase()
        {
            int[] copy = database.Fetch();

            Assert.AreNotSame(copy, database);
        }
    }
}