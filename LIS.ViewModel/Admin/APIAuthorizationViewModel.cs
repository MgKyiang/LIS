using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIS.ViewModel.Admin {
    public class APIAuthorizationViewModel {
        public string ID { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string RoleID { get; set; }
        public string RoleName { get; set; }
        public bool TransactionLog { get; set; }
        public bool AllowOrDeny { get; set; }

        public List<string> RolesId { get; set; }
        }
    }
