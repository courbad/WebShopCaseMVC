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

            products.Add(ProductVMFactory.CreateProduct("Refrigerator", 300m));
            products.Add(ProductVMFactory.CreateProduct("Bottle opener", 1.90m));
            products.Add(ProductVMFactory.CreateProduct("Mixer", 24.5m));
            products.Add(ProductVMFactory.CreateProduct("Gas stove", 290m));
            products.Add(ProductVMFactory.CreateProduct("Electric kettle", 45.95m));
            products.Add(ProductVMFactory.CreateProduct("Microwave oven", 120m));
            products.Add(ProductVMFactory.CreateProduct("Cast iron frying pan", 56.95m));
            products.Add(ProductVMFactory.CreateProduct("Blender", 89m));
            products.Add(ProductVMFactory.CreateProduct("Dishwasher", 255m));
            products.Add(ProductVMFactory.CreateProduct("Teflon coating pan", 29.99m));
            products.Add(ProductVMFactory.CreateProduct("Set of chef's knives", 119m));
            products.Add(ProductVMFactory.CreateProduct("Baking thermometer", 3.75m));
            products.Add(ProductVMFactory.CreateProduct("Wooden spice rack", 19.50m));
            products.Add(ProductVMFactory.CreateProduct("Rolling pin", 4.5m));
            products.Add(ProductVMFactory.CreateProduct("Set of 6 beer glasses", 34.90m));
            products.Add(ProductVMFactory.CreateProduct("Waffle pan", 29.30m));
            products.Add(ProductVMFactory.CreateProduct("Grill oven", 199m));
            products.Add(ProductVMFactory.CreateProduct("Egg timer", 1.99m));
            products.Add(ProductVMFactory.CreateProduct("Cutting board", 8.9m));
            products.Add(ProductVMFactory.CreateProduct("Wine decanter", 34.50m));
            products.Add(ProductVMFactory.CreateProduct("Chopsticks", 0.99m));
            products.Add(ProductVMFactory.CreateProduct("Stainless steel kitchen sink", 89m));
            products.Add(ProductVMFactory.CreateProduct("Coffee mug", 3.95m));
            products.Add(ProductVMFactory.CreateProduct("Tea cup", 2.65m));
            products.Add(ProductVMFactory.CreateProduct("Silver spoon", 99m));



            return products;
        }
    }
}