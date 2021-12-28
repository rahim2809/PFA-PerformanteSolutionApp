using DAL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserBs
    { 
        private UserDb objDb;

        public UserBs()
        {
            objDb = new UserDb();
        }
        public IEnumerable<AspNetUser> GetAll() // Select List
        {
            return objDb.GetAll();
        }
        public AspNetUser GetById(int id) // Select Single Record
        {
            return objDb.GetById(id);
        }
        public void Insert(AspNetUser user)
        {
            objDb.Insert(user);
        }
        public void Update(AspNetUser user)
        {
            objDb.Update(user);
        }
        public void Delete(int id)
        {
            objDb.Delete(id);
        }
    }
}
