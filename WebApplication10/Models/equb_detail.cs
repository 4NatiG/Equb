using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication10.Models
{
    public class equb_detail
    {


        [Key]
        [Display(Name = "Equb ID")]
        public int equb_id { get; set; }

        [Required(ErrorMessage = "Equb name is required")]
        [Display(Name = "Equb Name")]
        [StringLength(25, ErrorMessage = "Name shouldn't be longer than 25 letters ")]
        public string equb_name { get; set; }
        [Required(ErrorMessage = "Equb type is required")]
        [Display(Name = "Equb Type")]
        public string equb_type { get; set; }

        [Required(ErrorMessage = "Cycle is required")]
        public string cycle { get; set; }

        [Required(ErrorMessage = "Duration is required")]
        public int duration { get; set; }

        public string status { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{7,25}$", ErrorMessage = "Password shouldn't be longer that 25 and shorter that 7 letters and characters are not allowed")]
        public string password { get; set; }

        [Required(ErrorMessage = "Number of people participating is required")]
        [Display(Name = "Number of People")]
        [Range(5.00, 50.00, ErrorMessage = "The amount of people participating should't be greater than 50 and less than 5")]
        public int number_of_users { get; set; }

        [Required(ErrorMessage = "Please enter the amount")]
        [DataType(DataType.Currency)]
        [Range(100.00, 200000.00, ErrorMessage = "The maximum amount is 200,000 ETB and minimum amount is 100 ETB")]
        public float? amount { get; set; }

        [Required(ErrorMessage = "Start date is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime start_date { get; set; }

        [Required(ErrorMessage = "End date is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "End Date")]
        public DateTime end_date { get; set; }

       [Required]

        public string user_id { get; set; }
       


    }
}
