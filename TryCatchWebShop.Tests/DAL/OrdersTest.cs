using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TryCatchWebShop;
using TryCatchWebShop.Controllers;
using TryCatchWebShop.DAL;
using System;
using System.Linq;

namespace TryCatchWebShop.Tests.DAL
{
    [TestClass]
    public class OrdersTest
    {
        [TestMethod]
        public void InsertOrder()
        {
            var inOrder = new Order()
            {
                Id = Guid.NewGuid(),
                Address = "addrezs",
                City = "riga",
                EMail = "adsf@adfs.com",
                FirstName = "maris",
                LastName = "also maris",
                HouseNumber = "666",
                Title = "Royal Highness",
                ZipCode = "1010"

            };

            using (WebShopContext db = new WebShopContext())
            {
                db.Orders.Add(inOrder);
                db.SaveChanges();
            }

            Order outOrder = null;
            using (WebShopContext db = new WebShopContext())
            {
                var all = db.Orders.ToList();
                outOrder = db.Orders.Single(o => o.Id == inOrder.Id);
            }

            Assert.IsNotNull(outOrder);
        
        }
    }
}
