using BOL;
using BOL.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class RawSqlQueryDb 
    { 
        private PerformanteSolutionDBEntities db;
        private EditionDb objDb;


        public RawSqlQueryDb()
        {
            db = new PerformanteSolutionDBEntities();
            objDb = new EditionDb();
        }

        

        /************************* Get Pro events ********************************/


        public IEnumerable<AspNetEvent> GetProEvents(string Id) // Select List
        {
            var EventList = db.AspNetEvents.Where(e => e.UserId == Id ).ToList();

            return EventList;
        }

       

        /************************* Search for pro events ********************************/

        public IEnumerable<AspNetEvent> SearchForProEvents(string Id, string searchTxt)
        {
            var EventList = db.AspNetEvents.Where(e => e.UserId == Id && (e.NomEvent.Contains(searchTxt) || e.Organisateur.Contains(searchTxt)) ).ToList();

            return EventList;
        }

        

        /************************* For a given event id return all the related editions ********************************/

        public IEnumerable<AspNetEdition> GetEventEditions(int Id) // Select List 
        {
           
            var EdtionList = db.AspNetEditions.Where(e => e.EventId == Id ).OrderByDescending(e => e.Actif).ToList();
            return EdtionList;
        }

        /************************* Search  for event  editions list ********************************/

        public IEnumerable<AspNetEdition> SearchForEventEditionsList(int Id, string searchTxt)
        {
            var EdtionList = db.AspNetEditions.Where(e => e.EventId == Id &&  e.NomEdition.Contains(searchTxt) ).ToList();

            return EdtionList;
        }


        /*************************  editions' list pro side with event name ********************************/

        public IEnumerable<EditionViewModel> EditionListPro(string id)
        {
            

            IEnumerable<AspNetEdition> editionList = db.AspNetEditions.Where(e => e.AspNetEvent.AspNetUser.Id == id).ToList();

            EditionViewModel editionVM = new EditionViewModel();
            IEnumerable<EditionViewModel> editionVMList = editionList.Select(x => new EditionViewModel
            {
                NomEdition = x.NomEdition,
                DateDebut = x.DateDebut,
                DateFin = x.DateFin,
                NomEvent = x.AspNetEvent.NomEvent,
                Organisateur = x.AspNetEvent.Organisateur,
                Description = x.AspNetEvent.Description,
                Statut = x.Statut,
                Actif = x.Actif,
                EditionId = x.EditionId
            }).ToList();



            return editionVMList;

        }

        /************************* Search  for page list editions pro side ********************************/

        public IEnumerable<EditionViewModel> SearchForEditionsListPro(string id, string searchTxt)
        {
            var editionList = db.AspNetEditions.Where(e => e.AspNetEvent.AspNetUser.Id==id && (e.NomEdition.Contains(searchTxt) || e.AspNetEvent.NomEvent.Contains(searchTxt))).ToList();

            EditionViewModel editionVM = new EditionViewModel();
            IEnumerable<EditionViewModel> editionVMList = editionList.Select(x => new EditionViewModel
            {
                NomEdition = x.NomEdition,
                DateDebut = x.DateDebut,
                DateFin = x.DateFin,
                NomEvent = x.AspNetEvent.NomEvent,
                Organisateur = x.AspNetEvent.Organisateur,
                Description = x.AspNetEvent.Description,
                Statut = x.Statut,
                Actif = x.Actif,
                EditionId = x.EditionId
            }).ToList();

            return editionVMList;
        }



        /************************* Search funtionnality for  events admin side ********************************/

        public IEnumerable<AspNetEvent> SearchForEventsAdmin(string searchTxt)
        {
            var EventList = db.AspNetEvents.Where(e =>  (e.NomEvent.Contains(searchTxt) || e.Organisateur.Contains(searchTxt))).ToList();

            return EventList;
        }


        /*************************  List of all   editions admin side with event name ********************************/

        public IEnumerable<EditionViewModel> EditionListAdmin()
        {
            

            IEnumerable<AspNetEdition> editionList = db.AspNetEditions.ToList();

            EditionViewModel editionVM = new EditionViewModel();
            IEnumerable<EditionViewModel> editionVMList = editionList.Select(x => new EditionViewModel
            {
                NomEdition = x.NomEdition,
                DateDebut = x.DateDebut,
                DateFin = x.DateFin,
                NomEvent = x.AspNetEvent.NomEvent,
                Organisateur = x.AspNetEvent.Organisateur,
                Description = x.AspNetEvent.Description,
                Statut = x.Statut,
                Actif = x.Actif,
                EditionId = x.EditionId
            }).ToList();



            return editionVMList;

        }


        /************************* Search  for   editions list admin side ********************************/

        public IEnumerable<EditionViewModel> SearchForEditionsListAdmin(string searchTxt)
        {
            var editionList = db.AspNetEditions.Where(e =>  e.NomEdition.Contains(searchTxt) || e.AspNetEvent.NomEvent.Contains(searchTxt) ).ToList();

            EditionViewModel editionVM = new EditionViewModel();
            IEnumerable<EditionViewModel> editionVMList = editionList.Select(x => new EditionViewModel
            {
                NomEdition = x.NomEdition,
                DateDebut = x.DateDebut,
                DateFin = x.DateFin,
                NomEvent = x.AspNetEvent.NomEvent,
                Organisateur = x.AspNetEvent.Organisateur,
                Description = x.AspNetEvent.Description,
                Statut = x.Statut,
                Actif = x.Actif,
                EditionId = x.EditionId
            }).ToList();

            return editionVMList;
        
        }


        /************************* Enable or disable a given edition ********************************/

        public void OnOROffEdition(int id, string actif) // Select List
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ID", id),
                new SqlParameter("@Actif", actif)
            };

            db.Database.ExecuteSqlCommand("UPDATE AspNetEditions SET Actif = @Actif WHERE EditionId = @ID ",param);
        }

        /************************* Home Page List of all enabled  edition comming for the next 30 days ********************************/

        public IEnumerable<EditionViewModel> CommingEventEdition()
        {
            string actif = "TRUE";

            IEnumerable<AspNetEdition> editionList = db.AspNetEditions.Where(e => e.Actif == actif && e.DateDebut > DateTime.Now && e.DateDebut < System.Data.Entity.DbFunctions.AddDays(DateTime.Now, 30)).ToList();

            EditionViewModel editionVM = new EditionViewModel();
            IEnumerable<EditionViewModel> editionVMList = editionList.Select(x => new EditionViewModel
            {
                NomEdition = x.NomEdition,
                DateDebut = x.DateDebut,
                DateFin = x.DateFin,
                NomEvent = x.AspNetEvent.NomEvent,
                Organisateur = x.AspNetEvent.Organisateur,
                Description = x.AspNetEvent.Description,
                EventPhoto1 = x.EventPhoto1
            }).ToList();



            return editionVMList;

        }







        /************************* Disable editions of an unvalidated event by admin ********************************/

        public void OffEventEditions(int id, string statut, string actif) // Select List
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ID", id),
                new SqlParameter("@Actif", actif),
                new SqlParameter("@Statut", statut)
            };

            db.Database.ExecuteSqlCommand("UPDATE AspNetEditions SET Actif = @Actif , Statut=@Statut WHERE EventId = @ID ", param);
        }

        /************************* Get User by name  ********************************/


        public AspNetUser GetUserByName(string user) // Select List
        {
            var User = db.AspNetUsers.Where(u => u.UserName == user).FirstOrDefault();

            return User;
        }


    }
}
