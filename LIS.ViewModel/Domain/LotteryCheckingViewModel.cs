using LIS.Core.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIS.ViewModel.Domain {
   public class LotteryCheckingViewModel {

        [Required(ErrorMessage = "အကြိမ်ရေ လိုအပ်နေပါသည်.")]
        [Display(Name = "အကြိမ်ရေ")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string LotteryCheckingTime { get; set; }

        [Required(ErrorMessage = "ထီဖွင့်ရက် လိုအပ်နေပါသည်.")]
        [Display(Name = "ထီဖွင့်ရက်")]
        public DateTime LotteryCheckingDate { get; set; }

        }
    }
