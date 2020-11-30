using NUnit.Framework;
using BITS.Models;
using System.Collections.Generic;
using System.Linq;

namespace TestHomePage
{
    public class TestAppConfig
    {
        BITSContext context;
        AppConfig app;
        List<AppConfig> apps;
        [SetUp]
        public void Setup()
        {
            context = new BITSContext();
        }

        [Test]
        public void GetAllConfigs()
        {
            apps = context.AppConfig.OrderBy(a => a.BreweryId).ToList();
            Assert.AreEqual(apps.Count(), 2);
            Assert.AreEqual(apps[0].BreweryName, "Manifest");
        }

        [Test]
        public void GetByPrimaryKey()
        {
            app = context.AppConfig.Find(1);
            Assert.IsNotNull(app);
            Assert.AreEqual(app.BreweryName, "Manifest");
        }
        [Test]
        public void GetUsingWhere()
        {
            apps = context.AppConfig.Where(a => a.BreweryName.StartsWith("Manif")).OrderBy(a => a.BreweryId).ToList();
            Assert.AreEqual(apps[0].BreweryId, 1);
            Assert.AreEqual(apps.Count(), 1);
        }

        [Test]
        public void CreateTest()
        {
            app = new AppConfig();
            app.BreweryName = "new name";
            app.DefaultUnits = "metric";
            app.BreweryId = context.AppConfig.Count() + 1;

            context.AppConfig.Add(app);
            context.SaveChanges();
            Assert.IsNotNull(context.AppConfig.Find(2));
        }

        [Test]
        public void DeleteTest()
        {
            app = context.AppConfig.Find(3);
            context.AppConfig.Remove(app);
            context.SaveChanges();
            Assert.IsNull(context.AppConfig.Find(3));
        }

        [Test]
        public void UpdateTest()
        {

            app = context.AppConfig.Find(2);
            app.DefaultUnits = "imperial";

            app.HomePageText = "Update Update Update";
            context.AppConfig.Update(app);
            context.SaveChanges();
            Assert.AreEqual(context.AppConfig.Find(2).DefaultUnits, "imperial");

        }

    }
}