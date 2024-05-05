namespace Library.Services.LibraryBlog.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Data.Models;
    using Models.Employees;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    internal class EmployeeService : IEmployeeService
    {
        private readonly LibraryDbContext db;

        public EmployeeService(LibraryDbContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(string employeeNameBg, string employeeNameEn, string employeePhoneNumbers, int employeeOrder, int employeeDepartmentStructureId)
        {
            var employee = new Employee
            {
                NameBg = employeeNameBg,
                NameEn = employeeNameEn,
                PhoneNumbers = employeePhoneNumbers,
                Order = employeeOrder,
                DepartmentStructureId = employeeDepartmentStructureId
            };

            db.Add(employee);
            await db.SaveChangesAsync();
        }


        public async Task EditAsync(int id, string employeeNameBg, string employeeNameEn, string employeePhoneNumbers, int employeeOrder, int employeeDepartmentStructureId)
        {
            var employee = await db.Employees.FindAsync(id);

            if (employee == null)
            {
                return;
            }

            employee.NameBg = employeeNameBg;
            employee.NameEn = employeeNameEn;
            employee.PhoneNumbers = employeePhoneNumbers;
            employee.Order = employeeOrder;
            employee.DepartmentStructureId = employeeDepartmentStructureId;

            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var employee = await db.Employees.FindAsync(id);

            if (employee == null)
            {
                return;
            }

            db.Employees.Remove(employee);
            await db.SaveChangesAsync();
        }

        public async Task<EmployeeServiceModel> ByIdAsync(int id)
            => await db
                .Employees
                .Where(a => a.Id == id)
                .ProjectTo<EmployeeServiceModel>()
                .FirstOrDefaultAsync();

        public async Task<IEnumerable<EmployeeServiceModel>> AllEmployeesAsync()
            => await db
                .Employees
                .ProjectTo<EmployeeServiceModel>()
                .ToListAsync();

        public async Task<IEnumerable<EmployeeServiceModel>> AllEmployeesByDepartmentStructureAsync(int employeeDepartmentStructureId)
            => await db
                .Employees
                .Where(b => b.DepartmentStructureId == employeeDepartmentStructureId)
                .ProjectTo<EmployeeServiceModel>()
                .ToListAsync();

    }
}
