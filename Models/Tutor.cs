using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UJTUT.Models
{
    public class Tutor
    {

        [Key]
        public int id { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Please add a Profile picture")]
        [DisplayName("Profile Picture")]
        public IFormFile Profile_picture { get; set; }

        

        [Required(ErrorMessage ="Please enter Tutor name")]
        [DisplayName("Tutor name")]
        public string Tutor_name{ get; set; }

        [Required(ErrorMessage = "Please enter Modules")]
        [DisplayName("Modules")]
        public string Modules { get; set; }

        [Required(ErrorMessage = "Please fill in your Bio")]
        [DisplayName("Bio")]
        public string bio { get; set; }

        [Required(ErrorMessage = "Please enter your Phone number")]
        [DisplayName("Phone Number")]
        public string cell { get; set; }

        [Required(ErrorMessage = "Please enter your Email")]
        [DisplayName("Email")]
        public string email { get; set; }


        [Required(ErrorMessage = "Please enter your Rate")]
        [DisplayName("Rates per hour")]
        public string price { get; set; }
        public Tutor()
        {

        }
    }
}
