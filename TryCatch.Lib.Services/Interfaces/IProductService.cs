using System.Collections.Generic;
using TryCatch.Lib.DTO;

namespace TryCatch.Lib.Services
{
    public interface IProductService
    {
        List<Product> LoadAll();
        void GenerateXML();
    }
}
