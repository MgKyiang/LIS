using LIS.Repository.AdminRepository.AdminContract;
using LIS.Repository.UnitOfWorkImp;
using LIS.Services.CommonServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIS.Services.AdminServices {
   public class ErrorLogServices:BaseServices {
        public IErrorLogRepository ErrorLogs { get; set; }
        public ErrorLogServices() {
            ErrorLogs = unitOfWork.ErrorLogs;
            }
        }
    }
