using LIS.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIS.Core.DataModel {
    [Table("LotteryAlphabet")]
   public class LotteryAlphabet:BaseEntity {
        [Key]
        public string LotteryAlphabetID { get; set; }
        public int LotteryAlphabetNo { get; set; }
        public string Lotteryalphabet { get; set; }
        }
    }
