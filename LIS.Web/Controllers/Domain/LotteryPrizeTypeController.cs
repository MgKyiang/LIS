using LIS.Services.DomainServices;
using LIS.ViewModel.Domain;
using LIS.Web.Controllers.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LIS.Web.Controllers.Domain {
    public class LotteryPrizeTypeController : ControllerAuthorizeBase {
        private LotteryPrizeTypeServices lotteryPrizeTypeServices;
        public LotteryPrizeTypeController() {
            lotteryPrizeTypeServices = new LotteryPrizeTypeServices();
            }
        // GET: LotteryPrizeTypes
        public ActionResult Index() {
            return View(lotteryPrizeTypeServices.LotteryPrizeTypes.GetByAll().Where(x => x.Active == true).ToList());
            }
        public ActionResult Create() {
            return View();
            }
        [HttpPost]
        public ActionResult Create(LotteryPrizeTypeViewModel input) {
            if (ModelState.IsValid) {
                if (!lotteryPrizeTypeServices.checkDataExists(input)) {
                    if (lotteryPrizeTypeServices.UserActions(input, CurrentApplicationUser.Id, "Save")) {
                        Success(string.Format("<b>{0}</b> was successfully saved to the system.", input.LotteryPrizeTypeName), true);
                        return RedirectToAction("Index");
                        } 
                    }
                else {
                    Warning(string.Format("<b>{0}</b> already exists in the system.", input.LotteryPrizeTypeName), true);
                    return View();
                    }
                }
             return View();
            }
        public ActionResult Edit(string id) {
            if (!string.IsNullOrEmpty(id)) {
                var data = lotteryPrizeTypeServices.EditByID(id);
                return View(data);
                }
            return View();
            }
        [HttpPost]
        public ActionResult Edit(LotteryPrizeTypeViewModel input) {
            if (ModelState.IsValid) {
                if (!lotteryPrizeTypeServices.checkDataExists(input)) {
                    if (lotteryPrizeTypeServices.UserActions(input, CurrentApplicationUser.Id, "Update")) {
                        Success(string.Format("<b>{0}</b> was successfully update to the system.", input.LotteryPrizeTypeName), true);
                        return RedirectToAction("Index");
                        } 
                    }
                else {
                    Warning(string.Format("<b>{0}</b> already exists in the system.", input.LotteryPrizeTypeName), true);
                    return View();
                    }
                }
            return View();
            }
        public ActionResult Delete(string id) {
            if (!string.IsNullOrEmpty(id)) {
                var data = lotteryPrizeTypeServices.EditByID(id);
                return View(data);
                }
            return View();
            }
        [HttpPost]
        public ActionResult Delete(LotteryPrizeTypeViewModel input) {
            if (lotteryPrizeTypeServices.UserActions(input, CurrentApplicationUser.Id, "Delete")) {
                Success(string.Format("<b>{0}</b> was successfully Delete from the system.", input.LotteryPrizeTypeName), true);
                return RedirectToAction("Index");
                }
            return View();
            }
        }
    }