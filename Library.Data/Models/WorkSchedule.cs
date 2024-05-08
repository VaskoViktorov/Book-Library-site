namespace Library.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;
    public class WorkSchedule
    {
        public int Id { get; set; }

        [Required]
        [MinLength(WorkScheduleMinLength)]
        [MaxLength(WorkScheduleMaxLength)]
        public string DepartmentNameBg { get; set; }

        [Required]
        [MinLength(WorkScheduleMinLength)]
        [MaxLength(WorkScheduleMaxLength)]
        public string DepartmentNameEn { get; set; }

        [Required]
        [MinLength(WorkScheduleMinLength)]
        [MaxLength(WorkScheduleMaxLength)]
        public string WorkdaysBg { get; set; }

        [Required]
        [MinLength(WorkScheduleMinLength)]
        [MaxLength(WorkScheduleMaxLength)]
        public string WorkdaysEn { get; set; }

        [Required]
        [MinLength(WorkScheduleMinLength)]
        [MaxLength(WorkScheduleMaxLength)]
        public string SaturdayBg { get; set; }

        [Required]
        [MinLength(WorkScheduleMinLength)]
        [MaxLength(WorkScheduleMaxLength)]
        public string SaturdayEn { get; set; }

        [Required]
        [MinLength(WorkScheduleMinLength)]
        [MaxLength(WorkScheduleMaxLength)]
        public string SundayBg { get; set; }

        [Required]
        [MinLength(WorkScheduleMinLength)]
        [MaxLength(WorkScheduleMaxLength)]
        public string SundayEn { get; set; }
    }
}
