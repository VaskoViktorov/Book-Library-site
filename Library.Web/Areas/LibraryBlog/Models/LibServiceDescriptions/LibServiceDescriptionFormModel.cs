namespace Library.Web.Areas.LibraryBlog.Models.LibServiceDescriptions
{
    using Library.Services.LibraryBlog.Models.LibServiceTypes;
    using Resources.Areas.LibraryBlog.Models.LibServiceDescriptions;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class LibServiceDescriptionFormModel
    {
        [Required(ErrorMessageResourceName = "RequiredErrorMsg", ErrorMessageResourceType = typeof(LibServiceDescriptionFormModelResx))]
        [MinLength(ServiceTypeMinLength, ErrorMessageResourceName = "MinLengthErrorMsg", ErrorMessageResourceType = typeof(LibServiceDescriptionFormModelResx))]
        [MaxLength(ServiceTypeMaxLength, ErrorMessageResourceName = "MaxLengthErrorMsg", ErrorMessageResourceType = typeof(LibServiceDescriptionFormModelResx))]
        [Display(Name = "ServiceTypeBg", ResourceType = typeof(LibServiceDescriptionFormModelResx))]
        public string ServiceTypeBg { get; set; }

        [Required(ErrorMessageResourceName = "RequiredErrorMsg", ErrorMessageResourceType = typeof(LibServiceDescriptionFormModelResx))]
        [MinLength(ServiceTypeMinLength, ErrorMessageResourceName = "MinLengthErrorMsg", ErrorMessageResourceType = typeof(LibServiceDescriptionFormModelResx))]
        [MaxLength(ServiceTypeMaxLength, ErrorMessageResourceName = "MaxLengthErrorMsg", ErrorMessageResourceType = typeof(LibServiceDescriptionFormModelResx))]
        [Display(Name = "ServiceTypeEn", ResourceType = typeof(LibServiceDescriptionFormModelResx))]
        public string ServiceTypeEn { get; set; }

        [MaxLength(DescriptionMaxLength, ErrorMessageResourceName = "MaxLengthErrorMsg", ErrorMessageResourceType = typeof(LibServiceDescriptionFormModelResx))]
        [Display(Name = "DescriptionBg", ResourceType = typeof(LibServiceDescriptionFormModelResx))]
        public string DescriptionBg { get; set; }

        [MaxLength(DescriptionMaxLength, ErrorMessageResourceName = "MaxLengthErrorMsg", ErrorMessageResourceType = typeof(LibServiceDescriptionFormModelResx))]
        [Display(Name = "DescriptionEn", ResourceType = typeof(LibServiceDescriptionFormModelResx))]
        public string DescriptionEn { get; set; }

        [MaxLength(PriceInfoMaxLength, ErrorMessageResourceName = "MaxLengthErrorMsg", ErrorMessageResourceType = typeof(LibServiceDescriptionFormModelResx))]
        [Display(Name = "PriceInfoBg", ResourceType = typeof(LibServiceDescriptionFormModelResx))]
        public string PriceInfoBg { get; set; }

        [MaxLength(PriceInfoMaxLength, ErrorMessageResourceName = "MaxLengthErrorMsg", ErrorMessageResourceType = typeof(LibServiceDescriptionFormModelResx))]
        [Display(Name = "PriceInfoEn", ResourceType = typeof(LibServiceDescriptionFormModelResx))]
        public string PriceInfoEn { get; set; }

        [Required(ErrorMessageResourceName = "RequiredErrorMsg", ErrorMessageResourceType = typeof(LibServiceDescriptionFormModelResx))]
        [Display(Name = "Order", ResourceType = typeof(LibServiceDescriptionFormModelResx))]
        public int Order { get; set; }

        [Display(Name = "LibServiceTypeId", ResourceType = typeof(LibServiceDescriptionFormModelResx))]
        public int LibServiceTypeId { get; set; }

        [Display(Name = "LibServiceTypes", ResourceType = typeof(LibServiceDescriptionFormModelResx))]
        public List<LibServiceTypeServiceModel> LibServiceTypes { get; set; }
    }
}
