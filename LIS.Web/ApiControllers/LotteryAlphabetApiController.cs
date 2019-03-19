using LIS.Core.DataModel;
using LIS.Services.DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LIS.Web.ApiControllers
{
    [RoutePrefix("api/LotteryAlphabet")]
    public class LotteryAlphabetApiController : ApiController
    {
        public LotteryAlphabetServices lotteryAlphabetServices;
        public LotteryAlphabetApiController() {
            lotteryAlphabetServices = new LotteryAlphabetServices();
            }
        [Route("GetAllLotteryAlphabet")]
        public IHttpActionResult GetAllLotteryAlphabet() {
            var data = lotteryAlphabetServices.LotteryAlphabets.GetByAll().Where(x=>x.Active=true).ToList();
            List<LotteryAlphabet> listdata = new List<LotteryAlphabet>();
            foreach(var i in data) {
                LotteryAlphabet z = new LotteryAlphabet();
                z.LotteryAlphabetID = i.LotteryAlphabetID;
                z.LotteryAlphabetNo = i.LotteryAlphabetNo;
                z.Lotteryalphabet = i.Lotteryalphabet;
                z.CreatedDate = i.CreatedDate;
                z.UpdatedDate = i.UpdatedDate;
                z.CreatedUserID = i.CreatedUserID;
                z.UpdatedUserID = i.UpdatedUserID;
                listdata.Add(z);
                }
            return Ok(listdata);
            }
        }
}
