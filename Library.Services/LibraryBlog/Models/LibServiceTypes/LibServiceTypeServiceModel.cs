namespace Library.Services.LibraryBlog.Models.LibServiceTypes
{
    using Common.Mapping;
    using Data.Models;
    using System.Collections.Generic;

    public class LibServiceTypeServiceModel : IMapFrom<LibServiceType>
    {
        public int Id { get; set; }

        public string ServiceNameBg { get; set; }

        public string ServiceNameEn { get; set; }

        public int Order { get; set; }

        public List<LibServiceDescription> LibServiceDescriptions { get; set; } = new List<LibServiceDescription>();
    }
}
