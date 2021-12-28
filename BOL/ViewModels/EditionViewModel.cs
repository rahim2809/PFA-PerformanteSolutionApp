using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.ViewModels
{
    public class EditionViewModel
    {
        public int EditionId { get; set; }
        public string NomEdition { get; set; }
        public Nullable<System.DateTime> DateDebut { get; set; }
        public Nullable<System.DateTime> DateFin { get; set; }
        public string Statut { get; set; }
        public string Actif { get; set; }
        public string NomEvent { get; set; }
        public string Organisateur { get; set; }
        public string Description { get; set; }
        public string EventPhoto1 { get; set; }
    }
}
