namespace Library.Services.LibraryBlog.Models.WorkSchedules
{
    using Common.Mapping;
    using Data.Models;
    public class WorkScheduleServiceModel : IMapFrom<WorkSchedule>
    {
        public int Id { get; set; }

        public string DepartmentNameBg { get; set; }

        public string DepartmentNameEn { get; set; }

        public string WorkdaysBg { get; set; }

        public string WorkdaysEn { get; set; }

        public string SaturdayBg { get; set; }

        public string SaturdayEn { get; set; }

        public string SundayBg { get; set; }

        public string SundayEn { get; set; }
    }
}
