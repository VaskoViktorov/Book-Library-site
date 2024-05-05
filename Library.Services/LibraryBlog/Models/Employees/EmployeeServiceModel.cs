namespace Library.Services.LibraryBlog.Models.Employees
{
    using Common.Mapping;
    using Data.Models;

    public class EmployeeServiceModel : IMapFrom<Employee>
    {
        public int Id { get; set; }

        public string NameBg { get; set; }

        public string NameEn { get; set; }

        public string PhoneNumbers { get; set; }

        public int Order { get; set; }

        public int DepartmentStructureId { get; set; }
    }
}
