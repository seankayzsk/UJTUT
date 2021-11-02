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
        
        [DisplayName("Profile Picture")]

        public IFormFile Profile_picture { get; set; }

        public string pic_name { get; set; }
        


       
        [DisplayName("Tutor name")]
        public string Tutor_name{ get; set; }

        
        [DisplayName("Modules")]
        public string Modules { get; set; }

        [DisplayName("Campus")]
        public string Campus { get; set; }

        [DisplayName("Bio")]
        public string bio { get; set; }

        
        [DisplayName("Phone Number")]
        public string cell { get; set; }

       
        [DisplayName("Email")]
        public string email { get; set; }

        [DisplayName("Password")]
        public string password { get; set; }

        [DisplayName("Rate Criterion")]
        public string RateCriteria { get; set; }




        [DisplayName("Price(ZAR)")]
        public string price { get; set; }
        public Tutor()
        {

        }
    }
}
