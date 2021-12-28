using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RoleDb
    {
        private PerformanteSolutionDBEntities db;

        public RoleDb()
        {
            db = new PerformanteSolutionDBEntities();
        }


        public IEnumerable<AspNetRole> GetAll() // Select List
        {
            return db.AspNetRoles.ToList();
        }
        public AspNetRole GetById(int id) // Select Single Record
        {
            return db.AspNetRoles.Find(id);
        }
        public void Insert(AspNetRole role)
        {
            db.AspNetRoles.Add(role);
            save();
        }
        public void Update(AspNetRole role)
        {
            db.Entry(role).State = System.Data.Entity.EntityState.Modified;
            save();
        }
        public void Delete(int id)
        {
            AspNetRole role = db.AspNetRoles.Find(id);
            db.AspNetRoles.Remove(role);
            save();
        }

        public void save()
        {
            db.SaveChanges();
        }
    }
}
