using LIS.Core.IdentityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LIS.Web.ViewModels {
    public class AuthorizationsViewModel {
        public string ID { get; set; }
        [Required(ErrorMessage = "Require ControllerName.")]
        [DataType(DataType.Text)]
        [Display(Name = "ControllerName")]
        //  [MaxLength(100), MinLength(2)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string ControllerName { get; set; }

        [Required(ErrorMessage = "Require ActionName.")]
        [DataType(DataType.Text)]
        [Display(Name = "ActionName")]
        //  [MaxLength(100), MinLength(2)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string ActionName { get; set; }

        [Required(ErrorMessage = "Require RoleName.")]
        [Display(Name = "Role Name")]
        public string RoleID { get; set; }

        [Display(Name = "Allow")]
        public bool IsAllow { get; set; }

        [Display(Name = "UseLog")]
        public bool UseLog { get; set; }
        public ApplicationRole ApplicationRole { get; set; }
        }
    }