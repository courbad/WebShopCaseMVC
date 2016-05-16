using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TryCatch.Lib.DTO;

namespace TryCatch.Lib.BLL
{
    public interface IOrdersBLL
    {
        Guid Create(Order order);
        Order GetById(Guid id);
    }
}
