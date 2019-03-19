using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIS.ViewModel.Admin {
 public   class ContactUsViewModel {
        [Required(ErrorMessage = "Contact Name လိုအပ်နေပါသည်.")]
        [Display(Name = "Contact Name")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Contact Email လိုအပ်နေပါသည်.")]
        [Display(Name = "Contact Email")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string Email { get; set; }
        public string Company { get; set; }
        public string WebSite { get; set; }
        [Required(ErrorMessage = "Message လိုအပ်နေပါသည်.")]
        [Display(Name = "Message")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string Message { get; set; }
        }
    }
