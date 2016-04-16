using Microsoft.VisualStudio.TestTools.UnitTesting;
using TryCatchWebShop.DAL;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System;

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
                Address = "addrezs",
                City = "riga",
                Email = "hey@maris.com",
                FirstName = "maris",
                LastName = "also maris",
                HouseNumber = "666",
                Title = "MR",
                ZipCode = "1010",
            };

            inOrder.Products = new List<Product>()
            {
                new Product()
                {
                    Count = 10,
                    Id = "MD5something",
                    Name = "Test product",
                    Price = 99m
                }
            };


            using (WebShopContext db = new WebShopContext())
            {
                db.Orders.Add(inOrder);
                db.SaveChanges();
            }


            Order outOrder = null;
            using (WebShopContext db = new WebShopContext())
            {
                outOrder = db.Orders
                    .Include("Products")
                    .Single(o => o.Id == inOrder.Id);
            }

            Assert.IsNotNull(outOrder);
            Assert.AreEqual(inOrder.Id, outOrder.Id);
            Assert.AreEqual(inOrder.Title, outOrder.Title);
            Assert.AreEqual(inOrder.FirstName, outOrder.FirstName);
            Assert.AreEqual(inOrder.LastName, outOrder.LastName);
            Assert.AreEqual(inOrder.Address, outOrder.Address);
            Assert.AreEqual(inOrder.City, outOrder.City);
            Assert.AreEqual(inOrder.ZipCode, outOrder.ZipCode);
            Assert.AreEqual(inOrder.HouseNumber, outOrder.HouseNumber);
            Assert.AreEqual(inOrder.Email, outOrder.Email);

            Assert.IsNotNull(outOrder.Products);
            Assert.IsTrue(outOrder.Products.Count() == 1);
            Assert.AreEqual(inOrder.Products.First().Id, outOrder.Products.First().Id);
            Assert.AreEqual(inOrder.Products.First().Guid, outOrder.Products.First().Guid);
            Assert.AreEqual(inOrder.Products.First().Name, outOrder.Products.First().Name);
            Assert.AreEqual(inOrder.Products.First().Price, outOrder.Products.First().Price);

        }
    }
}
