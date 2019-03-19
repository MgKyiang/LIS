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
   public class LotteryPrizeServices : BaseServices {
      public  ILotteryPrizeRepository LotteryPrizes { get;  set; }
        public LotteryPrizeServices() {
            LotteryPrizes = unitOfWork.LotteryPrizes;
            }
        public bool UserActions(LotteryPrizeViewModel input,string CurrentUserID,string Status) {
            try {
                switch (Status) {
                    case "Save": {
                            LotteryPrize model = new LotteryPrize();
                            model.LotteryPrizeID = Guid.NewGuid().ToString();
                            //lottery alphabet
                            model.LotteryAlphabetID = input.LotteryAlphabetID;
                            //lottery prize type
                            model.LotteryPrizeTypeID = input.LotteryPrizeTypeID;
                            model.LotteryTime = input.LotteryTime;
                            model.LotteryNumber = input.LotteryNumber;
                            model.CreatedDate = DateTime.Now;
                            model.CreatedUserID = CurrentUserID;
                            model.Active = true;
                            LotteryPrizes.Add(model);
                            unitOfWork.Save();
                            }break;
                    case "Update": {
                            LotteryPrize model = LotteryPrizes.GetByID(input.LotteryPrizeID);
                            //lottery alphabet
                            model.LotteryAlphabetID = input.LotteryAlphabetID;
                            //lottery prize type
                            model.LotteryPrizeTypeID = input.LotteryPrizeTypeID;
                            model.LotteryTime = input.LotteryTime;
                            model.LotteryNumber = input.LotteryNumber;
                            model.UpdatedDate = DateTime.Now;
                            model.UpdatedUserID = CurrentUserID;
                            LotteryPrizes.Update(model);
                            unitOfWork.Save();
                            } break;
                    case "Delete": {
                            LotteryPrize model = LotteryPrizes.GetByID(input.LotteryPrizeID);
                            model.Active = false;
                            model.UpdatedUserID = CurrentUserID;
                            LotteryPrizes.Update(model);
                            unitOfWork.Save();
                            }
                        break;
                    default:
                        break;
                    }
                return true;
                }
            catch (Exception ex) {
                return false;
                }
            }
        public LotteryPrizeViewModel EditByID(string id) {
            LotteryPrize model= LotteryPrizes.GetByID(id);
            LotteryPrizeViewModel viewmodel = new LotteryPrizeViewModel();
            //lottery prize id
            viewmodel.LotteryPrizeID = model.LotteryPrizeID;
            //lottery alphabet
            viewmodel.LotteryAlphabetID = model.LotteryAlphabetID;
            //lottery prize type
            viewmodel.LotteryPrizeTypeID = model.LotteryPrizeTypeID;
            viewmodel.LotteryTime = model.LotteryTime;
            viewmodel.LotteryNumber = model.LotteryNumber;
            //for showing data when delete
            viewmodel.LotteryAlphabet = model.LotteryAlphabet;
            viewmodel.lotteryPrizeType = model.LotteryPrizeType;
            return viewmodel;
            }
        public bool checkDataExists(LotteryPrizeViewModel input) {
            return LotteryPrizes.GetByAll().Any(x => x.Active == true && x.LotteryAlphabet == input.LotteryAlphabet);
            }
        }
    }
