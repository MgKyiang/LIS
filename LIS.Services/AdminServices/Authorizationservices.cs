using LIS.Repository.AdminRepository;
using LIS.Repository.AdminRepository.AdminContract;
using LIS.Repository.UnitOfWorkImp;
using LIS.Services.CommonServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIS.Services.AdminServices {
 public   class Authorizationservices:BaseServices {
        //create the instace with specify interface
        public IAuthorizationsRepository Authorizations { get; set; }
        //Constructor
        public Authorizationservices() {
            //setting up Interface object with Unit of work functions.
            Authorizations = unitOfWork.Authorizations;
            }
        }
    }
