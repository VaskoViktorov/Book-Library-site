namespace Library.Services.LibraryBlog
{
    using Data.Models;
    using Models.Employees;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IEmployeeService
    {

        Task CreateAsync(
            string employeeNameBg,
            string employeeNameEn,
            string employeePhoneNumbers,
            int employeeOrder,
            int employeeDepartmentStructureId);

        Task EditAsync(
            int id,
            string employeeNameBg,
            string employeeNameEn,
            string employeePhoneNumbers,
            int employeeOrder,
            int employeeDepartmentStructureId);

        Task DeleteAsync(int id);

        Task<EmployeeServiceModel> ByIdAsync(int id);

        Task<IEnumerable<EmployeeServiceModel>> AllEmployeesAsync();

        Task<IEnumerable<EmployeeServiceModel>> AllEmployeesByDepartmentStructureAsync(int employeeDepartmentStructureId);

    }
}

