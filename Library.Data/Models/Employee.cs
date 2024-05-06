namespace Library.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [MinLength(EmployeeNameMinLength)]
        [MaxLength(EmployeeNameMaxLength)]
        public string NameBg { get; set; }

        [Required]
        [MinLength(EmployeeNameMinLength)]
        [MaxLength(EmployeeNameMaxLength)]
        public string NameEn { get; set; }

        [MaxLength(EmployeePhoneMaxLengt)]
        public string PhoneNumbers { get; set; }

        [Required]
        public int Order { get; set; }

        [Required]
        public int DepartmentStructureId { get; set; }

        [Required]
        public DepartmentStructure DepartmentStructure { get; set; }

    }
}
