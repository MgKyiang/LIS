using LIS.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIS.Core.DataModel {
    [Table("LotteryPrizeType")]
  public  class LotteryPrizeType:BaseEntity {
        [Key]
        public string LotteryPrizeTypeID { get; set; }
        public string LotteryPrizeTypeName { get; set; }
        public string LotteryPrizeTypeDescription { get; set; }
        }
    }
