namespace Library.Web.Areas.LibraryBlog.Models.WorkSchedules
{
    using Library.Web.Resources.Areas.LibraryBlog.Models.WorkSchedules;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class WorkScheduleFormModel
    {
        [Required(ErrorMessageResourceName = "RequiredErrorMsg", ErrorMessageResourceType = typeof(WorkSchedulesFormModelResx))]
        [MinLength(WorkScheduleMinLength, ErrorMessageResourceName = "MinLengthErrorMsg", ErrorMessageResourceType = typeof(WorkSchedulesFormModelResx))]
        [MaxLength(WorkScheduleMaxLength, ErrorMessageResourceName = "MaxLengthErrorMsg", ErrorMessageResourceType = typeof(WorkSchedulesFormModelResx))]
        [Display(Name = "DepartmentNameBg", ResourceType = typeof(WorkSchedulesFormModelResx))]
        public string DepartmentNameBg { get; set; }

        [Required(ErrorMessageResourceName = "RequiredErrorMsg", ErrorMessageResourceType = typeof(WorkSchedulesFormModelResx))]
        [MinLength(WorkScheduleMinLength, ErrorMessageResourceName = "MinLengthErrorMsg", ErrorMessageResourceType = typeof(WorkSchedulesFormModelResx))]
        [MaxLength(WorkScheduleMaxLength, ErrorMessageResourceName = "MaxLengthErrorMsg", ErrorMessageResourceType = typeof(WorkSchedulesFormModelResx))]
        [Display(Name = "DepartmentNameEn", ResourceType = typeof(WorkSchedulesFormModelResx))]
        public string DepartmentNameEn { get; set; }

        [Required(ErrorMessageResourceName = "RequiredErrorMsg", ErrorMessageResourceType = typeof(WorkSchedulesFormModelResx))]
        [MinLength(WorkScheduleMinLength, ErrorMessageResourceName = "MinLengthErrorMsg", ErrorMessageResourceType = typeof(WorkSchedulesFormModelResx))]
        [MaxLength(WorkScheduleMaxLength, ErrorMessageResourceName = "MaxLengthErrorMsg", ErrorMessageResourceType = typeof(WorkSchedulesFormModelResx))]
        [Display(Name = "WorkdaysBg", ResourceType = typeof(WorkSchedulesFormModelResx))]
        public string WorkdaysBg { get; set; }

        [Required(ErrorMessageResourceName = "RequiredErrorMsg", ErrorMessageResourceType = typeof(WorkSchedulesFormModelResx))]
        [MinLength(WorkScheduleMinLength, ErrorMessageResourceName = "MinLengthErrorMsg", ErrorMessageResourceType = typeof(WorkSchedulesFormModelResx))]
        [MaxLength(WorkScheduleMaxLength, ErrorMessageResourceName = "MaxLengthErrorMsg", ErrorMessageResourceType = typeof(WorkSchedulesFormModelResx))]
        [Display(Name = "WorkdaysEn", ResourceType = typeof(WorkSchedulesFormModelResx))]
        public string WorkdaysEn { get; set; }

        [Required(ErrorMessageResourceName = "RequiredErrorMsg", ErrorMessageResourceType = typeof(WorkSchedulesFormModelResx))]
        [MinLength(WorkScheduleMinLength, ErrorMessageResourceName = "MinLengthErrorMsg", ErrorMessageResourceType = typeof(WorkSchedulesFormModelResx))]
        [MaxLength(WorkScheduleMaxLength, ErrorMessageResourceName = "MaxLengthErrorMsg", ErrorMessageResourceType = typeof(WorkSchedulesFormModelResx))]
        [Display(Name = "SaturdayBg", ResourceType = typeof(WorkSchedulesFormModelResx))]
        public string SaturdayBg { get; set; }

        [Required(ErrorMessageResourceName = "RequiredErrorMsg", ErrorMessageResourceType = typeof(WorkSchedulesFormModelResx))]
        [MinLength(WorkScheduleMinLength, ErrorMessageResourceName = "MinLengthErrorMsg", ErrorMessageResourceType = typeof(WorkSchedulesFormModelResx))]
        [MaxLength(WorkScheduleMaxLength, ErrorMessageResourceName = "MaxLengthErrorMsg", ErrorMessageResourceType = typeof(WorkSchedulesFormModelResx))]
        [Display(Name = "SaturdayEn", ResourceType = typeof(WorkSchedulesFormModelResx))]
        public string SaturdayEn { get; set; }

        [Required(ErrorMessageResourceName = "RequiredErrorMsg", ErrorMessageResourceType = typeof(WorkSchedulesFormModelResx))]
        [MinLength(WorkScheduleMinLength, ErrorMessageResourceName = "MinLengthErrorMsg", ErrorMessageResourceType = typeof(WorkSchedulesFormModelResx))]
        [MaxLength(WorkScheduleMaxLength, ErrorMessageResourceName = "MaxLengthErrorMsg", ErrorMessageResourceType = typeof(WorkSchedulesFormModelResx))]
        [Display(Name = "SundayBg", ResourceType = typeof(WorkSchedulesFormModelResx))]
        public string SundayBg { get; set; }

        [Required(ErrorMessageResourceName = "RequiredErrorMsg", ErrorMessageResourceType = typeof(WorkSchedulesFormModelResx))]
        [MinLength(WorkScheduleMinLength, ErrorMessageResourceName = "MinLengthErrorMsg", ErrorMessageResourceType = typeof(WorkSchedulesFormModelResx))]
        [MaxLength(WorkScheduleMaxLength, ErrorMessageResourceName = "MaxLengthErrorMsg", ErrorMessageResourceType = typeof(WorkSchedulesFormModelResx))]
        [Display(Name = "SundayEn", ResourceType = typeof(WorkSchedulesFormModelResx))]
        public string SundayEn { get; set; }

    }
}
