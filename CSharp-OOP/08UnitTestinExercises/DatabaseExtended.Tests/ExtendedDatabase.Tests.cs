using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase.ExtendedDatabase extendedDb;

        [SetUp]
        public void Setup()
        {
            extendedDb = new ExtendedDatabase.ExtendedDatabase();
        }

        [Test]
        public void Ctor_AddInitialPeopleToDb()
        {
            Person[] people = new Person[5];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, $"Username:{i}");
            }

            extendedDb = new ExtendedDatabase.ExtendedDatabase(people);
            Assert.That(extendedDb.Count, Is.EqualTo(people.Length));
        }

        [Test]
        public void Ctor_ThrowsException_WhenCapacityIsExceeded()
        {
            Person[] people = new Person[17];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, $"Username:{i}");
            }

            Assert.Throws<ArgumentException>(() => extendedDb = new ExtendedDatabase.ExtendedDatabase(people));
        }

        [Test]
        public void Count_ReturnsZero_WhenDbIsEmpty()
        {
            int expectedCount = 0;

            Assert.That(extendedDb.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Add_ThrowsException_WhenCapacityIsExceeded()
        {
            Person[] people = new Person[16];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, $"Username:{i}");
            }

            extendedDb = new ExtendedDatabase.ExtendedDatabase(people);
            Assert.Throws<InvalidOperationException>(() => extendedDb.Add(new Person(17, "$Username:17")));
        }

        [Test]
        public void Add_ThrowsException_WhenUsernameExists()
        {
            string username = "Gosho";
            extendedDb.Add(new Person(2, username));

            Assert.Throws<InvalidOperationException>(() => extendedDb.Add(new Person(3, username)));
        }

        [Test]
        public void Add_ThrowsException_WhenIdExists()
        {
            int id = 1;
            extendedDb.Add(new Person(id, "Pesho"));
           
            Assert.Throws<InvalidOperationException>(() => extendedDb.Add(new Person(id, "Stoyan")));
        }

        [Test]
        public void Add_IncreasesCounter_WhenUserIsValid()
        {

            extendedDb.Add(new Person(1, "Pesho"));
            extendedDb.Add(new Person(2, "Gosho"));

            Assert.That(extendedDb.Count, Is.EqualTo(2));
        }

        [Test]
        public void Remove_ThrowsException_WhenEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => extendedDb.Remove());
        }

        [Test]
        public void Remove_RemovesElementFromDb()
        {
            extendedDb.Add(new Person(1, "Pesho"));
            extendedDb.Add(new Person(2, "Gosho"));

            extendedDb.Remove();
            int expectedCount = 1;

            Assert.That(extendedDb.Count, Is.EqualTo(expectedCount));
            Assert.Throws<InvalidOperationException>(() => extendedDb.FindById(2));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void FindByUsername_ThrowsException_WhenNullOrEmptyParamatererIsPassed(string username)
        {
            Assert.Throws<ArgumentNullException>(() => extendedDb.FindByUsername(username));
        }

        [Test]
        public void FindByUsername_ThrowsException_WhenUsernameDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => extendedDb.FindByUsername("Username"));
        }

        [Test]
        public void FindByUsername_ReturnsExpectedUser_WhenUSernameExists()
        {
            Person person = new Person(1, "Alex");

            extendedDb.Add(person);

            Person extendedDbPerson = extendedDb.FindByUsername("Alex");

            Assert.That(person, Is.EqualTo(extendedDbPerson));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-5)]
        public void FindById_ThrowsException_WhenIdLessThanZero(int id)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => extendedDb.FindById(id));
        }

        [Test]
        public void FindById_ThrowsException_WhenUserWithIdDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => extendedDb.FindById(2));
        }

        [Test]
        public void FindById_ReturnsExpectedUser_WhenUserExists()
        {
            Person person = new Person(1, "Alex");
            extendedDb.Add(person);
            Person extendedbPerson = extendedDb.FindById(1);

            Assert.That(person, Is.EqualTo(extendedbPerson));
        }
    }
}