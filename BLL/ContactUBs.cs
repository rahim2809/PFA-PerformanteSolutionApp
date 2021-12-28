using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public  class ContactUBs
    {
        private ContactUDb objDb;

        public ContactUBs()
        {
            objDb = new ContactUDb();
        }
        public IEnumerable<AspNetContactU> GetAll() // Select List
        {
            return objDb.GetAll();
        }
       
        public void Insert(AspNetContactU contact)
        {
            objDb.Insert(contact);
        }
       
        public void Delete(int id)
        {
            objDb.Delete(id);
        }
    }
}
