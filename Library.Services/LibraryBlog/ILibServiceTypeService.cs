namespace Library.Services.LibraryBlog
{
    using Library.Services.LibraryBlog.Models.LibServiceTypes;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface ILibServiceTypeService
    {

        Task CreateAsync(
            string serviceNameBg,
            string serviceNameEn,
            int order);

        Task EditAsync(
            int id,
            string serviceNameBg,
            string serviceNameEn,
            int order);

        Task DeleteAsync(int id);

        Task<LibServiceTypeServiceModel> ByIdAsync(int id);

        Task<IEnumerable<LibServiceTypeServiceModel>> AllLibServiceTypeAsync();
    }
}
