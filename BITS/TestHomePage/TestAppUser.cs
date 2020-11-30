using NUnit.Framework;
using BITS.Models;
using System.Collections.Generic;
using System.Linq;

namespace TestHomePage
{
    class TestAppUser
    {
        BITSContext context;
        AppUser u;
        List<AppUser> users;
        [SetUp]
        public void Setup()
        {
            context = new BITSContext();
        }

        [Test]
        public void CreateTest()
        {
            u = new AppUser();
            u.Name = "admin";
            u.AppUserId = context.AppUser.Count() + 1;

            context.AppUser.Add(u);
            context.SaveChanges();
            Assert.IsNotNull(context.AppUser.Find(2));
        }

        [Test]
        public void GetAllUsers()
        {
            users = context.AppUser.OrderBy(a => a.AppUserId).ToList();
            Assert.AreEqual(users.Count(), 2);
            Assert.AreEqual(users[1].Name, "admin");
        }

        [Test]
        public void GetByPrimaryKey()
        {
            u = context.AppUser.Find(1);
            Assert.IsNotNull(u);
            Assert.AreEqual(u.Name, "new name");
        }
        [Test]
        public void GetUsingWhere()
        {
            users = context.AppUser.Where(a => a.Name.StartsWith("ne")).OrderBy(a => a.AppUserId).ToList();
            Assert.AreEqual(users[0].AppUserId, 1);
            Assert.AreEqual(users.Count(), 1);
        }

        [Test]
        public void DeleteTest()
        {
            u = context.AppUser.Find(2);
            context.AppUser.Remove(u);
            context.SaveChanges();
            Assert.IsNull(context.AppUser.Find(2));
        }

        [Test]
        public void UpdateTest()
        {

            u = context.AppUser.Find(1);
            u.Name = "updatename";
            context.AppUser.Update(u);
            context.SaveChanges();
            Assert.AreEqual(context.AppUser.Find(1).Name, "updatename");

        }

    }
}
