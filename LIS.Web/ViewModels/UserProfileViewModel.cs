
using LIS.Core.DataModel;
using LIS.Core.IdentityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace LIS.Web.ViewModels {
    public class UserProfileViewModel
    {
        public Customer Customer { get; set; }
        public UsersMember UsersMember { get; set; }
    }
}