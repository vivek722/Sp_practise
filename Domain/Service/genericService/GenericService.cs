using Domain.Model;
using Domain.Model.BaseEntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.genericService
{
    public class GenericService<Tmodel> : IGenericService<Tmodel> where Tmodel : BaseEntity, new()
    {
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
