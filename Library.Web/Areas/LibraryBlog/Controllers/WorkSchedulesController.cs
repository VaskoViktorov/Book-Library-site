namespace Library.Web.Areas.LibraryBlog.Controllers
{
    using Infrastructure.Extensions;
    using Infrastructure.Filters;
    using Library.Services.LibraryBlog;
    using Library.Web.Areas.LibraryBlog.Models.WorkSchedules;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    using static WebConstants;

    public class WorkSchedulesController : BaseController
    {
        private const string ModelName = WorkScheduleBgModelName;

        private readonly IWorkScheduleService workSchedules;

        public WorkSchedulesController(IWorkScheduleService workSchedules)
        {
            this.workSchedules = workSchedules;
        }

        [AllowAnonymous]
        public async Task<IActionResult> WorkSchedules()
        {
            return this.View(new WorkScheduleListingViewModel
            {
                WorkSchedules = await this.workSchedules.AllWorkSchedulesAsync()
        
            });
        }


        public IActionResult Create()
            => this.View();

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Create(WorkScheduleFormModel model)
        {
            await this.workSchedules.CreateAsync(
                model.DepartmentNameBg,
                model.DepartmentNameEn,
                model.WorkdaysBg,
                model.WorkdaysEn,
                model.SaturdayBg,
                model.SaturdayEn,
                model.SundayBg,
                model.SundayEn
              );

            this.TempData.AddSuccessMessage(string.Format(TempDataCreateCommentText, ModelName, ""));

            return this.RedirectToAction(nameof(this.workSchedules));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var workSchedules = await this.workSchedules.ByIdAsync(id);
        
            if (workSchedules == null)
            {
                return this.NotFound();
            }
        
            return this.View(new WorkScheduleFormModel
            {
                DepartmentNameBg = workSchedules.DepartmentNameBg,
                DepartmentNameEn = workSchedules.DepartmentNameEn,
                WorkdaysBg = workSchedules.WorkdaysBg,
                WorkdaysEn = workSchedules.WorkdaysEn,
                SaturdayBg = workSchedules.SaturdayBg,
                SaturdayEn = workSchedules.SaturdayEn,
                SundayBg = workSchedules.SundayBg,
                SundayEn = workSchedules.SundayEn
            });
        }
        
        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Edit(int id, WorkScheduleFormModel model)
        {
        
            await this.workSchedules.EditAsync(
                id,
                model.DepartmentNameBg,
                model.DepartmentNameEn,
                model.WorkdaysBg,
                model.WorkdaysEn,
                model.SaturdayBg,
                model.SaturdayEn,
                model.SundayBg,
                model.SundayEn
                );
        
            this.TempData.AddSuccessMessage(string.Format(TempDataEditCommentText, ModelName, ""));
        
            return this.RedirectToAction(nameof(this.workSchedules));
        }
        public IActionResult Delete(WorkScheduleDeleteViewModel model)
            => this.View(model);
        
        public async Task<IActionResult> Destroy(int id)
        {
            await this.workSchedules.DeleteAsync(id);
        
            this.TempData.AddSuccessMessage(string.Format(TempDataDeleteCommentText, ModelName, ""));
        
            return this.RedirectToAction(nameof(this.workSchedules));
        }
    }
}
