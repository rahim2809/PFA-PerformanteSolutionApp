using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EventDb
    {
        private PerformanteSolutionDBEntities db;
         
        public EventDb()
        {
            db = new PerformanteSolutionDBEntities();
        }


        public IEnumerable<AspNetEvent> GetAll() // Select List
        {
            return db.AspNetEvents.ToList();
        }
        public AspNetEvent GetById(int id) // Select Single Record
        {
            return db.AspNetEvents.Find(id);
        }
        public void Insert(AspNetEvent userEvent)
        {
           
                db.AspNetEvents.Add(userEvent);
                save();
            
        }
        public void Update(AspNetEvent userEvent)
        {
            db.Entry(userEvent).State = System.Data.Entity.EntityState.Modified;
            save();
        }
        public void Delete(int id)
        {
            AspNetEvent userEvent = db.AspNetEvents.Find(id);
            db.AspNetEvents.Remove(userEvent);
            save();
        }

        public void save()
        {
            

                db.SaveChanges();
            

        }
    }
}
