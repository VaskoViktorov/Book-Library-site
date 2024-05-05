namespace Library.Services.LibraryBlog
{
    using Data.Models;
    using Library.Services.LibraryBlog.Models.DepartmentStructure;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IDepartmentStructureService
    {

        Task CreateAsync(
            string departmentUnitBg,
            string departmentUnitEn,
            string departmentEmail,
            DepartmentStructureType departmentStructureType);

        Task EditAsync(
            int id,
            string departmentUnitBg,
            string departmentUnitEn,
            string departmentEmail,
            DepartmentStructureType departmentStructureType);

        Task DeleteAsync(int id);

        Task<DepartmentStructureServiceModel> ByIdAsync(int id);

        Task<IEnumerable<DepartmentStructureServiceModel>> AllDepartmentStrucutresAsync();

        Task<IEnumerable<DepartmentStructureServiceModel>> AllDepartmentStrucutresByDepartmentStructureTypeAsync(DepartmentStructureType depStructure);

    }
}

