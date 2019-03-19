using LIS.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIS.Core.IdentityModel {
    [Table("UsersMember")]
  public  class UsersMember:BaseEntity
    {
        [Key]
        public string UsersMemberID { get; set; }
        public string UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual ApplicationUser ApplicationUser { get; set; }
        public string UserInMemberID { get; set; }
        public string MemberStatus { get; set; }

    }
}
