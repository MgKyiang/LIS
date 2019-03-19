using LIS.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIS.Core.DataModel {
    [Table("LotteryPrize")]
  public  class LotteryPrize:BaseEntity {
        [Key]
        public string LotteryPrizeID { get; set; }
        //Lottery Alphabet table and its forekignen
        public string LotteryAlphabetID { get; set; }
        [ForeignKey("LotteryAlphabetID")]
        public virtual LotteryAlphabet LotteryAlphabet { get; set; }

        public int LotteryNumber { get; set; }

        public string LotteryTime { get; set; }

        public string LotteryPrizeTypeID { get; set; }
        [ForeignKey("LotteryPrizeTypeID")]
        public virtual LotteryPrizeType LotteryPrizeType { get; set; }
        }
    }
