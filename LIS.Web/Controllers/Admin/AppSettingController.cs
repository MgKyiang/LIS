using LIS.Core.DataModel;
using LIS.Repository.UnitOfWorkImp;
using LIS.Services.AdminServices;
using LIS.Web.Controllers.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LIS.Web.Controllers.Admin
{
    public class AppSettingController : ControllerAuthorizeBase {

        private ApplicationSettingServices applicationSettingServices;
        private ApplicationSetting applicationSettingEntity;
        public AppSettingController() {
            applicationSettingServices = new ApplicationSettingServices();
            }
        [HttpGet]
        public ActionResult Index(string searchby1, string search1, string searchby2, string search2, string sortby, int? page, string status) {
            var data = applicationSettingServices.AppSettings.GetByAll().Where(x => x.Active == true).ToList();
            //Sorting ViewBag
            ViewBag.KeySortby = sortby == "KeyAsc" ? "KeyDesc" : "KeyAsc";
            ViewBag.ValueSortby = sortby == "ValueAsc" ? "ValueDesc" : "ValueAsc";

            //For Showing Alert
            ViewBag.Searchby1 = searchby1;
            ViewBag.Search1 = search1;

            ViewBag.Searchby2 = searchby2;
            ViewBag.Search2 = search2;

            ViewBag.sortby = sortby;
            ViewBag.Status = status;
            //Searching
            if (!string.IsNullOrEmpty(searchby1) && !string.IsNullOrEmpty(search1)) {
                data = GetSearchingData(searchby1, search1, data);
                }
            if (!string.IsNullOrEmpty(searchby2) && !string.IsNullOrEmpty(search2)) {
                data = GetSearchingData(searchby2, search2, data);
                }
            //Sorting
            if (!string.IsNullOrEmpty(sortby)) {
                switch (sortby) {
                    case "KeyAsc":
                        data = data.OrderBy(x => x.Key).ToList();
                        break;
                    case "ValueDesc":
                        data = data.OrderByDescending(x => x.Value).ToList();
                        break;
                    case "KeyDesc":
                        data = data.OrderBy(x => x.Key).ToList();
                        break;
                    case "ValueAsc":
                        data = data.OrderByDescending(x => x.Value).ToList();
                        break;
                    }
                }
            return View(data);
            }

        [HttpPost]
        public JsonResult Create(ApplicationSetting model) {
            var checkdata = applicationSettingServices.AppSettings.GetByAll().Any(x => x.Key == model.Key && x.Active == true);

            if (!checkdata) {
                ApplicationSetting appmodel = new ApplicationSetting() {
                    ApplicationSettingID = Guid.NewGuid().ToString(),
                    Key = model.Key,
                    Value = model.Value,
                    Active = true,
                    CreatedUserID = CurrentApplicationUser.Id,
                    CreatedDate = DateTime.Now
                    };
                try {
                    applicationSettingServices.AppSettings.Add(appmodel);
                    applicationSettingServices.Save();
                    // Check that ApplicationSetting entity is not null
                    }
                catch (Exception ex) {
                    throw;
                    }

                return Json(true, JsonRequestBehavior.AllowGet);
                }
            else {
                return Json(false, JsonRequestBehavior.AllowGet);
                }
            }

        [HttpGet]
        public ActionResult Edit(string Id) {
            if (!string.IsNullOrEmpty(Id)) {
                applicationSettingEntity = new ApplicationSetting();
                applicationSettingEntity = applicationSettingServices.AppSettings.SingleOrDefault(x => x.ApplicationSettingID == Id && x.Active == true);

                return View(applicationSettingEntity);
                }

            return View();
            }

        [HttpPost]
        public ActionResult Edit(ApplicationSetting model) {
            if (ModelState.IsValid) {
                applicationSettingEntity = new ApplicationSetting();
                applicationSettingEntity = applicationSettingServices.AppSettings.SingleOrDefault(x => x.ApplicationSettingID == model.ApplicationSettingID && x.Active == true);
                applicationSettingEntity.Key = model.Key;
                applicationSettingEntity.Value = model.Value;
                applicationSettingEntity.UpdatedDate = DateTime.Now;
                applicationSettingEntity.UpdatedUserID = CurrentApplicationUser.Id;

                applicationSettingServices.AppSettings.Update(applicationSettingEntity);
                applicationSettingServices.Save();

                return RedirectToAction("Index");
                }

            return View(model.ApplicationSettingID);
            }
        //Searching Helper
        private List<ApplicationSetting> GetSearchingData(string searchby, string search, List<ApplicationSetting> data) {
            switch (searchby) {
                case "Key":
                    data = data.Where(x => x.Key.ToLower().Contains(search.ToLower())).ToList();
                    break;
                case "Value":
                    data = data.Where(x => x.Value.ToLower().Contains(search.ToLower())).ToList();
                    break;
                }
            return data;
            }
        }
    }