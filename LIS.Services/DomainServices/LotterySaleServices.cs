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
   public class LotterySaleServices : BaseServices {
      public  ILotterySaleRepository LotterySales { get;  set; }
        public ILotteryAlphabetRepository LotteryAlphabets { get; set; }
        public ICustomerRepository Customers { get; set; }
        public LotterySaleServices() {
            LotterySales = unitOfWork.LotterySales;
            Customers = unitOfWork.Customers;
            LotteryAlphabets = unitOfWork.LotteryAlphabets;
            }
        public bool UserActions(LotterySaleViewModel input,string CurrentUserID,string Status) {
            try {               
                switch (Status) {
                    case "Save": {
                            List<LotterySale> lotterySaleList = new List<LotterySale>();
                            if (input.IsDefaultUser == true) {
                                Customer c = Customers.getCustomerByName("Default User");
                                input.CustomerID = c.CustomerID;
                                }
                            if (input.IsForAll47Alphabet == true) {
                                var data = LotteryAlphabets.GetByAll().Where(x => x.Active == true).ToList();
                                foreach (var i in data) {
                                    LotterySale model = new LotterySale();
                                    model.LotterySaleID = Guid.NewGuid().ToString();
                                    //lottery alphabet
                                    model.LotteryAlphabetID =i.LotteryAlphabetID;
                                    model.CustomerID = input.CustomerID;
                                    model.SaleDate = input.SaleDate;
                                    model.LotteryLuckyNumber =input.LotteryLuckyNumber;
                                    model.LotteryLuckyTime = input.LotteryLuckyTime;
                                    model.Prize = input.Prize;
                                    model.CreatedDate = DateTime.Now;
                                    model.CreatedUserID = CurrentUserID;
                                    model.Active = true;
                                    lotterySaleList.Add(model);
                                    }
                                LotterySales.AddRange(lotterySaleList);
                                }//end of 47 alphabet?
                          else  if (input.LotteryLuckyNumber2!=null) {
                                for (int i = input.LotteryLuckyNumber; i <= input.LotteryLuckyNumber2; i++) {
                                    LotterySale model = new LotterySale();
                                    model.LotterySaleID = Guid.NewGuid().ToString();
                                    //lottery alphabet
                                    model.LotteryAlphabetID = input.LotteryAlphabetID;
                                    model.CustomerID = input.CustomerID;
                                    model.SaleDate = input.SaleDate;
                                    model.LotteryLuckyNumber = i;
                                    model.LotteryLuckyTime = input.LotteryLuckyTime;
                                    model.Prize = input.Prize;
                                    model.CreatedDate = DateTime.Now;
                                    model.CreatedUserID = CurrentUserID;
                                    model.Active = true;
                                    lotterySaleList.Add(model);
                                    }
                                LotterySales.AddRange(lotterySaleList);
                                }//end of from Lucky Number 1 to Lucky Number ?
                            else {
                                LotterySale model = new LotterySale();
                                model.LotterySaleID = Guid.NewGuid().ToString();
                                //lottery alphabet
                                model.LotteryAlphabetID = input.LotteryAlphabetID;
                                model.CustomerID = input.CustomerID;
                                model.SaleDate = input.SaleDate;
                                model.LotteryLuckyNumber =input.LotteryLuckyNumber;
                                model.LotteryLuckyTime = input.LotteryLuckyTime;
                                model.Prize = input.Prize;
                                model.CreatedDate = DateTime.Now;
                                model.CreatedUserID = CurrentUserID;
                                model.Active = true;
                                LotterySales.Add(model);
                                }//end of else (Default input value)
                            unitOfWork.Save();
                            }break;
                    case "Update": {
                            LotterySale model = LotterySales.GetByID(input.LotterySaleID);
                            //lottery alphabet
                            model.LotteryAlphabetID = input.LotteryAlphabetID;
                            model.CustomerID = input.CustomerID;
                            model.SaleDate = input.SaleDate;
                            model.LotteryLuckyNumber = input.LotteryLuckyNumber;
                            model.LotteryLuckyTime = input.LotteryLuckyTime;
                            model.Prize = input.Prize;
                            model.UpdatedDate = DateTime.Now;
                            model.UpdatedUserID = CurrentUserID;
                            LotterySales.Update(model);
                            unitOfWork.Save();
                            } break;
                    case "Delete": {
                            LotterySale model = LotterySales.GetByID(input.LotterySaleID);
                            model.Active = false;
                            model.UpdatedUserID = CurrentUserID;
                            LotterySales.Update(model);
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
        public LotterySaleViewModel EditByID(string id) {
            LotterySale model= LotterySales.GetByID(id);
            LotterySaleViewModel viewmodel = new LotterySaleViewModel();
            //lottery prize id
            viewmodel.LotterySaleID = model.LotterySaleID;
            //lottery alphabet
            viewmodel.LotteryAlphabetID = model.LotteryAlphabetID;
            viewmodel.SaleDate = model.SaleDate;
            viewmodel.CustomerID = model.CustomerID;
            viewmodel.LotteryLuckyTime = model.LotteryLuckyTime;
            viewmodel.LotteryLuckyNumber = model.LotteryLuckyNumber;
            //for showing data when delete
            viewmodel.Customers = model.Customers;
            viewmodel.LotteryAlphabets = model.LotteryAlphabets;
            return viewmodel;
            }
        }
    }
