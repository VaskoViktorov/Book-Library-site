namespace Library.Web.Areas.LibraryBlog.Controllers
{
    using Infrastructure.Extensions;
    using Infrastructure.Filters;
    using Library.Services.LibraryBlog;
    using Library.Web.Areas.LibraryBlog.Models.LibServiceDescriptions;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using static WebConstants;

    public class LibServiceDescriptionsController : BaseController
    {
        private const string ModelName = EmployeeBgModelName;

        private readonly ILibServiceDescriptionService libservicedescriptions;
        private readonly ILibServiceTypeService libservicetypes;

        public LibServiceDescriptionsController(ILibServiceDescriptionService libservicedescriptions, ILibServiceTypeService libservicetypes)
        {
            this.libservicedescriptions = libservicedescriptions;
            this.libservicetypes = libservicetypes;
        }

        public async Task<IActionResult> Create()
        {
            var allLibServiceTypes = await this.libservicetypes.AllLibServiceTypeAsync();
            LibServiceDescriptionFormModel model = new LibServiceDescriptionFormModel();
            model.LibServiceTypes = (List<Services.LibraryBlog.Models.LibServiceTypes.LibServiceTypeServiceModel>)allLibServiceTypes;
            return this.View(model);
        }

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Create(LibServiceDescriptionFormModel model)
        {
        
            await this.libservicedescriptions.CreateAsync(
                model.ServiceTypeBg,
                model.ServiceTypeEn,
                model.DescriptionBg,
                model.DescriptionEn,
                model.PriceInfoBg,
                model.PriceInfoEn,
                model.Order,
                model.LibServiceTypeId
              );
        
            this.TempData.AddSuccessMessage(string.Format(TempDataCreateCommentText, ModelName, ""));
        
            return RedirectToAction(nameof(LibServiceTypesController.LibServiceTypes), "libservicetypes", null);
        }
        
        public async Task<IActionResult> Edit(int id)
        {
            var libServiceDescription = await this.libservicedescriptions.ByIdAsync(id);
        
            if (libServiceDescription == null)
            {
                return this.NotFound();
            }
            var allLibServiceTypes = await this.libservicetypes.AllLibServiceTypeAsync();
            var listLibServiceTypes = (List<Services.LibraryBlog.Models.LibServiceTypes.LibServiceTypeServiceModel>)allLibServiceTypes;
            return this.View(new LibServiceDescriptionFormModel
            {
                ServiceTypeBg = libServiceDescription.ServiceTypeBg,
                ServiceTypeEn = libServiceDescription.ServiceTypeEn,
                DescriptionBg = libServiceDescription.DescriptionBg,
                DescriptionEn = libServiceDescription.DescriptionEn,
                PriceInfoBg = libServiceDescription.PriceInfoBg,
                PriceInfoEn = libServiceDescription.PriceInfoEn,
                Order = libServiceDescription.Order,
                LibServiceTypes = listLibServiceTypes
            });
        }
        
        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Edit(int id, LibServiceDescriptionFormModel model)
        {
        
            await this.libservicedescriptions.EditAsync(
                id,
                model.ServiceTypeBg,
                model.ServiceTypeEn,
                model.DescriptionBg,
                model.DescriptionEn,
                model.PriceInfoBg,
                model.PriceInfoEn,
                model.Order,
                model.LibServiceTypeId
                );
        
            this.TempData.AddSuccessMessage(string.Format(TempDataEditCommentText, ModelName, ""));
        
            return RedirectToAction(nameof(LibServiceTypesController.LibServiceTypes), "libservicetypes", null);
        }
        public IActionResult Delete(LibServiceDescriptionDeleteViewModel model)
            => this.View(model);
        
        public async Task<IActionResult> Destroy(int id)
        {
            await this.libservicedescriptions.DeleteAsync(id);
        
            this.TempData.AddSuccessMessage(string.Format(TempDataDeleteCommentText, ModelName, ""));
        
            return RedirectToAction(nameof(LibServiceTypesController.LibServiceTypes), "libservicetypes", null);
        }
    }
}
