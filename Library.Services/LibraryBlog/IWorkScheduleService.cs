namespace Library.Services.LibraryBlog
{
    using Library.Services.LibraryBlog.Models.WorkSchedules;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IWorkScheduleService
    {
        Task CreateAsync(
            string departmentNameBg,
            string departmentNameEn,
            string workdaysBg,
            string workdaysEn,
            string saturdayBg,
            string saturdayEn,
            string sundayBg,
            string sundayEn);

        Task EditAsync(
            int id,
            string departmentNameBg,
            string departmentNameEn,
            string workdaysBg,
            string workdaysEn,
            string saturdayBg,
            string saturdayEn,
            string sundayBg,
            string sundayEn);

        Task DeleteAsync(int id);

        Task<WorkScheduleServiceModel> ByIdAsync(int id);

        Task<IEnumerable<WorkScheduleServiceModel>> AllWorkSchedulesAsync();
    }
}
