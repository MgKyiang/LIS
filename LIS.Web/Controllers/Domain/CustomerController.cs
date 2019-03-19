using LIS.Services.DomainServices;
using LIS.ViewModel.Domain;
using LIS.Web.Controllers.Common;
using System.Linq;
using System.Web.Mvc;

namespace LIS.Web.Controllers.Domain {
    public class CustomerController : ControllerAuthorizeBase {
        private CustomerServices customerServices;
        public CustomerController() {
            customerServices = new CustomerServices();
            }
        // GET: Customers
        public ActionResult Index() {
            return View(customerServices.Customers.GetByAll().Where(x => x.Active == true).ToList());
            }
        public ActionResult Create() {
            return View();
            }
        [HttpPost]
        public ActionResult Create(CustomerViewModel input) {
            if (!ModelState.IsValid) { return View(); }
            if (customerServices.UserActions(input, CurrentApplicationUser.Id, "Save")) {
                Success(string.Format("<b>{0}</b> was successfully saved to the system.", input.Name), true);
                return RedirectToAction("Index");
                }
            else return View();
            }
        public ActionResult Edit(string id) {
            if (!string.IsNullOrEmpty(id)) {
                var data = customerServices.EditByID(id);
                return View(data);
                }
            return View();
            }
        [HttpPost]
        public ActionResult Edit(CustomerViewModel input) {
            if (ModelState.IsValid) {
                if (customerServices.UserActions(input, CurrentApplicationUser.Id, "Update")) {
                    Success(string.Format("<b>{0}</b> was successfully update to the system.", input.Name), true);
                    return RedirectToAction("Index");
                    }
                }
            return View();
            }
        public ActionResult Delete(string id) {
            if (!string.IsNullOrEmpty(id)) {
                var data = customerServices.EditByID(id);
                return View(data);
                }
            return View();
            }
        [HttpPost]
        public ActionResult Delete(CustomerViewModel input) {
            if (customerServices.UserActions(input, CurrentApplicationUser.Id, "Delete")) {
                Success(string.Format("<b>{0}</b> was successfully Delete from the system.", input.Name), true);
                return RedirectToAction("Index");
                }
            return View();
            }
        }
    }