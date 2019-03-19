using System.ComponentModel.DataAnnotations;

namespace LIS.ViewModel.Domain {
    public class LotteryAlphabetViewModel {
        public string LotteryAlphabetID { get; set; }

        [Required(ErrorMessage = "အမှတ်စဉ် လိုအပ်နေပါသည်.")]
        [Display(Name = "အမှတ်စဉ်")]
        public int LotteryAlphabetNo { get; set; }
   
        [Required(ErrorMessage = "ထီအက္ခရာ လိုအပ်နေပါသည်.")]
        [Display(Name = "ထီအက္ခရာ")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength =1 )]
        public string Lotteryalphabet { get; set; }
        }
    }
