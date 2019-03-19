using LIS.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIS.Core.DataModel {
    [Table("LotteryShopProfile")]
  public  class LotteryShopProfile:BaseEntity {
        [Key]
        public string LotteryShopProfileID { get; set; }
        public string LotteryShopProfileName { get; set; }
        public string LotteryShopProfileLogo { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string FbPageUrl { get; set; }
        public string WebSiteUrl { get; set; }
        public string Address { get; set; }
        }
    }
