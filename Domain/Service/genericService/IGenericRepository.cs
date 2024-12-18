using Domain.Model;
using Domain.Model.BaseEntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.genericService
{
    public interface IGenericRepository<TModel> where TModel : BaseEntity , new()
    {
        Task <List<EmployeeEntity>> GetAll();
        Task <EmployeeEntity> GetById();
        Task <EmployeeEntity> addEmployee();
        Task <EmployeeEntity> UpdateEmployee();
        Task <EmployeeEntity> DeleteEmployee();
    }
}
