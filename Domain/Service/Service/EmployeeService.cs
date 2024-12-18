using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public Task<int> addEmployee(EmployeeEntity employeeEntity)
        {
            return _employeeRepository.addEmployee(employeeEntity);
        }

        public Task<int> DeleteEmployee(int id)
        {
            return _employeeRepository.DeleteEmployee(id);
        }

        public Task<List<EmployeeEntity>> GetAll()
        {
            return _employeeRepository.GetAll();
        }

        public Task<EmployeeEntity> GetById(int id)
        {
            return _employeeRepository.GetById(id);
        }

        public Task<List<EmployeeEntity>> SearchString(string search)
        {
            return _employeeRepository.SearchString(search);
        }

        public Task<int> UpdateEmployee(EmployeeEntity employeeEntity)
        {
            return _employeeRepository.UpdateEmployee(employeeEntity);
        }
    }
}
