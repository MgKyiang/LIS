using LIS.Core.IdentityModel;
using LIS.Repository.UnitOfWorkContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LIS.Repository.AdminRepository.AdminContract;
using LIS.Repository.AdminRepository;
using LIS.Repository.DomainRepository.DomainContract;
using LIS.Repository.CommonRepository;
using System.Data.Entity;
using LIS.Repository.DomainRepository;

namespace LIS.Repository.UnitOfWorkImp {
    //IMPLEMENT the interface tell HOW TO DO in the system.
    public class UnitOfWork : IUnitOfWork {
        //Application Db context is here.
        protected readonly ApplicationDbContext dbContext;
        //DbContextTransaction is here.
        private DbContextTransaction dbContextTransaction;
        //Constructor is here with dbContext DI
        public UnitOfWork() {
            dbContext =new ApplicationDbContext();
            //Admin Repo
            Authorizations = new AuthorizationsRepository(dbContext);
            AppSettings = new ApplicationSettingRepository(dbContext);
            ContactUs = new ContactUsRepository(dbContext);
            TransactionLogs = new TransactionLogRepository(dbContext);
            ErrorLogs = new ErrorLogRepository(dbContext);
            APIAuthorizations = new APIAuthorizationRepository(dbContext);
            //Domain Repo
            LotteryAlphabets = new LotteryAlphabetRepository(dbContext);
            LotteryPrizeTypes = new LotteryPrizeTypeRepository(dbContext);
            LotteryPrizes = new LotteryPrizeRepository(dbContext);
            Customers = new CustomerRepository(dbContext);
            LotterySales = new LotterySalePrizeRepository(dbContext);
            LotteryCheckings = new LotteryCheckingRepository(dbContext);
            }

        public IApplicationSettingRepository AppSettings { get; private set; }
        public IAuthorizationsRepository Authorizations { get; private set; }
        public IContactUsRepository ContactUs { get; private set; }
        public IErrorLogRepository ErrorLogs { get; private set; }
        public ITransactionLogRepository TransactionLogs { get; private set; }
        public IAPIAuthorizationRepository APIAuthorizations { get;set;          }
        public ILotteryAlphabetRepository LotteryAlphabets { get; set; }
        public ILotteryPrizeTypeRepository LotteryPrizeTypes { get;set;}
        public ILotteryPrizeRepository LotteryPrizes { get;set;}
        public ICustomerRepository Customers { get;set;}
        public ILotterySaleRepository LotterySales {get; }
        public ILotteryCheckingRepository LotteryCheckings { get;set;}

        //submit the data to the database
        public bool Save() {
            try {
                dbContext.SaveChanges();
                return true;
                }
            catch (Exception e) {
                return false;
                }
            }
        //dispose(close) the dbcontext.
        public void Dispose() {
            dbContext.Dispose();
            }

        /// <summary>
        /// DbContext BeginTransaction
        /// </summary>
        public void BeginTransaction() {
            dbContextTransaction = dbContext.Database.BeginTransaction();
            }
        /// <summary>
        /// DbContext Commit Transaction
        /// </summary>
        public void Commit() {
            dbContextTransaction.Commit();
            }
        /// <summary>
        /// DbContext RollBack Transaction
        /// </summary>
        public void Rollback() {
            dbContextTransaction.Rollback();
            }
        }
    }
