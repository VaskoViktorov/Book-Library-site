namespace Library.Services.LibraryBlog.Models.LibServiceDescriptions
{
    using Common.Mapping;
    using Data.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class LibServiceDescriptionServiceModel : IMapFrom<LibServiceDescription>
    {
        public int Id { get; set; }

        public string ServiceTypeBg { get; set; }

        public string ServiceTypeEn { get; set; }

        public string DescriptionBg { get; set; }

        public string DescriptionEn { get; set; }

        public string PriceInfoBg { get; set; }

        public string PriceInfoEn { get; set; }

        public int Order { get; set; }

        public int LibServiceTypeId { get; set; }
    }
}
