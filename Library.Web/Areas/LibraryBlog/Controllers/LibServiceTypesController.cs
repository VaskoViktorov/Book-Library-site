namespace Library.Web.Areas.LibraryBlog.Controllers
{
    using Infrastructure.Extensions;
    using Infrastructure.Filters;
    using Library.Services.LibraryBlog;
    using Library.Web.Areas.LibraryBlog.Models.LibServiceTypes;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    using static WebConstants;

    public class LibServiceTypesController : BaseController
    {
        private const string ModelName = LibServiceTypeBgModelName;

        private readonly ILibServiceTypeService libservicetypes;

        public LibServiceTypesController(ILibServiceTypeService libservicetypes)
        {
            this.libservicetypes = libservicetypes;
        }

        [AllowAnonymous]
        public async Task<IActionResult> LibServiceTypes()
        {
            return this.View(new LibServiceTypeListingViewModel
            {
                LibServiceTypes = await this.libservicetypes.AllLibServiceTypeAsync()
        
            });
        }


        public IActionResult Create()
            => this.View();

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Create(LibServiceTypeFormModel model)
        {
            await this.libservicetypes.CreateAsync(
                model.ServiceNameBg,
                model.ServiceNameEn,
                model.Order
              );

            this.TempData.AddSuccessMessage(string.Format(TempDataCreateCommentText, ModelName, ""));

            return this.RedirectToAction(nameof(this.LibServiceTypes));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var libservicetype = await this.libservicetypes.ByIdAsync(id);
       
            if (libservicetype == null)
            {
                return this.NotFound();
            }
       
            return this.View(new LibServiceTypeFormModel
            {
                ServiceNameBg = libservicetype.ServiceNameBg,
                ServiceNameEn = libservicetype.ServiceNameEn,
                Order = libservicetype.Order
            });
        }
       
        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Edit(int id, LibServiceTypeFormModel model)
        {
       
            await this.libservicetypes.EditAsync(
                id,
                model.ServiceNameBg,
                model.ServiceNameEn,
                model.Order
                );
       
            this.TempData.AddSuccessMessage(string.Format(TempDataEditCommentText, ModelName, ""));
       
            return this.RedirectToAction(nameof(this.LibServiceTypes));
        }

       public IActionResult Delete(LibServiceTypeDeleteViewModel model)
           => this.View(model);
       
       public async Task<IActionResult> Destroy(int id)
       {
           await this.libservicetypes.DeleteAsync(id);
                  this.TempData.AddSuccessMessage(string.Format(TempDataDeleteCommentText, ModelName, ""));
                  return this.RedirectToAction(nameof(this.LibServiceTypes));
       }
    }
}
