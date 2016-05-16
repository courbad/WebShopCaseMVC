using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using TryCatch.Lib.DTO;


namespace TryCatch.Lib.Services
{
    public class ProductService : IProductService
    {
        protected string _xmlFilePath;

        public ProductService(string productXmlFilePath)
        {
            _xmlFilePath = productXmlFilePath;
        }

        public void GenerateXML()
        {
            var allProducts = GenerateProducts();

            using (var fileStream = new FileStream(_xmlFilePath, FileMode.Create, FileAccess.Write))
            {
                using (var xmlWriter = XmlWriter.Create(fileStream, new XmlWriterSettings()
                {
                    Encoding = Encoding.UTF8,
                    CloseOutput = true
                }))
                {
                    (new XmlSerializer(allProducts.GetType())).Serialize(xmlWriter, allProducts);
                }
            }
        }

        public List<Product> LoadAll()
        {
            var allProducts = new List<Product>();

            using (Stream stream = new FileStream(_xmlFilePath, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader file = new StreamReader(stream))
                {
                    XmlSerializer reader = new XmlSerializer(typeof(List<Product>));
                    allProducts = (List<Product>)reader.Deserialize(file);
                }
            }

            return allProducts;
        }

        private static IEnumerable<Product> GenerateProducts()
        {
            var products = new List<Product>();

            products.Add(ProductFactory.CreateProduct("Refrigerator", 300m));
            products.Add(ProductFactory.CreateProduct("Bottle opener", 1.90m));
            products.Add(ProductFactory.CreateProduct("Mixer", 24.5m));
            products.Add(ProductFactory.CreateProduct("Gas stove", 290m));
            products.Add(ProductFactory.CreateProduct("Electric kettle", 45.95m));
            products.Add(ProductFactory.CreateProduct("Microwave oven", 120m));
            products.Add(ProductFactory.CreateProduct("Cast iron frying pan", 56.95m));
            products.Add(ProductFactory.CreateProduct("Blender", 89m));
            products.Add(ProductFactory.CreateProduct("Dishwasher", 255m));
            products.Add(ProductFactory.CreateProduct("Teflon coating pan", 29.99m));
            products.Add(ProductFactory.CreateProduct("Set of chef's knives", 119m));
            products.Add(ProductFactory.CreateProduct("Baking thermometer", 3.75m));
            products.Add(ProductFactory.CreateProduct("Wooden spice rack", 19.50m));
            products.Add(ProductFactory.CreateProduct("Rolling pin", 4.5m));
            products.Add(ProductFactory.CreateProduct("Set of 6 beer glasses", 34.90m));
            products.Add(ProductFactory.CreateProduct("Waffle pan", 29.30m));
            products.Add(ProductFactory.CreateProduct("Grill oven", 199m));
            products.Add(ProductFactory.CreateProduct("Egg timer", 1.99m));
            products.Add(ProductFactory.CreateProduct("Cutting board", 8.9m));
            products.Add(ProductFactory.CreateProduct("Wine decanter", 34.50m));
            products.Add(ProductFactory.CreateProduct("Chopsticks", 0.99m));
            products.Add(ProductFactory.CreateProduct("Stainless steel kitchen sink", 89m));
            products.Add(ProductFactory.CreateProduct("Coffee mug", 3.95m));
            products.Add(ProductFactory.CreateProduct("Tea cup", 2.65m));
            products.Add(ProductFactory.CreateProduct("Silver spoon", 99m));

            return products;
        }
    }
}