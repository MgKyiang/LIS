namespace LIS.Core.Migrations
{
    using SeedConfig;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LIS.Core.IdentityModel.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(LIS.Core.IdentityModel.ApplicationDbContext context)
        {
            //Default Admin/User Account and Roles
            IdentitySeed.SeedData(context);
            //Default Authorization Seed
            Authorizationseed.SeedData(context);
            //Default API Authorization Seed
            APIAuthorizationSeedData.SeedData(context);
            //Default ApplicationSetting Data
            ApplicationSettingSeed.SeedData(context);
            }
    }
}
