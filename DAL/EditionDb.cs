using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EditionDb
    {
        private PerformanteSolutionDBEntities db;

        public EditionDb()
        {
            db = new PerformanteSolutionDBEntities(); 
        }


        public IEnumerable<AspNetEdition> GetAll() // Select List
        {
            return db.AspNetEditions.ToList();
        }

        public AspNetEdition GetById(int id) // Select Single Record
        {
            return db.AspNetEditions.Find(id);
        }

        public void Insert(AspNetEdition edition)
        {
            try
            {
                db.AspNetEditions.Add(edition);
                save();
            }
            catch (Exception ex)
            { 

            }
        }

        public void Update(AspNetEdition edition)
        {
            try
            {
                db.Entry(edition).State = System.Data.Entity.EntityState.Modified;
                save();
            }
            catch (Exception ex) { }
        }
        public void Delete(int id)
        {
            AspNetEdition edition = db.AspNetEditions.Find(id);
            db.AspNetEditions.Remove(edition);
            save();
        }

        public void save()
        {
            db.SaveChanges();
        }
    }
}
