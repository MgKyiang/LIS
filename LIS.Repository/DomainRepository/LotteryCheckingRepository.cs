using LIS.Core.DataModel;
using LIS.Repository.CommonRepository;
using LIS.Repository.DomainRepository.DomainContract;
using System.Data.Entity;
using LIS.Core.IdentityModel;

namespace LIS.Repository.DomainRepository {
    public class LotteryCheckingRepository : Repository<LotteryChecking>, ILotteryCheckingRepository {
        public ApplicationDbContext AppDbContext {
            get { return dbContext as ApplicationDbContext; }
            }
        public LotteryCheckingRepository(DbContext _dbContext) : base(_dbContext) {
            }
        }
    }
