using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using DAL;

namespace BLL
{
    public class EditionBs
    {
        private EditionDb objDb;

        public EditionBs()
        {
            objDb = new EditionDb();
        }
        public IEnumerable<AspNetEdition> GetAll() // Select List
        {
            return objDb.GetAll();
        }
        public AspNetEdition GetById(int id) // Select Single Record
        {
            return objDb.GetById(id);
        }
        public void Insert(AspNetEdition edition)
        {
            objDb.Insert(edition);
        }

       

        public void Update(AspNetEdition edition)
        {
            objDb.Update(edition);
        }
        public void Delete(int id)
        {
            objDb.Delete(id);
        }


    }
}
