using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContactManagemet.Models
{
    public class ContactMetaData
    {
        public int Id { get; set; }
        [Required]        
        [Display(Name= "First Name")]        
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [RegularExpression(RegexType.Email,ErrorMessage="Please enter valid email.")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [RegularExpression(RegexType.Phone, ErrorMessage = "Please enter valid phone number.")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
        [Display(Name = "Status")]
        public string Status { get; set; }
    }
}