namespace Library.Web.Areas.LibraryBlog.Models.Departments
{
    using Data.Models;
    using Resources.Areas.LibraryBlog.Models.Departments;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class DepartmentFormModel
    {
        [Required(ErrorMessageResourceName = "RequiredErrorMsg", ErrorMessageResourceType = typeof(DepartmentFormModelResx))]
        [MinLength(DepartmentStructureDepartmentUnitMinLength, ErrorMessageResourceName = "MinLengthErrorMsg", ErrorMessageResourceType = typeof(DepartmentFormModelResx))]
        [MaxLength(DepartmentStructureDepartmentUnitMaxLength, ErrorMessageResourceName = "MaxLengthErrorMsg", ErrorMessageResourceType = typeof(DepartmentFormModelResx))]
        [Display(Name = "DepartmentBg", ResourceType = typeof(DepartmentFormModelResx))]
        public string DepartmentUnitBg { get; set; }

        [Required(ErrorMessageResourceName = "RequiredErrorMsg", ErrorMessageResourceType = typeof(DepartmentFormModelResx))]
        [MinLength(DepartmentStructureDepartmentUnitMinLength, ErrorMessageResourceName = "MinLengthErrorMsg", ErrorMessageResourceType = typeof(DepartmentFormModelResx))]
        [MaxLength(DepartmentStructureDepartmentUnitMaxLength, ErrorMessageResourceName = "MaxLengthErrorMsg", ErrorMessageResourceType = typeof(DepartmentFormModelResx))]
        [Display(Name = "DepartmentEn", ResourceType = typeof(DepartmentFormModelResx))]
        public string DepartmentUnitEn { get; set; }

        [Required(ErrorMessageResourceName = "RequiredErrorMsg", ErrorMessageResourceType = typeof(DepartmentFormModelResx))]
        [MaxLength(DepartmentStructureDepartmentEmailMaxLength, ErrorMessageResourceName = "MaxLengthErrorMsg", ErrorMessageResourceType = typeof(DepartmentFormModelResx))]
        [Display(Name = "DepartmentEmail", ResourceType = typeof(DepartmentFormModelResx))]
        public string DepartmentEmail { get; set; }

        [Required(ErrorMessageResourceName = "RequiredErrorMsg", ErrorMessageResourceType = typeof(DepartmentFormModelResx))]
        [Display(Name = "DepartmentStructureType", ResourceType = typeof(DepartmentFormModelResx))]
        public DepartmentStructureType DepartmentStructureType { get; set; }
    }
}
