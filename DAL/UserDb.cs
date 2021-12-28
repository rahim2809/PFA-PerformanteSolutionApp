using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDb
    {
        private PerformanteSolutionDBEntities db;

        public UserDb()
        {
            db = new PerformanteSolutionDBEntities();
        }


        public IEnumerable<AspNetUser> GetAll() // Select List
        {
            return db.AspNetUsers.ToList();
        }
        public AspNetUser GetById(int id) // Select Single Record
        {
            return db.AspNetUsers.Find(id);
        }
        public void Insert(AspNetUser user)
        {
           
            db.AspNetUsers.Add(user);
            save();
        }
        public void Update(AspNetUser user)
        {
            db.Entry(user).State = System.Data.Entity.EntityState.Modified;
            save();
        }
        public void Delete(int id)
        {
            AspNetUser user = db.AspNetUsers.Find(id);
            db.AspNetUsers.Remove(user);
            save();
        }

        public void save()
        {
            db.SaveChanges();
        }
    }
}
