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
   public class LotteryAlphabetServices:BaseServices {
      public  ILotteryAlphabetRepository LotteryAlphabets { get;  set; }
        public LotteryAlphabetServices() {
            LotteryAlphabets = unitOfWork.LotteryAlphabets;
            }
        public bool UserActions(LotteryAlphabetViewModel input,string CurrentUserID,string Status) {
            try {
                switch (Status) {
                    case "Save": {
                            LotteryAlphabet model = new LotteryAlphabet();
                            model.LotteryAlphabetID = Guid.NewGuid().ToString();
                            model.CreatedDate = DateTime.Now;
                            model.LotteryAlphabetNo = input.LotteryAlphabetNo;
                            model.Lotteryalphabet = input.Lotteryalphabet;
                            model.CreatedUserID = CurrentUserID;
                            model.Active = true;
                            LotteryAlphabets.Add(model);
                            unitOfWork.Save();
                            }break;
                    case "Update": {
                            LotteryAlphabet model = LotteryAlphabets.GetByID(input.LotteryAlphabetID);
                            model.LotteryAlphabetNo = input.LotteryAlphabetNo;
                            model.Lotteryalphabet = input.Lotteryalphabet;
                            model.UpdatedDate = DateTime.Now;
                            model.UpdatedUserID = CurrentUserID;
                            LotteryAlphabets.Update(model);
                            unitOfWork.Save();
                            } break;
                    case "Delete": {
                            LotteryAlphabet model = LotteryAlphabets.GetByID(input.LotteryAlphabetID);
                            model.Active = false;
                            model.UpdatedUserID = CurrentUserID;
                            LotteryAlphabets.Update(model);
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
        public LotteryAlphabetViewModel EditByID(string id) {
            LotteryAlphabet model= LotteryAlphabets.GetByID(id);
            LotteryAlphabetViewModel viewmodel = new LotteryAlphabetViewModel();
            viewmodel.Lotteryalphabet = model.Lotteryalphabet;
            viewmodel.LotteryAlphabetID = model.LotteryAlphabetID;
            viewmodel.LotteryAlphabetNo = model.LotteryAlphabetNo;
            return viewmodel;
            }
        public bool checkDataExists(LotteryAlphabetViewModel input) {
           return LotteryAlphabets.GetByAll().Any(x => x.Active == true && x.Lotteryalphabet == input.Lotteryalphabet);        
            }
        }
    }
