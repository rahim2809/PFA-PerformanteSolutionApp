using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace BOL
{
    public class AspNetEventValidation
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Event Name Required")] 
        public string NomEvent { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Organizator Name Required")]
        public string Organisateur { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Event Login Required")]
        public string Login { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Event Description Required")]
        public string Description { get; set; }

    }

    [MetadataType(typeof(AspNetEventValidation))]
    public partial class AspNetEvent
    {

    }
}
