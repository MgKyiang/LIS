using LIS.Core.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LIS.Core.DataModel {
    [Table("Customer")]
    public class Customer : BaseEntity {
        [Key]
        public string CustomerID { get; set; }
        [MaxLength(500), MinLength(2)]
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        }
        }
