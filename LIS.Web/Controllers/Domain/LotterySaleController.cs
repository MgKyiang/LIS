using LIS.Services.DomainServices;
using LIS.ViewModel.Domain;
using LIS.Web.Controllers.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LIS.Web.Controllers.Domain {
    public class LotterySaleController : ControllerAuthorizeBase {
        private LotterySaleServices lotterySaleServices;
        private CustomerServices customerServices;
        private LotteryAlphabetServices lotteryAlphabetServices;
        public LotterySaleController() {
            lotterySaleServices = new LotterySaleServices();
            customerServices = new CustomerServices();
            lotteryAlphabetServices = new LotteryAlphabetServices();
            }
        public ActionResult Index() {
            return View(lotterySaleServices.LotterySales.GetByAll().Where(x => x.Active == true).ToList());
            }
        public ActionResult Create() {
            ddlDataBind();
            return View();
            }
        private void ddlDataBind() {
            ViewBag.CustomerID = new SelectList(customerServices.Customers.GetByAll().
                Where(x => x.Active == true).ToList(), "CustomerID", "Name");
            ViewBag.LotteryAlphabetID = new SelectList(lotteryAlphabetServices.LotteryAlphabets.GetByAll().
                Where(x => x.Active == true).OrderBy(y=>y.LotteryAlphabetNo).ToList(), "LotteryAlphabetID", "Lotteryalphabet");
            ViewBag.LotteryAlphabetID2 = new SelectList(lotteryAlphabetServices.LotteryAlphabets.GetByAll().
                Where(x => x.Active == true).ToList(), "LotteryAlphabetID", "Lotteryalphabet");
            }
        [HttpPost]
        public ActionResult Create(LotterySaleViewModel input) {
            if (!ModelState.IsValid) {
                this.ddlDataBind();
                return View(); }
            if (lotterySaleServices.UserActions(input, CurrentApplicationUser.Id, "Save")) {
                Success(string.Format("<b>{0}</b> was successfully saved to the system.", input.LotteryLuckyNumber), true);
                return RedirectToAction("Index");
                }
            else { ddlDataBind(); return View(); }
            }
        public ActionResult Edit(string id) {
            if (!string.IsNullOrEmpty(id)) {
                var data = lotterySaleServices.EditByID(id);
                ddlDataBind();
                return View(data);
                }
            return View();
            }
        [HttpPost]
        public ActionResult Edit(LotterySaleViewModel input) {
            if (ModelState.IsValid) {
                if (lotterySaleServices.UserActions(input, CurrentApplicationUser.Id, "Update")) {
                    Success(string.Format("<b>{0}</b> was successfully update to the system.", input.LotteryLuckyNumber), true);
                    return RedirectToAction("Index");
                    }
                }
            ddlDataBind();
            return View();
            }
        public ActionResult Delete(string id) {
            if (!string.IsNullOrEmpty(id)) {
                var data = lotterySaleServices.EditByID(id);
                return View(data);
                }
            return View();
            }
        [HttpPost]
        public ActionResult Delete(LotterySaleViewModel input) {
            if (lotterySaleServices.UserActions(input, CurrentApplicationUser.Id, "Delete")) {
                Success(string.Format("<b>{0}</b> was successfully Delete from the system.", input.LotteryLuckyNumber), true);
                return RedirectToAction("Index");
                }
            return View();
            }
        }
    }