namespace Library.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;
    public class DepartmentStructure
    {
        public int Id { get; set; }

        [Required]
        [MinLength(DepartmentStructureDepartmentUnitMinLength)]
        [MaxLength(DepartmentStructureDepartmentUnitMaxLength)]
        public string DepartmentUnitBg { get; set; }

        [Required]
        [MinLength(DepartmentStructureDepartmentUnitMinLength)]
        [MaxLength(DepartmentStructureDepartmentUnitMaxLength)]
        public string DepartmentUnitEn { get; set; }

        [MinLength(DepartmentStructureDepartmentEmailMinLength)]
        [MaxLength(DepartmentStructureDepartmentEmailMaxLength)]
        public string DepartmentEmail { get; set; }

        [Required]
        public DepartmentStructureType DepartmentStructureType { get; set; }

        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
