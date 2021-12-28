using BOL;
using BOL.ViewModels;
using DAL;
using System;
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RawSqlQueryBs 
    {
        private RawSqlQueryDb objDb;

        public RawSqlQueryBs()
        {
            objDb = new RawSqlQueryDb();
        }

        public IEnumerable<AspNetEvent> GetProEvents(string id) // Select List
        {
            return objDb.GetProEvents(id);
        }

        public IEnumerable<AspNetEvent> SearchForProEvents(string Id, string searchTxt)
        {
            return objDb.SearchForProEvents( Id,  searchTxt);
        }





        public IEnumerable<AspNetEdition> GetEventEditions(int Id)
        {
            return objDb.GetEventEditions(Id);
        }


        public IEnumerable<AspNetEdition> SearchForEventEditionsList(int Id, string searchTxt)
        {

            return objDb.SearchForEventEditionsList(Id, searchTxt);
        }


        public IEnumerable<EditionViewModel> EditionListPro(string id)
        {
            return objDb.EditionListPro(id);
        }

        public IEnumerable<EditionViewModel> SearchForEditionsListPro(string id, string searchTxt)
        {
            return objDb.SearchForEditionsListPro(id, searchTxt);
        }


        public IEnumerable<AspNetEvent> SearchForEventsAdmin(string searchTxt)
        {

            return objDb.SearchForEventsAdmin(searchTxt);
        }



        public IEnumerable<EditionViewModel> EditionListAdmin()
        {
            return objDb.EditionListAdmin();
        }

        public IEnumerable<EditionViewModel> SearchForEditionsListAdmin(string searchTxt)
        {
            return objDb.SearchForEditionsListAdmin(searchTxt);
        }




        public void OnOROffEdition(int id, string actif)
        {
            objDb.OnOROffEdition(id, actif);
        }



        public IEnumerable<EditionViewModel> CommingEventEdition()
        {
            return objDb.CommingEventEdition();
        }


        public void OffEventEditions(int id, string statut, string actif)
        {
            objDb.OffEventEditions(id, statut, actif);
        }



        public AspNetUser GetUserByName(string user)
        {
            return objDb.GetUserByName(user);
        }






    }
}
