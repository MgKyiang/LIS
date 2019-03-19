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
   public class CustomerServices : BaseServices {
      public  ICustomerRepository    Customers { get;  set; }
        public CustomerServices() {
            Customers = unitOfWork.Customers;
            }
        public bool UserActions(CustomerViewModel input,string CurrentUserID,string Status) {
            try {
                switch (Status) {
                    case "Save": {
                            Customer model = new Customer();
                            model.CustomerID = Guid.NewGuid().ToString();
                            model.CreatedDate = DateTime.Now;
                            model.Name = input.Name;
                            model.PhoneNo = input.PhoneNo;
                            model.Address = input.Address;
                            model.CreatedUserID = CurrentUserID;
                            model.Active = true;
                            Customers.Add(model);
                            unitOfWork.Save();
                            }break;
                    case "Update": {
                            Customer model = Customers.GetByID(input.CustomerID);
                            model.Name = input.Name;
                            model.PhoneNo = input.PhoneNo;
                            model.Address = input.Address;
                            model.UpdatedDate = DateTime.Now;
                            model.UpdatedUserID = CurrentUserID;
                            Customers.Update(model);
                            unitOfWork.Save();
                            } break;
                    case "Delete": {
                            Customer model = Customers.GetByID(input.CustomerID);
                            model.Active = false;
                            model.UpdatedUserID = CurrentUserID;
                            Customers.Update(model);
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
        public CustomerViewModel EditByID(string id) {
            Customer model= Customers.GetByID(id);
            CustomerViewModel viewmodel = new CustomerViewModel();
            viewmodel.Name = model.Name;
            viewmodel.CustomerID = model.CustomerID;
            viewmodel.PhoneNo = model.PhoneNo;
            viewmodel.Address = model.Address;
            return viewmodel;
            }
        }
    }
