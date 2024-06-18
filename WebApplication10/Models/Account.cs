using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication10.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication10.Models
{
    public class Account
    {
       
        [Key]
        [Display(Name = "Account Number")]
        
        public int account_id { get; set; }

        [Required(ErrorMessage = "Please enter the amount")]
        [DataType(DataType.Currency)]
        [Range(0.00, 1000000.00, ErrorMessage = "The maximum amount is 1,000,000 ETB")]
        public float? balance { get; set; }
     [Required]
        
        public string? Id { get; set; }
       
       
       

       





    }
}
