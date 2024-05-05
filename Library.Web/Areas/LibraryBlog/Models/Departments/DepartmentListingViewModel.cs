using Library.Services.LibraryBlog.Models.DepartmentStructure;
using System.Collections.Generic;

namespace Library.Web.Areas.LibraryBlog.Models.Departments
{
    public class DepartmentListingViewModel
    {
        public IEnumerable<DepartmentStructureServiceModel> Departments { get; set; }
    }
}
