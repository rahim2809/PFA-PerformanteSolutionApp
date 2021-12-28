using DAL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EventBs
    { 
        private EventDb objDb;

        public EventBs()
        {
            objDb = new EventDb();
        }
        public IEnumerable<AspNetEvent> GetAll() // Select List
        {
            return objDb.GetAll();
        }
        public AspNetEvent GetById(int id) // Select Single Record
        {
            return objDb.GetById(id);
        }
        public void Insert(AspNetEvent userEvent)
        {
            objDb.Insert(userEvent);
        }
        public void Update(AspNetEvent userEvent)
        {
            objDb.Update(userEvent);
        }
        public void Delete(int id)
        {
            objDb.Delete(id);
        }

       
    }
}
