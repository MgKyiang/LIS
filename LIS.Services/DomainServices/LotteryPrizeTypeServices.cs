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
   public class LotteryPrizeTypeServices : BaseServices {
      public  ILotteryPrizeTypeRepository LotteryPrizeTypes { get;  set; }
        public LotteryPrizeTypeServices() {
            LotteryPrizeTypes = unitOfWork.LotteryPrizeTypes;
            }
        public bool UserActions(LotteryPrizeTypeViewModel input,string CurrentUserID,string Status) {
            try {
                switch (Status) {
                    case "Save": {
                            LotteryPrizeType model = new LotteryPrizeType();
                            model.LotteryPrizeTypeID = Guid.NewGuid().ToString();
                            model.CreatedDate = DateTime.Now;
                            model.LotteryPrizeTypeName = input.LotteryPrizeTypeName;
                            model.LotteryPrizeTypeDescription = input.LotteryPrizeTypeDescription;
                            model.CreatedUserID = CurrentUserID;
                            model.Active = true;
                            LotteryPrizeTypes.Add(model);
                            unitOfWork.Save();
                            }break;
                    case "Update": {
                            LotteryPrizeType model = LotteryPrizeTypes.GetByID(input.LotteryPrizeTypeID);
                            model.LotteryPrizeTypeName = input.LotteryPrizeTypeName;
                            model.LotteryPrizeTypeDescription = input.LotteryPrizeTypeDescription;
                            model.UpdatedDate = DateTime.Now;
                            model.UpdatedUserID = CurrentUserID;
                            LotteryPrizeTypes.Update(model);
                            unitOfWork.Save();
                            } break;
                    case "Delete": {
                            LotteryPrizeType model = LotteryPrizeTypes.GetByID(input.LotteryPrizeTypeID);
                            model.Active = false;
                            model.UpdatedUserID = CurrentUserID;
                            LotteryPrizeTypes.Update(model);
                            unitOfWork.Save();
                            }
                        break;
                    default:
                        break;
                    }
                return true;
                }
            catch (Exception) {
                return false;
                }
            }
        public LotteryPrizeTypeViewModel EditByID(string id) {
            LotteryPrizeType model= LotteryPrizeTypes.GetByID(id);
            LotteryPrizeTypeViewModel viewmodel = new LotteryPrizeTypeViewModel();
            viewmodel.LotteryPrizeTypeDescription = model.LotteryPrizeTypeDescription;
            viewmodel.LotteryPrizeTypeID = model.LotteryPrizeTypeID;
            viewmodel.LotteryPrizeTypeName = model.LotteryPrizeTypeName;
            return viewmodel;
            }

        public bool checkDataExists(LotteryPrizeTypeViewModel input) {
            return LotteryPrizeTypes.GetByAll().Any(x => x.Active == true && x.LotteryPrizeTypeName == input.LotteryPrizeTypeName);
            }
        }
    }
