namespace Library.Services.ViewComponents
{
    using Library.Services.LibraryBlog.Models.WorkSchedules;
    using System.Threading.Tasks;

    public interface IGeneralWorkSchedule
    {
        Task<WorkScheduleServiceModel> ByGenralNameAsync(string departmentNameEn = "General");
    }
}
