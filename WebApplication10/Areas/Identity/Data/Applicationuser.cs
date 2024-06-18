using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WebApplication10.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the Applicationuser class
    public class Applicationuser : IdentityUser
    { 
        
        [PersonalData]
        [Key]
       
       
        public String Fname { get; set; }
        [PersonalData]
        public String Lname { get; set; }
        [PersonalData]
        public String LLname { get; set; }
        [PersonalData]
        public String phone_no { get; set; }
        [PersonalData]
        public String typeofId { get; set; }
        [PersonalData]
        public String Id_photo { get; set; }
    }
}
