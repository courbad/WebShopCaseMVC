using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System;
using TryCatch.Lib.BLL;
using TryCatch.Lib.DTO;

namespace TryCatch.Web.Shop.Tests.BLL
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
                    //Count = 10,
                    Id = "MD5something",
                    Name = "Test product",
                    Price = 99m
                }
            };


            var bll = new OrdersBLL();
            var guid = bll.Create(inOrder);

            var outOrder = bll.GetById(guid);


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
            //Assert.AreEqual(inOrder.Products.First().Guid, outOrder.Products.First().Guid);
            Assert.AreEqual(inOrder.Products.First().Name, outOrder.Products.First().Name);
            Assert.AreEqual(inOrder.Products.First().Price, outOrder.Products.First().Price);

        }
    }
}
