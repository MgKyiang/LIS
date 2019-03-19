using LIS.Core.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIS.ViewModel.Domain {
  public  class LotterySaleViewModel {
        public string LotterySaleID { get; set; }
        [Required(ErrorMessage = "၀ယ်ယူသူအမည် လိုအပ်နေပါသည်.")]
        [Display(Name = "၀ယ်ယူသူအမည်")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        public string CustomerID { get; set; }
        public virtual Customer Customers { get; set; }
        [Required(ErrorMessage = "ရက်စွဲ လိုအပ်နေပါသည်.")]
        [Display(Name = "ရက်စွဲ")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime SaleDate { get; set; }
        [Required(ErrorMessage = "အက္ခရာ လိုအပ်နေပါသည်.")]
        [Display(Name = "အက္ခရာ")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        public string LotteryAlphabetID { get; set; }
        public virtual  LotteryAlphabet LotteryAlphabets { get; set; }
        public string LotteryAlphabetID2 { get; set; }
        public virtual LotteryAlphabet LotteryAlphabets2 { get; set; }

        [Required(ErrorMessage = "ထီဂဏန်း လိုအပ်နေပါသည်.")]
        [Display(Name = "ထီဂဏန်း")]
        //[Range(1, 6)]
        public int LotteryLuckyNumber { get; set; }
       

        [Required(ErrorMessage = "အကြိမ် လိုအပ်နေပါသည်.")]
        [Display(Name = "အကြိမ်")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string LotteryLuckyTime { get; set; }


        [Required(ErrorMessage = "စျေးနှုန်း လိုအပ်နေပါသည်.")]
        [Display(Name = "စျေးနှုန်း")]       
        public decimal Prize { get; set; }


       // [Range(1,6)]
        public  Nullable< int> LotteryLuckyNumber2 { get; set; }
        public Nullable< bool> IsDefaultUser { get; set; }

        public bool IsForAll47Alphabet { get; set; }

        }
    }
