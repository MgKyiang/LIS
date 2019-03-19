﻿
using LIS.Core.DataModel;
using LIS.Core.IdentityModel;
using LIS.Repository.AdminRepository.AdminContract;
using LIS.Repository.CommonRepository;
using System.Collections.Generic;
using System.Linq;

namespace LIS.Repository.AdminRepository {
    public class ApplicationSettingRepository : Repository<ApplicationSetting>, IApplicationSettingRepository
    {
        public ApplicationDbContext ApplicationDbContext
        {
            get { return dbContext as ApplicationDbContext; }
        }
        public ApplicationSettingRepository(ApplicationDbContext _dbContext) : base(_dbContext)
        {
        }
        //define Customize method
        public IEnumerable<ApplicationSetting> GetApplicationSettingByKeyName(string Key)
        {
            return ApplicationDbContext.ApplicationSettings.Where(x => x.Key == Key);
        }
    }
}
