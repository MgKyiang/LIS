using LIS.Core.IdentityModel;
using LIS.Repository.AdminRepository.AdminContract;
using LIS.Repository.UnitOfWorkImp;
using LIS.Services.CommonServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIS.Services.AdminServices {
    public class APIAuthorizationServices:BaseServices  {
        public IAPIAuthorizationRepository APIAuthorizations { get; set; }
        public APIAuthorizationServices() {
            APIAuthorizations = unitOfWork.APIAuthorizations;
            }
        }
    }
