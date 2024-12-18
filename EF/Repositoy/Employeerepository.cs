using Domain.Model;
using Domain.Service.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.EF.Repositoy
{
    public class Employeerepository : IEmployeeRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public Employeerepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> addEmployee(EmployeeEntity employeeEntity)
        {
    

            // Execute the stored procedure
            var result = await _dbContext.Database.ExecuteSqlRawAsync(
                "EXEC AddEmployeeWithSkills @name = {0}, @age = {1}, @mno = {2}, @Email_id = {3}, @Image = {4}, @IsActive = {5}",
                employeeEntity.name,
                employeeEntity.age,
                employeeEntity.mno,
                employeeEntity.emailid,
                employeeEntity.image,
                employeeEntity.IsActive
            );

            return result; 
        }

        public async Task<int> DeleteEmployee(int id)
        {
            var reuslt = await _dbContext.Database.ExecuteSqlRawAsync("EXEC Deleteemployee @id ={0}", id);
            return reuslt;
        }

        public async Task<List<EmployeeEntity>> GetAll()
        {
            var result = await _dbContext.Employees.FromSqlRaw("EXEC  EmployeeGetAll").ToListAsync();
            return result;
        }

        public async Task<EmployeeEntity> GetById(int id)
        {
            var result = await _dbContext.Employees.FromSqlRaw("EXEC employeegetbyId @id={0}", id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<List<EmployeeEntity>> SearchString(string search)
        {
            var result = await _dbContext.Employees.FromSqlRaw("EXEC SearchEmployee @Searchstring={0}",search).ToListAsync();
            return result;
        }

        public async Task<int> UpdateEmployee(EmployeeEntity employeeEntity)
        {
            var result = await _dbContext.Database.ExecuteSqlRawAsync("EXEC updateEmployee @id={0},@name={1},@age={2},@mno={3},@Emailid={4},@Image={5},@Isactive={6}",
                employeeEntity.id,
                employeeEntity.name,
                employeeEntity.age,
                employeeEntity.mno,
                employeeEntity.emailid,
                employeeEntity.image,
                employeeEntity.IsActive
                );
            return result;
        }
    }
}
