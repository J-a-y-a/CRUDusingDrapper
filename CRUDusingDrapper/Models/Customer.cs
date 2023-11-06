using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUDusingDrapper.Models
{
    public class Customer
    {
        [Display(Name = "Id")]
        public int CustomerID { get; set; }
        [Required(ErrorMessage = "First name is required.")]
        public string Name { get; set; }
        public string Address { get; set; }
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Invalid Phone number")]
        [StringLength(12)]
        public string Mobileno { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        // public string Birthdate { get; set; }
        public DateTime? Birthdate { get; set; }
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "gmail required")]
        [StringLength(30)]
        public string EmailID { get; set; }
    }
}