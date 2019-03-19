using LIS.Core.Common;
using LIS.Core.IdentityModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LIS.Core.DataModel {
    [Table("APIAuthorization")]
 public   class APIAuthorization : BaseEntity
    {
        [Key]
        public string APIAuthorizationID { get; set; }

        [Display(Name = "ControllerName")]
        public string ControllerName { get; set; }

        [Display(Name = "ActionName")]
        public string ActionName { get; set; }

        [Display(Name = "TransactionLog")]
        public bool TransactionLog { get; set; }

        [Display(Name = "AllowOrDeny")]
        public bool AllowOrDeny { get; set; }

        public string RoleID { get; set; }

        [ForeignKey("RoleID")]
        public virtual ApplicationRole ApplicationRole { get; set; }
    }
}
