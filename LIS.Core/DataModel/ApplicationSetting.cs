using LIS.Core.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LIS.Core.DataModel {
    [Table("ApplicationSetting")]
    public class ApplicationSetting : BaseEntity
    {
        [Key]
        [ScaffoldColumn(false)]
        public string ApplicationSettingID { get; set; }

        [Required(ErrorMessage = "Require KeyName.")]
        [Display(Name = "Key")]
        [MaxLength(500), MinLength(2)]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string Key { get; set; }

        [Required(ErrorMessage = "Require Value.")]
        [Display(Name = "Value")]
        [MaxLength(4000), MinLength(2)]
        [StringLength(4000, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string Value { get; set; }
    }
}
