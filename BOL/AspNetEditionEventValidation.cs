using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Web;


namespace BOL
{
    public class AspNetEditionEventValidation
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Edition Name Required")] 
        public string NomEdition { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public string DateDebut { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public string DateFin { get; set; }

        public int EvId { get; set; }

        public string PhotoPath { get; set; }


        [DisplayName("Choisir un fichier")]
        public string EventPhoto1 { get; set; }

        public HttpPostedFileBase fichierImage { get; set; }


    }


    [MetadataType(typeof(AspNetEditionEventValidation))]
    public partial class AspNetEdition
    {
        public int EvId { get; set; }
        public string PhotoPath { get; set; }

        [NotMapped]
        public HttpPostedFileBase fichierImage { get; set; }
    }
}
