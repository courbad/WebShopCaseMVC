using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TryCatchWebShop.DAL;

namespace TryCatchWebShop
{
    public static class CodeFirstConfig
    {
        public static void InitDatabase()
        {
            using (WebShopContext db = new WebShopContext())
            {
                var test = new Order()
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

                db.Orders.Add(test);

                var check = db.Orders.ToList();
            }
        }
    }
}