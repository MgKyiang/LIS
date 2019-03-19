using LIS.Services.AdminServices;
using LIS.ViewModel.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LIS.Web.Controllers {
    public class HomeController : Controller {
        private ContactUsServices contactUsServices;
        public HomeController() {
            contactUsServices = new ContactUsServices();
            }
        public ActionResult Index() {
            return View();
            }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";
            return View();
            }

        public ActionResult Contact() {
            return View();
            }
        [HttpPost]
        public  ActionResult Contact(ContactUsViewModel input) {
            if (ModelState.IsValid) {
              if(  contactUsServices.UserActions(input, Guid.NewGuid().ToString())){
                    ViewBag.msg = "Your Message had been sent Thanks.";           
                    }
                }
            return View();
            }
        }
    }