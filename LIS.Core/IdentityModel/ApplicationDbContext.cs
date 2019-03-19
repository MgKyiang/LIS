using LIS.Core.DataModel;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIS.Core.IdentityModel {
  public  class ApplicationDbContext: IdentityDbContext<ApplicationUser> {
        public ApplicationDbContext() : base("CloudBasedLIS") {
            }
        public static ApplicationDbContext Create() {
            return new ApplicationDbContext();
            }
        //Administration
        public DbSet<Authorizations> Authorizations { get; set; }
        public DbSet<TransactionLog> TransactionLogs { get; set; }
        public DbSet<UserInRole> UserInRole { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }
        public DbSet<ApplicationSetting> ApplicationSettings { get; set; }
        public DbSet<UsersMember> UsersMember { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<APIAuthorization> APIAuthorization { get; set; }
        //Domain Models
        public DbSet<LotteryAlphabet> LotteryAlphabet { get; set; }
        public DbSet<LotteryPrizeType> LotteryPrizeTypes { get; set; }
        public DbSet<LotteryPrize> LotteryPrizes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<LotterySale> LotterySales { get; set; }
        public DbSet<LotteryChecking> LotteryCheckings { get; set; }
        public DbSet<LotteryShopProfile> LotteryShopProfile { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            }
        }
    }
