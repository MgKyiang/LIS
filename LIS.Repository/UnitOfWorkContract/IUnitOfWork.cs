using LIS.Repository.AdminRepository.AdminContract;
using LIS.Repository.DomainRepository.DomainContract;
using System;

namespace LIS.Repository.UnitOfWorkContract {
    //ABSTRATION tell WHAT the system do.
    public interface IUnitOfWork : IDisposable {
        //Admin Contract
        IAuthorizationsRepository Authorizations { get; }
        IApplicationSettingRepository AppSettings { get; }
        IContactUsRepository ContactUs { get; }
        ITransactionLogRepository TransactionLogs { get; }
        IErrorLogRepository ErrorLogs { get; }
        IAPIAuthorizationRepository APIAuthorizations { get; }
        //Domain Contract
        ILotteryAlphabetRepository LotteryAlphabets { get; }
        ILotteryPrizeTypeRepository LotteryPrizeTypes { get; }
        ILotteryPrizeRepository LotteryPrizes { get; set; }
         ICustomerRepository Customers { get; }
        ILotterySaleRepository LotterySales { get; }
        ILotteryCheckingRepository LotteryCheckings { get; }
        bool Save();
        }
    }
