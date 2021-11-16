using EmployeeWebApi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeWebApi.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeEntity>> Get();
        Task<EmployeeEntity> GetEmployeeById(int Empid);
        Task<int> AddNewEmployee(EmployeeEntity employeeEntity);
        Task Update(int Empid, EmployeeEntity employeeEntity);
        Task Delete(int Empid);
    }
}