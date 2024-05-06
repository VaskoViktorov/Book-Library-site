namespace Library.Services.LibraryBlog
{
    using Library.Services.LibraryBlog.Models.LibServiceDescriptions;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface ILibServiceDescriptionService
    {

        Task CreateAsync(
            string serviceTypeBg,
            string serviceTypeEn,
            string descriptionBg,
            string descriptionEn,
            string priceInfoBg,
            string priceInfoEn,
            int order,
            int libServiceTypeId);

        Task EditAsync(
            int id,
            string serviceTypeBg,
            string serviceTypeEn,
            string descriptionBg,
            string descriptionEn,
            string priceInfoBg,
            string priceInfoEn,
            int order,
            int libServiceTypeId);

        Task DeleteAsync(int id);

        Task<LibServiceDescriptionServiceModel> ByIdAsync(int id);

        Task<IEnumerable<LibServiceDescriptionServiceModel>> AllLibServiceDescriptionAsync();
    }
}
