using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDemoCodeDAL.DAL.Entity.Customer
{
   public class CustomerDetails
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }
        [Required]
        public string Address { get; set; }
        public string State { get; set; }
        public string Dist { get; set; }
        [Display(Name = "Mobile Number")]
        public string MobileNo { get; set; }
        public string Email { get; set; }

         [Required(ErrorMessage = "DOB is Required")]
         [DataType(DataType.Date, ErrorMessage = "DOB is Required")]
         [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Opening Balance")]
        public double OpeningBal { get; set; }
        [Display(Name = "Closing Balance")]
        public double ClosingBal { get; set; }
        //[Display(Name = "Is Active")]
       // public bool IsActive { get; set; }
    }
}
