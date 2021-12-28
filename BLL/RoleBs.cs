using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RoleBs
    { 
        private RoleDb objDb;

        public RoleBs()
        {
            objDb = new RoleDb();
        }
        public IEnumerable<AspNetRole> GetAll() // Select List
        {
            return objDb.GetAll();
        }
        public AspNetRole GetById(int id) // Select Single Record
        {
            return objDb.GetById(id);
        }
        public void Insert(AspNetRole role)
        {
            objDb.Insert(role);
        }
        public void Update(AspNetRole role)
        {
            objDb.Update(role);
        }
        public void Delete(int id)
        {
            objDb.Delete(id);
        }

    }
}
