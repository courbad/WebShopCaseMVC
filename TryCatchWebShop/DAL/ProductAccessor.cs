using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using TryCatchWebShop.Models;

namespace TryCatchWebShop.DAL
{
    public class ProductAccessor
    {
        private static readonly ProductAccessor _instance = new ProductAccessor();

        private string _xmlFilePath;

        private ProductAccessor()
        {
            _xmlFilePath = HttpContext.Current.Server.MapPath("~/App_Data/products.xml");
        }

        public static ProductAccessor Instance 
        {
            get 
            {
                return _instance;
            }
        }

        public void CreateProductXml()
        {
            var allProducts = GenerateProducts();

            var serializer = new XmlSerializer(allProducts.GetType());
            var fileStream = new FileStream(_xmlFilePath, FileMode.Create);
            using (var xmlWriter = new XmlTextWriter(fileStream, Encoding.UTF8))
            {
                serializer.Serialize(xmlWriter, allProducts);
            }
        }

        public List<ProductVM> LoadAllProducts()
        {
            var allProducts = new List<ProductVM>();

            XmlSerializer reader = new XmlSerializer(typeof(List<ProductVM>));
            using (StreamReader file = new System.IO.StreamReader(_xmlFilePath))
            {
                allProducts = (List<ProductVM>)reader.Deserialize(file);
            }

            return allProducts;
        }

        private static IEnumerable<ProductVM> GenerateProducts()
        {
            var products = new List<ProductVM>();

            products.Add(new ProductVM() { Name = "Refrigerator", Price = 300m });
            products.Add(new ProductVM() { Name = "Bottle opener", Price = 1.90m });
            products.Add(new ProductVM() { Name = "Mixer", Price = 24.5m });
            products.Add(new ProductVM() { Name = "Gas stove", Price = 290m });
            products.Add(new ProductVM() { Name = "Electric kettle", Price = 45.95m });
            products.Add(new ProductVM() { Name = "Microwave oven", Price = 120m });
            products.Add(new ProductVM() { Name = "Cast iron frying pan", Price = 56.95m });
            products.Add(new ProductVM() { Name = "Blender", Price = 89m });
            products.Add(new ProductVM() { Name = "Dishwasher", Price = 255m });
            products.Add(new ProductVM() { Name = "Teflon coating pan", Price = 29.99m });
            products.Add(new ProductVM() { Name = "Set of chef's knives", Price = 119m });
            products.Add(new ProductVM() { Name = "Baking thermometer", Price = 3.75m });
            products.Add(new ProductVM() { Name = "Wooden spice rack", Price = 19.50m });
            products.Add(new ProductVM() { Name = "Rolling pin", Price = 4.5m });
            products.Add(new ProductVM() { Name = "Set of 6 beer glasses", Price = 34.90m });
            products.Add(new ProductVM() { Name = "Waffle pan", Price = 29.30m });
            products.Add(new ProductVM() { Name = "Grill oven", Price = 199m });
            products.Add(new ProductVM() { Name = "Egg timer", Price = 1.99m });
            products.Add(new ProductVM() { Name = "Cutting board", Price = 8.9m });
            products.Add(new ProductVM() { Name = "Wine decanter", Price = 34.50m });
            products.Add(new ProductVM() { Name = "Chopsticks", Price = 0.99m });
            products.Add(new ProductVM() { Name = "Stainless steel kitchen sink", Price = 89m });
            products.Add(new ProductVM() { Name = "Coffee mug", Price = 3.95m });
            products.Add(new ProductVM() { Name = "Tea cup", Price = 2.65m });
            products.Add(new ProductVM() { Name = "Silver spoon", Price = 99m });

            return products;
        }

    }
}