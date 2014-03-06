using System;
using System.ComponentModel.DataAnnotations;

namespace Xos.Mvc.Framework.Models
{
    public class BaseUser : BaseModel
    {
        [Display(Name="First Name")]
        [StringLength(100,ErrorMessage="{0} must not exceed {2} characters.")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(100, ErrorMessage = "{0} must not exceed {2} characters.")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Display(Name = "Email Address")]
        [StringLength(150, ErrorMessage = "{0} must not exceed {2} characters.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name="Last Login")]
        [DataType(DataType.DateTime)]
        public DateTime? LastLogin { get; set; }
    }
}