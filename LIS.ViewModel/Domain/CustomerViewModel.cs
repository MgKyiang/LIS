using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIS.ViewModel.Domain {
 public   class CustomerViewModel {
        public string CustomerID { get; set; }
        [Required(ErrorMessage = "Customer Name လိုအပ်နေပါသည်.")]
        [Display(Name = "Customer Name")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Phone No လိုအပ်နေပါသည်.")]
        [Display(Name = "Phone No")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string PhoneNo { get; set; }
        public string  Address { get; set; }
        }
    }
