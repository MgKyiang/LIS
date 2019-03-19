using LIS.Services.DomainServices;
using LIS.ViewModel.Domain;
using LIS.Web.Controllers.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LIS.Web.Controllers.Domain {
    public class LotteryPrizeController : ControllerAuthorizeBase {
        private LotteryPrizeServices LotteryPrizeServices;
        private LotteryPrizeTypeServices lotteryPrizeTypeServices;
        private LotteryAlphabetServices lotteryAlphabetServices;
        public LotteryPrizeController() {
            LotteryPrizeServices = new LotteryPrizeServices();
            lotteryPrizeTypeServices = new LotteryPrizeTypeServices();
            lotteryAlphabetServices = new LotteryAlphabetServices();
            }
        // GET: LotteryPrizes
        public ActionResult Index() {
            return View(LotteryPrizeServices.LotteryPrizes.GetByAll().Where(x => x.Active == true).ToList());
            }
        public ActionResult Create() {
            ddlDataBind();
            return View();
            }
        private void ddlDataBind() {
            ViewBag.LotteryPrizeTypeID = new SelectList(lotteryPrizeTypeServices.LotteryPrizeTypes.GetByAll().
                Where(x => x.Active == true).ToList(), "LotteryPrizeTypeID", "LotteryPrizeTypeName");
            ViewBag.LotteryAlphabetID = new SelectList(lotteryAlphabetServices.LotteryAlphabets.GetByAll().
                Where(x => x.Active == true).ToList(), "LotteryAlphabetID", "Lotteryalphabet");
            }
        [HttpPost]
        public ActionResult Create(LotteryPrizeViewModel input) {
            if (ModelState.IsValid) {
                if (!LotteryPrizeServices.checkDataExists(input)) {
                    if (LotteryPrizeServices.UserActions(input, CurrentApplicationUser.Id, "Save")) {
                        Success(string.Format("<b>{0}</b> was successfully saved to the system.", input.LotteryNumber), true);
                        return RedirectToAction("Index");
                        }

                    }
                else {
                    Warning(string.Format("<b>{0}</b> already exists in the system.", input.LotteryNumber), true);
                    return View();
                    }
                }
            return View();
            }
        public ActionResult Edit(string id) {
            if (!string.IsNullOrEmpty(id)) {
                var data = LotteryPrizeServices.EditByID(id);
                ddlDataBind();
                return View(data);
                }
            return View();
            }
        [HttpPost]
        public ActionResult Edit(LotteryPrizeViewModel input) {
            if (ModelState.IsValid) {
                if (!LotteryPrizeServices.checkDataExists(input)) {
                    if (LotteryPrizeServices.UserActions(input, CurrentApplicationUser.Id, "Update")) {
                        Success(string.Format("<b>{0}</b> was successfully update to the system.", input.LotteryNumber), true);
                        return RedirectToAction("Index");
                        } 
                    }
                else {
                    Warning(string.Format("<b>{0}</b> already exists in the system.", input.LotteryNumber), true);
                    return View();
                    }
                }
            ddlDataBind();
            return View();
            }
        public ActionResult Delete(string id) {
            if (!string.IsNullOrEmpty(id)) {
                var data = LotteryPrizeServices.EditByID(id);
                return View(data);
                }
            return View();
            }
        [HttpPost]
        public ActionResult Delete(LotteryPrizeViewModel input) {
            if (LotteryPrizeServices.UserActions(input, CurrentApplicationUser.Id, "Delete")) {
                Success(string.Format("<b>{0}</b> was successfully Delete from the system.", input.LotteryNumber), true);
                return RedirectToAction("Index");
                }
            return View();
            }
        }
    }