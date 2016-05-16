using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TryCatch.Lib.DTO;

namespace TryCatch.Lib.Services
{
    public interface IOrderService
    {
        Guid Insert(Order order);
        Order GetById(Guid id);
    }
}
