namespace Database.Tests
{
    using Newtonsoft.Json.Linq;
    using NUnit.Framework;
    using NUnit.Framework.Interfaces;
    using static System.Net.Mime.MediaTypeNames;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        public void TestConstructor()
        {
            var db = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
                                                 11, 12, 13, 14, 15, 16);
            Assert.AreEqual(16, db.Count);
        }
        [Test]
        public void TestConstructorWithMoreThan16Elements()
        {
            Assert.Throws<InvalidOperationException>(() => new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
                                                                11, 12, 13, 14, 15, 16, 17));
        }
        [Test]
        public void TestConstructorWithLessThan16Elements2()
        {
            var db = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
                                                                                                                             11, 12, 13, 14, 15);
            Assert.AreEqual(15, db.Count);
        }
       
        [Test]
        public void TestAddMethodWithLessThan16Elements()
        {
            var db = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
                                                                                                              11, 12, 13, 14, 15);
            db.Add(16);
            Assert.AreEqual(16, db.Count);
        }
        [Test]
        public void TestAddMethodWithMoreThan16Elements()
        {
            var db = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
                                                                               11, 12, 13, 14, 15, 16);
            Assert.Throws<InvalidOperationException>(() => db.Add(17));
        }
        [Test]
        public void TestRemoveMethod()
        {
            var db = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
                                                                                              11, 12, 13, 14, 15, 16);
            db.Remove();
            Assert.AreEqual(15, db.Count);
        }
        [Test]
        public void TestRemoveMethodWithLessThan1Elements()
        {
            var db = new Database(1);
            db.Remove();
            Assert.AreEqual(0, db.Count);
        }
        
            [Test]
            public void TestFetchMethod()
        {
              var db = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
                                                                                                               11, 12, 13, 14, 15, 16);
            var result = db.Fetch();
            Assert.AreEqual(16, result.Length);

        }
        [Test]
        public void TestFetchMethodWithLessThan1Elements()
        {
            var db = new Database(1);
            var result = db.Fetch();
            Assert.AreEqual(1, result.Length);
        }
        [Test]
        public void TestFetchMethodWithMoreThan16Elements()
        {
            var db = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
                                                                                                                              11, 12, 13, 14, 15, 16);
            var result = db.Fetch();
            Assert.AreEqual(16, result.Length);
        }
        [Test]
        public void TestFetchMethodWithDifferentElements()
        {
            var db = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
                                                                                                                                             11, 12, 13, 14, 15, 16);
            var result = db.Fetch();
            Assert.AreEqual(new int[] { 1, 2, 3, 4, 5, 6, 7, 8,
                                                                                                                                         9, 10, 11, 12, 13, 14, 15, 16 }, result);
        }
        [Test]
        public void TestConstructorWithNoElements()
        {
            var db = new Database();
            Assert.AreEqual(0, db.Count);
        }
        //test remove method
      

        [Test]
        public void TestRemoveMethodIfDatabaseIsEmpty()
        {
            var db = new Database();
            Assert.Throws<InvalidOperationException>(() => db.Remove());
        }





    }
}
