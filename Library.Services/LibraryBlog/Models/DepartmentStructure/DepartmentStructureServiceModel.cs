namespace Library.Services.LibraryBlog.Models.DepartmentStructure
{
    using Common.Mapping;
    using Data.Models;
    using System.Collections.Generic;

    public class DepartmentStructureServiceModel : IMapFrom<DepartmentStructure>
    {
        public int Id { get; set; }

        public string DepartmentUnitBg { get; set; }

        public string DepartmentUnitEn { get; set; }

        public string DepartmentEmail { get; set; }

        public DepartmentStructureType DepartmentStructureType { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
