using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ContactUDb
    {
        private PerformanteSolutionDBEntities db;

        public ContactUDb()
        {
            db = new PerformanteSolutionDBEntities();
        }


        public IEnumerable<AspNetContactU> GetAll() // Select List
        {
            return db.AspNetContactUs.ToList();
        }
       
        public void Insert(AspNetContactU contact)
        {

            db.AspNetContactUs.Add(contact);
            save();
        }
       
        public void Delete(int id)
        {
            AspNetContactU contact = db.AspNetContactUs.Find(id);
            db.AspNetContactUs.Remove(contact);
            save();
        }

        public void save()
        {
            db.SaveChanges();
        }
    }
}
