using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIS.ViewModel.Domain {
  public  class LotteryPrizeTypeViewModel {
        public string LotteryPrizeTypeID { get; set; }
        [Required(ErrorMessage = "ထီသိန်းဆု အမျိုးအစား  လိုအပ်နေပါသည်.")]
        [Display(Name = "ထီသိန်းဆု အမျိုးအစား")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string LotteryPrizeTypeName { get; set; }

        [Required(ErrorMessage = "ထီသိန်းဆု အမျိုးအစား(အပြည့်အစုံ) လိုအပ်နေပါသည်.")]
        [Display(Name = "ထီသိန်းဆု အမျိုးအစား(အပြည့်အစုံ)")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength =2)]
        public string LotteryPrizeTypeDescription { get; set; }
        }
    }
