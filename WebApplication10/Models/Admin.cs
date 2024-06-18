using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace WebApplication10.Models
{
    public class Admin
    {
        [Required]
    public string Rolename { get; set; }
    }
}
