using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TryCatch.Lib.DTO;

namespace TryCatch.Lib.BLL
{
    public interface IProductsBLL
    {
        IList<Product> GetManyById(string[] ids);
        IEnumerable<Product> GetList(int skip, int take);
        Product GetById(string id);
        int GetTotalCount();

        void GenerateXML();
    }
}
