using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace assignment.Models
{

    public class EFShoppers : IShoppersMock
    {
        private Model1 db = new Model1();

        public IQueryable<Shopper> Shoppers
        {
            get { return db.Shoppers; }
        }

        public void Delete(Shopper shopper)
        {
            db.Shoppers.Remove(shopper);
            db.SaveChanges();
        }

        public Shopper Save(Shopper shopper)
        {
            if (shopper.Stock == 0)
            {
                // insert
                db.Shoppers.Add(shopper);
            }
            else
            {
                // update
                db.Entry(shopper).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return shopper;
        }
    }
}