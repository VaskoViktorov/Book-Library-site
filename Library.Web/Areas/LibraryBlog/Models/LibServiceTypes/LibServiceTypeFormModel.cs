namespace Library.Web.Areas.LibraryBlog.Models.LibServiceTypes
{

    using Resources.Areas.LibraryBlog.Models.LibServiceTypes;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class LibServiceTypeFormModel
    {
        [Required(ErrorMessageResourceName = "RequiredErrorMsg", ErrorMessageResourceType = typeof(LibServiceTypeFormModelResx))]
        [MinLength(LibServiceTypeMinLength, ErrorMessageResourceName = "MinLengthErrorMsg", ErrorMessageResourceType = typeof(LibServiceTypeFormModelResx))]
        [MaxLength(LibServiceTypeMaxLength, ErrorMessageResourceName = "MaxLengthErrorMsg", ErrorMessageResourceType = typeof(LibServiceTypeFormModelResx))]
        [Display(Name = "ServiceNameBg", ResourceType = typeof(LibServiceTypeFormModelResx))]
        public string ServiceNameBg { get; set; }

        [Required(ErrorMessageResourceName = "RequiredErrorMsg", ErrorMessageResourceType = typeof(LibServiceTypeFormModelResx))]
        [MinLength(LibServiceTypeMinLength, ErrorMessageResourceName = "MinLengthErrorMsg", ErrorMessageResourceType = typeof(LibServiceTypeFormModelResx))]
        [MaxLength(LibServiceTypeMaxLength, ErrorMessageResourceName = "MaxLengthErrorMsg", ErrorMessageResourceType = typeof(LibServiceTypeFormModelResx))]
        [Display(Name = "ServiceNameEn", ResourceType = typeof(LibServiceTypeFormModelResx))]
        public string ServiceNameEn { get; set; }

        [Required(ErrorMessageResourceName = "RequiredErrorMsg", ErrorMessageResourceType = typeof(LibServiceTypeFormModelResx))]
        [Display(Name = "Order", ResourceType = typeof(LibServiceTypeFormModelResx))]
        public int Order { get; set; }

    }
}
