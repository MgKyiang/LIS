using LIS.Core.DataModel;
using LIS.Repository.CommonRepository;
using LIS.Repository.DomainRepository.DomainContract;
using System.Data.Entity;
using LIS.Core.IdentityModel;
using System;
using System.Linq;
using System.Collections.Generic;

namespace LIS.Repository.DomainRepository {
    public class CustomerRepository : Repository<Customer>, ICustomerRepository {
        public ApplicationDbContext AppDbContext {
            get { return dbContext as ApplicationDbContext; }
            }
        public CustomerRepository(DbContext _dbContext) : base(_dbContext) {
            }
        //define Customize method
        public  Customer getCustomerByName(string Name) {
            return AppDbContext.Customers.Where(x => x.Name == Name).SingleOrDefault();
            }
        }
    }
