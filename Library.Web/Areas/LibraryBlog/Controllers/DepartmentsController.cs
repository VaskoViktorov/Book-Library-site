namespace Library.Web.Areas.LibraryBlog.Controllers
{
    using Infrastructure.Extensions;
    using Infrastructure.Filters;
    using Library.Services.LibraryBlog;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models.Departments;
    using System.Threading.Tasks;

    using static WebConstants;

    public class DepartmentsController : BaseController
    {
        private const string ModelName = DepartmentBgModelName;

        private readonly IDepartmentStructureService departments;

        public DepartmentsController(IDepartmentStructureService departments)
        {
            this.departments = departments;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Departments(int page = 1)
        {
            return this.View(new DepartmentListingViewModel
            {
                Departments = await this.departments.AllDepartmentStrucutresAsync()

            });
        }


        public IActionResult Create()
            => this.View();

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Create(DepartmentFormModel model)
        {
            await this.departments.CreateAsync(
                model.DepartmentUnitBg,
                model.DepartmentUnitEn,
                model.DepartmentEmail,
                model.DepartmentStructureType
              );

            this.TempData.AddSuccessMessage(string.Format(TempDataCreateCommentText, ModelName, ""));

            return this.RedirectToAction(nameof(this.Departments));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var department = await this.departments.ByIdAsync(id);

            if (department == null)
            {
                return this.NotFound();
            }

            return this.View(new DepartmentFormModel
            {
                DepartmentUnitBg = department.DepartmentUnitBg,
                DepartmentUnitEn = department.DepartmentUnitEn,
                DepartmentEmail = department.DepartmentEmail,
                DepartmentStructureType = department.DepartmentStructureType
            });
        }

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Edit(int id, DepartmentFormModel model)
        {

            await this.departments.EditAsync(
                id,
                model.DepartmentUnitBg,
                model.DepartmentUnitEn,
                model.DepartmentEmail,
                model.DepartmentStructureType
                );

            this.TempData.AddSuccessMessage(string.Format(TempDataEditCommentText, ModelName, ""));

            return this.RedirectToAction(nameof(this.Departments));
        }
        public IActionResult Delete(DepartmentDeleteViewModel model)
            => this.View(model);

        public async Task<IActionResult> Destroy(int id)
        {
            await this.departments.DeleteAsync(id);

            this.TempData.AddSuccessMessage(string.Format(TempDataDeleteCommentText, ModelName, ""));

            return this.RedirectToAction(nameof(this.Departments));
        }
    }
}