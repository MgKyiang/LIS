using LIS.Core.DataModel;
using LIS.Repository.DomainRepository.DomainContract;
using LIS.Repository.UnitOfWorkImp;
using LIS.Services.CommonServices;
using LIS.ViewModel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIS.Services.DomainServices {
   public class LotteryCheckingServices : BaseServices {
      public  ILotteryCheckingRepository LotteryCheckings { get;  set; }
        public LotteryCheckingServices() {
            LotteryCheckings = unitOfWork.LotteryCheckings;
            }
        public bool LotteryCheckingProcess(List<LotteryChecking> input,string CurrentUserID) {
            try {
                List<LotteryChecking> modellsit = new List<LotteryChecking>();
                foreach (var item in input) {
                            LotteryChecking model = new LotteryChecking();
                            model.LotteryCheckingID = Guid.NewGuid().ToString();
                            model.LotteryPrizeID = item.LotteryPrizeID;
                            model.LotterySaleID = item.LotterySaleID;
                            model.LotteryCheckingTime = item.LotteryCheckingTime;
                            model.LotteryCheckingDate = item.LotteryCheckingDate;
                            model.CreatedDate = DateTime.Now;
                            model.CreatedUserID = CurrentUserID;
                            model.Active = true;
                            modellsit.Add(model);
                    }                            
                            LotteryCheckings.AddRange(modellsit);
                            unitOfWork.Save();
                return true;
                }
            catch (Exception ex) {
                return false;
                }
            }    
        }
    }
