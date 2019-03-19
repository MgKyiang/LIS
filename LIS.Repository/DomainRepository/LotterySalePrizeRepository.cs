using LIS.Core.DataModel;
using LIS.Repository.CommonRepository;
using LIS.Repository.DomainRepository.DomainContract;
using System.Data.Entity;
using LIS.Core.IdentityModel;

namespace LIS.Repository.DomainRepository {
    public class LotterySalePrizeRepository : Repository<LotterySale>, ILotterySaleRepository {
        public ApplicationDbContext AppDbContext {
            get { return dbContext as ApplicationDbContext; }
            }
        public LotterySalePrizeRepository(DbContext _dbContext) : base(_dbContext) {
            }
        }
    }
