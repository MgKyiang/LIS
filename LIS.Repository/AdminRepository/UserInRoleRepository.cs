

using LIS.Core.IdentityModel;
using LIS.Repository.AdminRepository.AdminContract;
using LIS.Repository.CommonRepository;

namespace LIS.Repository.AdminRepository {
    public class UserInRoleRepository : Repository<UserInRole>, IUserInRoleRepository
    {
        public UserInRoleRepository(ApplicationDbContext _dbContext) : base(_dbContext)
        {
        }
        //define Customize method
    }
}
