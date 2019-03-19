
using LIS.Core.DataModel;
using LIS.Core.IdentityModel;
using LIS.Repository.AdminRepository.AdminContract;
using LIS.Repository.CommonRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIS.Repository.AdminRepository {
    public class ContactUsRepository : Repository<ContactUs>, IContactUsRepository
    {
        public ApplicationDbContext ApplicationDbContext
        {
            get { return dbContext as ApplicationDbContext; }
        }
        public ContactUsRepository(ApplicationDbContext _dbContext) : base(_dbContext)
        {
        }
    }
}
