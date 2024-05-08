namespace Library.Web.Areas.LibraryBlog.Models.WorkSchedules
{
    using Library.Services.LibraryBlog.Models.WorkSchedules;
    using System.Collections.Generic;
    public class WorkScheduleListingViewModel
    {
        public IEnumerable<WorkScheduleServiceModel> WorkSchedules { get; set; }
    }
}
