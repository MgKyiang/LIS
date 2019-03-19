using LIS.Repository.AdminRepository.AdminContract;
using LIS.Repository.UnitOfWorkImp;
using LIS.Services.CommonServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIS.Services.AdminServices {
public    class TransactionLogServices:BaseServices {
        public ITransactionLogRepository TransactionLogs { get; set; }
        public TransactionLogServices() {
            TransactionLogs = unitOfWork.TransactionLogs;
            }
        }
    }
