namespace Library.Web.Areas.LibraryBlog.Models.Employees
{
    using Data.Models;
    using Library.Services.LibraryBlog.Models.DepartmentStructure;
    using Resources.Areas.LibraryBlog.Models.Employees;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class EmployeeFormModel
    {
        [Required(ErrorMessageResourceName = "RequiredErrorMsg", ErrorMessageResourceType = typeof(EmployeeFormModelResx))]
        [MinLength(DepartmentStructureDepartmentUnitMinLength, ErrorMessageResourceName = "MinLengthErrorMsg", ErrorMessageResourceType = typeof(EmployeeFormModelResx))]
        [MaxLength(DepartmentStructureDepartmentUnitMaxLength, ErrorMessageResourceName = "MaxLengthErrorMsg", ErrorMessageResourceType = typeof(EmployeeFormModelResx))]
        [Display(Name = "EmployeeNameBg", ResourceType = typeof(EmployeeFormModelResx))]
        public string EmployeeNameBg { get; set; }

        [Required(ErrorMessageResourceName = "RequiredErrorMsg", ErrorMessageResourceType = typeof(EmployeeFormModelResx))]
        [MinLength(DepartmentStructureDepartmentUnitMinLength, ErrorMessageResourceName = "MinLengthErrorMsg", ErrorMessageResourceType = typeof(EmployeeFormModelResx))]
        [MaxLength(DepartmentStructureDepartmentUnitMaxLength, ErrorMessageResourceName = "MaxLengthErrorMsg", ErrorMessageResourceType = typeof(EmployeeFormModelResx))]
        [Display(Name = "EmployeeNameEn", ResourceType = typeof(EmployeeFormModelResx))]
        public string EmployeeNameEn { get; set; }

        [MaxLength(DepartmentStructureDepartmentEmailMaxLength, ErrorMessageResourceName = "MaxLengthErrorMsg", ErrorMessageResourceType = typeof(EmployeeFormModelResx))]
        [Display(Name = "EmployeePhoneNumbers", ResourceType = typeof(EmployeeFormModelResx))]
        public string EmployeePhoneNumbers { get; set; }

        [Required(ErrorMessageResourceName = "RequiredErrorMsg", ErrorMessageResourceType = typeof(EmployeeFormModelResx))]
        [Display(Name = "EmployeeOrder", ResourceType = typeof(EmployeeFormModelResx))]
        public int EmployeeOrder { get; set; }

        [Display(Name = "EmployeeDepartmentStructureId", ResourceType = typeof(EmployeeFormModelResx))]
        public int EmployeeDepartmentStructureId { get; set; }

        [Display(Name = "DepartmentStructures", ResourceType = typeof(EmployeeFormModelResx))]
        public List<DepartmentStructureServiceModel> DepartmentStructures { get; set; }
    }
}
