using LIS.Core.DataModel;
using LIS.Core.IdentityModel;
using LIS.Repository.UnitOfWorkImp;
using LIS.Services.AdminServices;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace LIS.Web.Controllers.Common {
    public class AuthorizationsBase : AuthorizeAttribute {
        //Create Instance
        private Authorizationservices authorizationservices;
        private TransactionLogServices transactionLogServices;
        private TransactionLog transactionLog;

        //constructor
        public AuthorizationsBase() {
            transactionLogServices = new TransactionLogServices();
            authorizationservices = new Authorizationservices();
            }
        //override method for On Authorization with AuthorizationContext parameter
        public override void OnAuthorization(AuthorizationContext filterContext) {
            base.OnAuthorization(filterContext);
            }
        /// <summary>
        /// Override method for AuthorizeCore with HttpContextBase Parameter
        /// Authorizations Checking
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        protected override bool AuthorizeCore(HttpContextBase httpContext) {
            //Checking User is In Authenticate
            if (httpContext.User.Identity.IsAuthenticated == false) {
                return false;
                }
            //Create User/Role Manager
            var userManager = httpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var roleManager = httpContext.GetOwinContext().Get<ApplicationRoleManager>();

            List<Authorizations> authorizationsEntities = authorizationservices.Authorizations.GetByAll().Where(x => x.Active == true).ToList();
            if (authorizationsEntities.Count == 0 || authorizationsEntities == null) {
                return false;
                }
            //Get Current RouteDate like ConrollerName , ActionName 
            var routeDate = httpContext.Request.RequestContext.RouteData;
            string currentAction = routeDate.GetRequiredString("action");
            string currentController = routeDate.GetRequiredString("controller");
            //Get Current UserName
            string currentUserName = httpContext.User.Identity.Name;

            if (string.IsNullOrEmpty(currentUserName)) {
                return false;
                }
            //Get Current ApplicationUser
            ApplicationUser currentApplicationUser = userManager.FindByName(currentUserName);

            if (currentApplicationUser == null) {
                return false;
                }

            //Get Current RoleName By Current ApplicationUser
            string roleName = userManager.GetRoles(currentApplicationUser.Id).SingleOrDefault();

            if (string.IsNullOrEmpty(roleName)) {
                return false;
                }

            //Get Current ApplicaitonRole By Current RoleName
            ApplicationRole applicaitonRole = roleManager.FindByName(roleName);

            if (applicaitonRole == null) {
                return false;
                }
            bool uselog = authorizationsEntities.Any(a => a.ControllerName.Replace(" ", string.Empty).ToLower() == currentController.Replace(" ", string.Empty).ToLower() &&
                                                                                 a.ActionName.Replace(" ", string.Empty).ToLower() == currentAction.Replace(" ", string.Empty).ToLower() &&
                                                                                 a.IsAllow == true &&
                                                                                 a.IsUseLog == true &&
                                                                                 a.RoleID == applicaitonRole.Id &&
                                                                                 a.Active == true);

            bool allow = authorizationsEntities.Any(a => a.ControllerName.Replace(" ", string.Empty).ToLower() == currentController.Replace(" ", string.Empty).ToLower() &&
                                                                               a.ActionName.Replace(" ", string.Empty).ToLower() == currentAction.Replace(" ", string.Empty).ToLower() &&
                                                                               a.IsAllow == true &&
                                                                               a.RoleID == applicaitonRole.Id &&
                                                                               a.Active == true);

            bool deny = authorizationsEntities.Any(a => a.ControllerName.Replace(" ", string.Empty).ToLower() == currentController.Replace(" ", string.Empty).ToLower() &&
                                                                               a.ActionName.Replace(" ", string.Empty).ToLower() == currentAction.Replace(" ", string.Empty).ToLower() &&
                                                                               a.IsAllow == false &&
                                                                               a.RoleID == applicaitonRole.Id &&
                                                                               a.Active == true);

            //For Log
            if (uselog) {
                //Saving Log
                Log(httpContext);
                }

            //First
            if (deny) {
                return false;
                }

            //Second
            if (allow) {
                return true;
                }
            else {
                return false;
                }
            //return base.AuthorizeCore(httpContext);
            }

        //Use Log Helper Method
        private void Log(HttpContextBase httpContext) {
            transactionLog =new TransactionLog();
            var userManager = httpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            ApplicationUser currentApplicationUser = userManager.FindByName(httpContext.User.Identity.Name);
            //create instance HTTPRequest
            var _httpRequest = httpContext.Request;
            //For Saving Passing Data => Name & Value
            StringBuilder rawDataStringBuilder = new StringBuilder();
            //Get ALl Request Key
            string[] getAllKeys = httpContext.Request.Form.AllKeys;
            //Get Value For Get Key
            foreach (string key in getAllKeys) {
                if (key != "__RequestVerificationToken") {
                    rawDataStringBuilder.Append("[ " + key + " : " + _httpRequest.Params[key].ToString() + " ]" + "\n");
                    }
                }
            transactionLog.LogID = System.Guid.NewGuid().ToString();
            transactionLog.Url = _httpRequest.Url.AbsoluteUri;
            transactionLog.ServerName = _httpRequest.Url.DnsSafeHost;
            transactionLog.HostName = _httpRequest.Url.Host;
            transactionLog.HttpRequestType = _httpRequest.RequestType;
            transactionLog.Port = _httpRequest.Url.Port.ToString();
            transactionLog.ControllerName = _httpRequest.RequestContext.RouteData.GetRequiredString("controller");
            transactionLog.ActionName = _httpRequest.RequestContext.RouteData.GetRequiredString("action");
            transactionLog.RawData = rawDataStringBuilder.ToString();
            transactionLog.CreatedUserID = currentApplicationUser.Id;
            transactionLog.CreatedDate = DateTime.Now;
            transactionLog.Active = true;
           transactionLogServices.TransactionLogs.Add(transactionLog);
            transactionLogServices.Save();
            }
        }
    }