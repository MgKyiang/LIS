using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIS.Services.CommonServices {
 public   interface IBaseServices {
        bool Save();

        void Dispose();

        void BeginTransaction();

        bool Commit();

        void Rollback();
        }
    }
