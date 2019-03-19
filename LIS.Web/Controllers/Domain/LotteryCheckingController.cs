using LIS.Core.DataModel;
using LIS.Services.DomainServices;
using LIS.ViewModel.Domain;
using LIS.Web.Controllers.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LIS.Web.Controllers.Domain
{
    public class LotteryCheckingController : ControllerAuthorizeBase {
        public LotteryCheckingServices lotteryCheckingServices;
        public LotteryAlphabetServices lotteryAlphabetSerivces;
        public LotterySaleServices lotterySaleServices;
        public LotteryPrizeServices lotteryPrizeServices;
        public LotteryCheckingController() {
            lotteryCheckingServices = new LotteryCheckingServices();
            lotteryAlphabetSerivces = new LotteryAlphabetServices();
            lotterySaleServices = new LotterySaleServices();
            lotteryPrizeServices = new LotteryPrizeServices();
            }
        // GET: LotteryChecking
        public ActionResult Index()
        {
            return View(lotteryCheckingServices.LotteryCheckings.GetByAll().Where(x=>x.Active==true).ToList());
        }
        public ActionResult LotteryCheckingProcess() {
            return View();
            }
        [HttpPost]
        public ActionResult LotteryCheckingProcess(LotteryCheckingViewModel input) {
            if(!ModelState.IsValid) {
                return View();
                }
        List<LotteryChecking> data=lotteryCheckingServices.LotteryCheckings.GetByAll().Where(x => x.LotteryCheckingDate == input.LotteryCheckingDate && x.LotteryCheckingTime == input.LotteryCheckingTime).ToList();
            if (data.Count > 0)
                lotteryCheckingServices.LotteryCheckings.RemoveRange(data);
            List<LotteryPrize> prizesList = lotteryPrizeServices.LotteryPrizes.GetByAll().Where(x => x.LotteryTime == input.LotteryCheckingTime).ToList();
            List<LotterySale> salesSearchList = lotterySaleServices.LotterySales.GetByAll().Where(x => x.LotteryLuckyTime == input.LotteryCheckingTime).ToList();

            var LotteryPrizeResult = from p in prizesList
                                                     join x in salesSearchList
                                                     on p.LotteryAlphabetID equals x.LotteryAlphabetID
                                                     where p.LotteryNumber == x.LotteryLuckyNumber
                                                     select new { Prize=p,
                                                                         SaleUser=x
                                                                        };
            List<LotteryChecking> entities = new List<LotteryChecking>();
            foreach(var item in LotteryPrizeResult) {
                LotteryChecking model = new LotteryChecking();
                model.LotteryCheckingDate = input.LotteryCheckingDate;
                model.LotteryCheckingTime = input.LotteryCheckingTime;
                model.LotterySaleID = item.SaleUser.LotterySaleID;
                model.LotteryPrizeID = item.Prize.LotteryPrizeID;
                entities.Add(model);
                }
            if (entities.Count > 0) {
                if (lotteryCheckingServices.LotteryCheckingProcess(entities, CurrentApplicationUser.Id))
                    Success(string.Format("<b>{0}</b>record(s) was successfully saved to the system.", entities.Count), true);
                else Danger(string.Format("<b>{0}</b>Error Occur when Lottery Prize Checking Process.", entities.Count), true);
                }
            else Information("There is no data when processing Lottery Prize Checking process", true);
            return RedirectToAction("Index");
            }
        }
}