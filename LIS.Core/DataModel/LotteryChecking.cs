using LIS.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIS.Core.DataModel {
    [Table("LotteryChecking")]
  public  class LotteryChecking : BaseEntity {
        [Key]
        public string LotteryCheckingID { get; set; }

        public string LotteryCheckingTime { get; set; }

        public DateTime  LotteryCheckingDate { get; set; }

        public string LotteryPrizeID { get; set; }
        [ForeignKey("LotteryPrizeID")]
        public virtual LotteryPrize LotteryPrizes { get; set; }

        public string LotterySaleID { get; set; }
        [ForeignKey("LotterySaleID")]
        public virtual LotterySale LotterySales { get; set; }
        }
    }
