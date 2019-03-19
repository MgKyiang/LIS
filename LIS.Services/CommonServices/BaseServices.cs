using LIS.Repository.UnitOfWorkImp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIS.Services.CommonServices {
  public  class BaseServices:IBaseServices {
       
        //instance of Unit of Work
        protected UnitOfWork unitOfWork;
        //construcotr
        public BaseServices() {
            unitOfWork = new UnitOfWork();
            }
        //begin transaction for commit and rollback.
        public void BeginTransaction() {
            this.unitOfWork.BeginTransaction();
            }
        //commit the record to the database.
        public bool Commit() {
            try {
                unitOfWork.Commit();
                return true;
                }
            catch (Exception ex) {
                return false;
                }
            }
        //dispose (close) for unit of work.
        public void Dispose() {
            unitOfWork.Dispose();
            }
        //roll back the record before saving record to database.
        public void Rollback() {
            unitOfWork.Rollback();
            }
        //save the record to the database.
        public bool Save() {

            try {
                unitOfWork.Save();
                return true;
                }
            catch (Exception ex) {
                return false;
                }
            }
        }
   
    }
