using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment.Models
{
   public interface IShoppersMock
    {
        IQueryable<Shopper> Shoppers { get; }
        Shopper Save(Shopper shopper);
        void Delete(Shopper shopper);
    }
}
