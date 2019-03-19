using LIS.Services.DomainServices;
using LIS.ViewModel.Domain;
using LIS.Web.Controllers.Common;
using System.Linq;
using System.Web.Mvc;

namespace LIS.Web.Controllers.Domain {
    public class LotteryAlphabetController : ControllerAuthorizeBase {

        private   LotteryAlphabetServices lotteryAlphabetServices;
        public LotteryAlphabetController() {
            lotteryAlphabetServices = new LotteryAlphabetServices();
            }
        // GET: LotteryAlphabet
        public ActionResult Index()
        {
            return View(lotteryAlphabetServices.LotteryAlphabets.GetByAll().Where(x=>x.Active==true).ToList());
        }
        public ActionResult Create() {
            return View();            
            }
        [HttpPost]
        public ActionResult Create(LotteryAlphabetViewModel input) {
            if (ModelState.IsValid) { 
                if (!lotteryAlphabetServices.checkDataExists(input)) {
                if (lotteryAlphabetServices.UserActions(input, CurrentApplicationUser.Id, "Save")) {
                    Success(string.Format("<b>{0}</b> was successfully saved to the system.", input.Lotteryalphabet), true);
                    return RedirectToAction("Index");
                    }
                }//end of check data exists
            else {
                Warning(string.Format("<b>{0}</b> already exists in the system.", input.Lotteryalphabet), true);
                return View();
                }
                }//end of ModelState.IsValid()
            return View();
            }
        public ActionResult Edit(string id) {
            if (!string.IsNullOrEmpty(id)) {
              var data=  lotteryAlphabetServices.EditByID(id);
                return View(data);
                }
                return View();
            }
        [HttpPost]
        public ActionResult Edit(LotteryAlphabetViewModel input) {
            if (ModelState.IsValid) {
                if (!lotteryAlphabetServices.checkDataExists(input)) {
                    if (lotteryAlphabetServices.UserActions(input, CurrentApplicationUser.Id, "Update")) {
                        Success(string.Format("<b>{0}</b> was successfully update to the system.", input.Lotteryalphabet), true);
                        return RedirectToAction("Index");
                        }
                    }else {
                    Warning(string.Format("<b>{0}</b> already exists in the system.", input.Lotteryalphabet), true);
                    return View();
                    }
                }
            return View();
            }
        public ActionResult Delete(string id) {
            if (!string.IsNullOrEmpty(id)) {
                var data = lotteryAlphabetServices.EditByID(id);
                return View(data);
                }
            return View();
            }
        [HttpPost]
        public ActionResult Delete(LotteryAlphabetViewModel input) {
                if (lotteryAlphabetServices.UserActions(input, CurrentApplicationUser.Id, "Delete")) {
                    Success(string.Format("<b>{0}</b> was successfully Delete from the system.", input.Lotteryalphabet), true);
                return RedirectToAction("Index");
                }
            return View();
            }
        }
    }