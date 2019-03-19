using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LIS.WebAPI.Controllers
{
    public class UsersController : Controller
    {
        [HttpGet]
        public ActionResult Create() {
            return View();
            }
        [HttpGet]
        public ActionResult Login() {
            return View();
            }
        }
}