using LIS.Core.IdentityModel;
using System.Collections.Generic;

namespace LIS.Web.ViewModels {
    public class UserAssignRoleViewModel
    {
        public ApplicationUser ApplicationUser { get; set; }
        public List<ApplicationRole> ApplicationRoles { get; set; }
    }
}
