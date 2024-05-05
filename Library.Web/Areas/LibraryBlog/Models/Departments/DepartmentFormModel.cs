namespace Library.Web.Areas.LibraryBlog.Models.Departments
{
    using Data.Models;
    using Microsoft.AspNetCore.Http;
    using Resources.Areas.LibraryBlog.Models.Departments;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Infrastructure.Filters;

    using static Data.DataConstants;
    using Library.Web.Resources.Areas.LibraryBlog.Models.Departments;

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
        [MinLength(DepartmentStructureDepartmentEmailMinLength, ErrorMessageResourceName = "MinLengthErrorMsg", ErrorMessageResourceType = typeof(DepartmentFormModelResx))]
        [MaxLength(DepartmentStructureDepartmentEmailMaxLength, ErrorMessageResourceName = "MaxLengthErrorMsg", ErrorMessageResourceType = typeof(DepartmentFormModelResx))]
        [Display(Name = "DepartmentEmail", ResourceType = typeof(DepartmentFormModelResx))]
        public string DepartmentEmail { get; set; }

        [Required(ErrorMessageResourceName = "RequiredErrorMsg", ErrorMessageResourceType = typeof(DepartmentFormModelResx))]
        [Display(Name = "DepartmentStructureType", ResourceType = typeof(DepartmentFormModelResx))]
        public DepartmentStructureType DepartmentStructureType { get; set; }
    }
}
