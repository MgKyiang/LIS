using LIS.Core.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIS.ViewModel.Domain {
   public class LotteryPrizeViewModel {
        public string LotteryPrizeID { get; set; }
        //Lottery Alphabet table 
        [Required(ErrorMessage = "ထီအက္ခရာ လိုအပ်နေပါသည်.")]
        [Display(Name = "ထီအက္ခရာ")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        public string LotteryAlphabetID { get; set; }
        
        public virtual LotteryAlphabet LotteryAlphabet { get; set; }
        [Required(ErrorMessage = "ထီဂဏန်း  လိုအပ်နေပါသည်.")]
        [Display(Name = "ထီဂဏန်း")]
      //  [Range(1, 6)]
        public int LotteryNumber { get; set; }
        [Required(ErrorMessage = "အကြိမ်ရေ လိုအပ်နေပါသည်.")]
        [Display(Name = "အကြိမ်ရေ")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string LotteryTime { get; set; }

        [Required(ErrorMessage = "ထီသိန်းဆု အမျိုးအစား  လိုအပ်နေပါသည်.")]
        [Display(Name = "ထီသိန်းဆု အမျိုးအစား")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string LotteryPrizeTypeID { get; set; }

        public virtual LotteryPrizeType lotteryPrizeType { get; set; }
        }
    }
