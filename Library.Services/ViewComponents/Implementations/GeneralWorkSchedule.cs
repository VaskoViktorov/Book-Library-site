namespace Library.Services.ViewComponents.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Library.Services.LibraryBlog.Models.WorkSchedules;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;

    public class GeneralWorkSchedule : IGeneralWorkSchedule
    {
        private readonly LibraryDbContext db;

        public GeneralWorkSchedule(LibraryDbContext db)
        {
            this.db = db;
        }

        public async Task<WorkScheduleServiceModel> ByGenralNameAsync(string departmentNameEn)
            => await this.db
                .WorkSchedules
                .Where(a => a.DepartmentNameEn == departmentNameEn)
                .ProjectTo<WorkScheduleServiceModel>()
                .FirstOrDefaultAsync();

    }
}
