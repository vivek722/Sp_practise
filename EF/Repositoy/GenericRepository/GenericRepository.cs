using Domain.Model;
using Domain.Model.BaseEntityModel;
using Domain.Service.genericService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Repositoy.GenericRepository
{
    public class GenericRepository<TModel> : IGenericRepository<TModel> where TModel : BaseEntity , new()
    {
        public GenericRepository()
        {
            
        }
        public Task<EmployeeEntity> addEmployee()
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeEntity> DeleteEmployee()
        {
            throw new NotImplementedException();
        }

        public Task<List<EmployeeEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeEntity> GetById()
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeEntity> UpdateEmployee()
        {
            throw new NotImplementedException();
        }
    }
}
