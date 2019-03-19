using LIS.Core.DataModel;
using LIS.Repository.AdminRepository.AdminContract;
using LIS.Repository.UnitOfWorkImp;
using LIS.Services.CommonServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIS.Services.AdminServices {
public    class ApplicationSettingServices:BaseServices {

        public IApplicationSettingRepository AppSettings { get; set; }
        public ApplicationSettingServices() {
            AppSettings = unitOfWork.AppSettings;
            }


        #region Paging Size
        public int PagingSize {
            get {
                ApplicationSetting pagingsize = AppSettings.SingleOrDefault(x => x.Key == "PagingSize" && x.Active == true);

                if (pagingsize == null) {
                    return 10;
                    }
                else {
                    int value;
                    if (int.TryParse(pagingsize.Value, out value)) {
                        return value;
                        }
                    else {
                        return 10;
                        }
                    }
                }
            }

        #endregion

        #region [DateFormat
        public string DateFormat {
            get {
                ApplicationSetting dateFormat =AppSettings.SingleOrDefault(x => x.Key == "DateFormat" && x.Active == true);

                if (dateFormat == null) {
                    return "dd/MM/yyyy";
                    }
                else {
                    return dateFormat.Value;
                    }

                }
            }
        #endregion

        #region TimeFormat
        public string TimeFormat {
            get {
                ApplicationSetting dateFormat = AppSettings.SingleOrDefault(x => x.Key == "TimeFormat" && x.Active == true);

                if (dateFormat == null) {
                    return "hh:mm tt";
                    }
                else {
                    return dateFormat.Value;
                    }

                }
            }
        #endregion

        #region AppName
        public string ApplicationName {
            get {
                ApplicationSetting dateFormat = AppSettings.SingleOrDefault(x => x.Key == "ApplicationName" && x.Active == true);

                if (dateFormat == null) {
                    return "Lottery Information System";
                    }
                else {
                    return dateFormat.Value;
                    }

                }
            }
        #endregion

        #region App Version
        public string ApplicationVersion {
            get {
                ApplicationSetting dateFormat = AppSettings.SingleOrDefault(x => x.Key == "ApplicationVersion" && x.Active == true);

                if (dateFormat == null) {
                    return "LIS v.1.0.0.0";
                    }
                else {
                    return dateFormat.Value;
                    }
                }
            }
        #endregion

        #region DefaultUserPassword
        public string DefaultUserPassword {
            get {
                ApplicationSetting dateFormat = AppSettings.SingleOrDefault(x => x.Key == "DefaultUserPassword" && x.Active == true);

                if (dateFormat == null) {
                    return "LIS v.1.0.0.0";
                    }
                else {
                    return dateFormat.Value;
                    }
                }
            }
        #endregion

        #region FooterTradeMark
        public string FooterTradeMark {
            get {
                ApplicationSetting dateFormat = AppSettings.SingleOrDefault(x => x.Key == "FooterTradeMark" && x.Active == true);

                if (dateFormat == null) {
                    return "Copyright";
                    }
                else {
                    return dateFormat.Value;
                    }
                }
            }
        #endregion

        }
    }
