using LIS.Core.DataModel;
using LIS.Repository.AdminRepository.AdminContract;
using LIS.Repository.UnitOfWorkImp;
using LIS.Services.CommonServices;
using LIS.ViewModel.Admin;
using LIS.ViewModel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIS.Services.AdminServices {
 public   class ContactUsServices:BaseServices {
        public IContactUsRepository ContactUs { get; set; }
        public ContactUsServices() {
            ContactUs = unitOfWork.ContactUs;
            }
        public bool UserActions(ContactUsViewModel input, string CurrentUserID) {
            try {
                            ContactUs model = new ContactUs();
                            model.ContactUsID = Guid.NewGuid().ToString();
                            model.CreatedDate = DateTime.Now;
                            model.Name = input.Name;
                            model.Message = input.Message;
                            model.Company = input.Company;
                            model.WebSite = input.WebSite;
                            model.CreatedUserID = CurrentUserID;
                            model.Active = true;
                            ContactUs.Add(model);
                            unitOfWork.Save();
                return true;
                }
            catch (Exception) {
                return false;
                }
            }
        }
    }
