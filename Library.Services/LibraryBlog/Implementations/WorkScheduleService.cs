namespace Library.Services.LibraryBlog.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Data.Models;
    using Library.Services.LibraryBlog.Models.DepartmentStructure;
    using Library.Services.LibraryBlog.Models.WorkSchedules;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public class WorkScheduleService : IWorkScheduleService
    {
        private readonly LibraryDbContext db;

        public WorkScheduleService(LibraryDbContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(string departmentNameBg,
            string departmentNameEn,
            string workdaysBg,
            string workdaysEn,
            string saturdayBg,
            string saturdayEn,
            string sundayBg,
            string sundayEn)
        {
            var workSchedule = new WorkSchedule
            {
                DepartmentNameBg = departmentNameBg,
                DepartmentNameEn = departmentNameEn,
                WorkdaysBg = workdaysBg,
                WorkdaysEn = workdaysEn,
                SaturdayBg = saturdayBg,
                SaturdayEn = saturdayEn,
                SundayBg = sundayBg,
                SundayEn = sundayEn
            };

            db.Add(workSchedule);
            await db.SaveChangesAsync();
        }


        public async Task EditAsync(int id, 
            string departmentNameBg,
            string departmentNameEn,
            string workdaysBg,
            string workdaysEn,
            string saturdayBg,
            string saturdayEn,
            string sundayBg,
            string sundayEn)
        {
            var workSchedule = await db.WorkSchedules.FindAsync(id);

            if (workSchedule == null)
            {
                return;
            }

            workSchedule.DepartmentNameBg = departmentNameBg;
            workSchedule.DepartmentNameEn = departmentNameEn;
            workSchedule.WorkdaysBg = workdaysBg;
            workSchedule.WorkdaysEn = workdaysEn;
            workSchedule.SaturdayBg = saturdayBg;
            workSchedule.SaturdayEn = saturdayEn;
            workSchedule.SundayBg = sundayBg;
            workSchedule.SundayEn = sundayEn;

            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var workSchedule = await db.WorkSchedules.FindAsync(id);

            if (workSchedule == null)
            {
                return;
            }

            db.WorkSchedules.Remove(workSchedule);
            await db.SaveChangesAsync();
        }

        public async Task<WorkScheduleServiceModel> ByIdAsync(int id)
            => await db
                .WorkSchedules
                .Where(a => a.Id == id)
                .ProjectTo<WorkScheduleServiceModel>()
                .FirstOrDefaultAsync();

        public async Task<IEnumerable<WorkScheduleServiceModel>> AllWorkSchedulesAsync()
            => await db
                .WorkSchedules
                .ProjectTo<WorkScheduleServiceModel>()
                .ToListAsync();
    }
}
