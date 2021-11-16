using EmployeeWebApi.Entities;
using EmployeeWebApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebApi.Repositories
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly WebApiDbContext _context;

        public EmployeeRepository(WebApiDbContext context)
        {
            _context = context;
        }

        public async Task<List<EmployeeEntity>> Get()
        {
            var records = await _context.Employees.Select(x => new EmployeeEntity()
            {
                EmployeeId = x.EmployeeId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                EmpCode = x.EmpCode,
                Position = x.Position,
                Office = x.Office
            }).ToListAsync();
            return records;

        }

        public async Task<EmployeeEntity> GetEmployeeById(int Empid)
        {
            var record = await _context.Employees.Where(x => x.EmployeeId == Empid).Select(x => new EmployeeEntity()
            {
                EmployeeId = x.EmployeeId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                EmpCode = x.EmpCode,
                Position = x.Position,
                Office = x.Office

            }).FirstOrDefaultAsync();
            return record;

        }

        public async Task<int> AddNewEmployee(EmployeeEntity employeeEntity)
        {
            var employee = new Employee()
            {

               FirstName=employeeEntity.FirstName,
               LastName=employeeEntity.LastName,
               EmpCode=employeeEntity.EmpCode,
               Position=employeeEntity.Position,
               Office=employeeEntity.Office

            };
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee.EmployeeId;
        }
        public async Task Update(int Empid, EmployeeEntity employeeEntity)
        {
            var employee = await _context.Employees.FindAsync(Empid);
            if (employee != null)
            {
                employee.FirstName = employeeEntity.FirstName;
                employee.LastName = employeeEntity.LastName;
                employee.EmpCode = employeeEntity.EmpCode;
                employee.Position = employeeEntity.Position;
                employee.Office = employeeEntity.Office;
                await _context.SaveChangesAsync();
            }


        }

        public async Task Delete(int Empid)
        {
            var employee = new Employee() { EmployeeId=Empid};
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

        }
    }
}
