namespace Library.Web.Areas.LibraryBlog.Models.LibServiceTypes
{
    using Library.Services.LibraryBlog.Models.LibServiceTypes;
    using System.Collections.Generic;
    public class LibServiceTypeListingViewModel
    {
        public IEnumerable<LibServiceTypeServiceModel> LibServiceTypes { get; set; }
    }
}
