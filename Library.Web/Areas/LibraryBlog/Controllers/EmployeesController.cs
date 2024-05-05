namespace Library.Web.Areas.LibraryBlog.Controllers
{
    using Infrastructure.Extensions;
    using Infrastructure.Filters;
    using Library.Services.LibraryBlog;
    using Microsoft.AspNetCore.Mvc;
    using Models.Employees;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using static WebConstants;

    public class EmployeesController : BaseController
    {
        private const string ModelName = EmployeeBgModelName;

        private readonly IEmployeeService employees;
        private readonly IDepartmentStructureService departments;

        public EmployeesController(IEmployeeService employees, IDepartmentStructureService departments)
        {
            this.employees = employees;
            this.departments = departments;
        }

        public async Task<IActionResult> Create()
        {
            var allDepartments = await this.departments.AllDepartmentStrucutresAsync();
            EmployeeFormModel model = new EmployeeFormModel();
            model.DepartmentStructures = (List<Services.LibraryBlog.Models.DepartmentStructure.DepartmentStructureServiceModel>)allDepartments;
            return this.View(model);
        }

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Create(EmployeeFormModel model)
        {
            
            await this.employees.CreateAsync(
                model.EmployeeNameBg,
                model.EmployeeNameEn,
                model.EmployeePhoneNumbers,
                model.EmployeeOrder,
                model.EmployeeDepartmentStructureId
              );

            this.TempData.AddSuccessMessage(string.Format(TempDataCreateCommentText, ModelName, ""));

            return RedirectToAction(nameof(DepartmentsController.Departments), "departments", null);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var employee = await this.employees.ByIdAsync(id);
        
            if (employee == null)
            {
                return this.NotFound();
            }
            var allDepartments = await this.departments.AllDepartmentStrucutresAsync();
            var listDeepartments = (List<Services.LibraryBlog.Models.DepartmentStructure.DepartmentStructureServiceModel>)allDepartments;
            return this.View(new EmployeeFormModel
            {
                EmployeeNameBg = employee.NameBg,
                EmployeeNameEn = employee.NameEn,
                EmployeePhoneNumbers = employee.PhoneNumbers,
                EmployeeOrder = employee.Order,
                EmployeeDepartmentStructureId = employee.DepartmentStructureId,
                DepartmentStructures = listDeepartments
            });
        }
        
        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Edit(int id, EmployeeFormModel model)
        {
        
            await this.employees.EditAsync(
                id,
                model.EmployeeNameBg,
                model.EmployeeNameEn,
                model.EmployeePhoneNumbers,
                model.EmployeeOrder,
                model.EmployeeDepartmentStructureId
                );
        
            this.TempData.AddSuccessMessage(string.Format(TempDataEditCommentText, ModelName, ""));

            return RedirectToAction(nameof(DepartmentsController.Departments), "departments", null);
        }
        public IActionResult Delete(EmployeeDeleteViewModel model)
            => this.View(model);

        public async Task<IActionResult> Destroy(int id)
        {
            await this.employees.DeleteAsync(id);

            this.TempData.AddSuccessMessage(string.Format(TempDataDeleteCommentText, ModelName, ""));

            return RedirectToAction(nameof(DepartmentsController.Departments), "departments", null);
        }
    }
}