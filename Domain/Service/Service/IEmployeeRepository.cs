using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Service
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeEntity>> GetAll();
        Task<EmployeeEntity> GetById(int id);
        Task<int> addEmployee(EmployeeEntity employeeEntity);
        Task<int> UpdateEmployee(EmployeeEntity employeeEntity);
        Task<int> DeleteEmployee(int id);
        Task<List<EmployeeEntity>> SearchString(string search);

    }
}
