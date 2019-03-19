
using CloudBasedRMS.GenericRepositories;
using LIS.Core.IdentityModel;
using LIS.Repository.CommonRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIS.Repository.AdminRepository {
   public class UsersMemberRepsitory:Repository<UsersMember>,IUsersMemberRepository
    {
        public ApplicationDbContext ApplicationDbContext
        {
            get { return dbContext as ApplicationDbContext; }
        }
        public UsersMemberRepsitory(ApplicationDbContext _dbContext) : base(_dbContext)
        {
        }
        //define Customize method
        public IEnumerable<UsersMember> GetByUserInMemberID(string UserInMemberID)
        {
            return ApplicationDbContext.UsersMember.Where(x => x.UserInMemberID == UserInMemberID);
        }
        public UsersMember GetByUserID(string UserID)
        {
            return ApplicationDbContext.UsersMember.Where(x => x.UserID == UserID).SingleOrDefault();
        }
    }
}
