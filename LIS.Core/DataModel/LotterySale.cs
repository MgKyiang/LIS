using LIS.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIS.Core.DataModel {
    [Table("LotterySale")]
  public  class LotterySale : BaseEntity {
        [Key]
        public string LotterySaleID { get; set; }
        //Lottery Alphabet table and its forekignen
        public string CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public virtual Customer  Customers { get; set; }

        public DateTime SaleDate { get; set; }

        public string LotteryAlphabetID { get; set; }
        [ForeignKey("LotteryAlphabetID")]
        public virtual LotteryAlphabet LotteryAlphabets { get; set; }

        public int LotteryLuckyNumber { get; set; }

        public string LotteryLuckyTime { get; set; }

        public decimal Prize { get; set; }

        }
    }
