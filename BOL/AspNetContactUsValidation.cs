using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    class AspNetContactUsValidation
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Sender Full Name Required")]
        public string FullName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Message Object Required")]
        public string Objet { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Sender Phone Number Required")]
        public string PhoneNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email Address Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Message Required")]
        public string Message { get; set; }

    }

    [MetadataType(typeof(AspNetContactUsValidation))]
    public partial class AspNetContactU
    {

    }
}
