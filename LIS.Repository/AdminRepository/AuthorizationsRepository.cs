
using LIS.Core.DataModel;
using LIS.Core.IdentityModel;
using LIS.Repository.AdminRepository.AdminContract;
using LIS.Repository.CommonRepository;
using System.Collections.Generic;
using System.Linq;
namespace LIS.Repository.AdminRepository {
    public class AuthorizationsRepository : Repository<Authorizations>, IAuthorizationsRepository
    {
        public ApplicationDbContext ApplicationDbContext
        {
            get { return dbContext as ApplicationDbContext; }
        }
        public AuthorizationsRepository(ApplicationDbContext _dbContext) : base(_dbContext)
        {
        }
        //define Customize method
        public List<Authorizations> GetControllerAndAction()
        { 
            var data = ApplicationDbContext.Authorizations.Where(x => x.Active).ToList();
            var filterData = data.AsEnumerable().Select(x => new Authorizations()
            {
                ControllerName = x.ControllerName,
                ActionName = x.ActionName
            }).ToList();

            return filterData;
        }
    }
}
