namespace DatabaseExtended.Tests
{
    using global::ExtendedDatabaseTests;
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [Test]
        public void AddMethodShouldThrowExceptionWhenUserWithSameNameExists()
        {
            var db = new Database(new Person(1, "Pesho"));
            Assert.Throws<InvalidOperationException>(() => db.Add(new Person(2, "Pesho")));
        }
        [Test]
        public void AddMethodShouldThrowExceptionWhenUserWithSameIdExists()
        {
            var db = new Database(new Person(1, "Pesho"));
            Assert.Throws<InvalidOperationException>(() => db.Add(new Person(1, "Gosho")));
        }
        [Test]
        public void RemoveMethodShouldRemoveUser()
        {
            var db = new Database(new Person(1, "Pesho"));
            db.Remove();
            Assert.AreEqual(0, db.Count);
        }
        [Test]
        public void RemoveMethodShouldThrowExceptionWhenDatabaseIsEmpty()
        {
            var db = new Database();
            Assert.Throws<InvalidOperationException>(() => db.Remove());
        }
        [Test]
        public void FindByUsernameMethodShouldThrowExceptionWhenUsernameIsNull()
        {
            var db = new Database(new Person(1, "Pesho"));
            Assert.Throws<ArgumentNullException>(() => db.FindByUsername(null));
        }
        [Test]
        public void FindByUsernameMethodShouldThrowExceptionWhenUserWithUsernameDoesNotExist()
        {
            var db = new Database(new Person(1, "Pesho"));
            Assert.Throws<InvalidOperationException>(() => db.FindByUsername("Gosho"));
        }
        [Test]
        public void FindByUsernameMethodShouldReturnUserWithGivenUsername()
        {
            var db = new Database(new Person(1, "Pesho"));
            var user = db.FindByUsername("Pesho");
            Assert.AreEqual("Pesho", user.UserName);
        }
        [Test]
        public void FindByIdMethodShouldThrowExceptionWhenIdIsNegative()
        {
            var db = new Database(new Person(1, "Pesho"));
            Assert.Throws<ArgumentOutOfRangeException>(() => db.FindById(-1));
        }
        [Test]
        public void FindByIdMethodShouldThrowExceptionWhenUserWithIdDoesNotExist()
        {
            var db = new Database(new Person(1, "Pesho"));
            Assert.Throws<InvalidOperationException>(() => db.FindById(2));
        }
        [Test]
        public void FindByIdMethodShouldReturnUserWithGivenId()
        {
            var db = new Database(new Person(1, "Pesho"));
            var user = db.FindById(1);
            Assert.AreEqual(1, user.Id);
        }
        [Test]
        public void CtorShouldThrowExceptionWhenCapacityIsExceeded()
        {
            var persons = new Person[17];
            Assert.Throws<ArgumentException>(() => new Database(persons));
        }
        [Test]
        public void CtorShouldAddRangeOfPersons()
        {
            var persons = new Person[3]
            {
                new Person(1, "Pesho"),
                new Person(2, "Gosho"),
                new Person(3, "Stamat")
            };
            var db = new Database(persons);
            Assert.AreEqual(3, db.Count);
        }
    
  

        [Test]
        public void AddRangeMethodShouldThrowExceptionWhenUserWithSameNameExists()
        {
            var persons = new Person[3]
            {
                new Person(1, "Pesho"),
                new Person(2, "Gosho"),
                new Person(3, "Stamat")
            };
            var db = new Database(persons);
            Assert.Throws<InvalidOperationException>(() => db.Add(new Person(4, "Pesho")));
        }
        [Test]
        public void AddRangeMethodShouldAddRangeOfPersons()
        {
            var persons = new Person[3]
            {
                new Person(1, "Pesho"),
                new Person(2, "Gosho"),
                new Person(3, "Stamat")
            };
            var db = new Database(persons);
            db.Add(new Person(4, "Ivan"));
            Assert.AreEqual(4, db.Count);
        }

        [Test]
        public void AddMethodShouldAddUser()
        {
            var db = new Database();
            db.Add(new Person(1, "Pesho"));
            Assert.AreEqual(1, db.Count);
        }
        [Test]
        public void CtorShouldAddPerson()
        {
            var db = new Database(new Person(1, "Pesho"));
            Assert.AreEqual(1, db.Count);
        }
        

    }
}