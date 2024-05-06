namespace Library.Services.LibraryBlog.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Data.Models;
    using Library.Services.LibraryBlog.Models.DepartmentStructure;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public class DepartmentStructureService : IDepartmentStructureService
    {
        private readonly LibraryDbContext db;

        public DepartmentStructureService(LibraryDbContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(string departmentUnitBg, string departmentUnitEn, string departmentEmail, DepartmentStructureType departmentStructureType)
        {
            var departmentStructure = new DepartmentStructure
            {
                DepartmentUnitBg = departmentUnitBg,
                DepartmentUnitEn = departmentUnitEn,
                DepartmentEmail = departmentEmail,
                DepartmentStructureType = departmentStructureType
            };

            db.Add(departmentStructure);
            await db.SaveChangesAsync();
        }


        public async Task EditAsync(int id, string departmentUnitBg, string departmentUnitEn, string departmentEmail, DepartmentStructureType departmentStructureType)
        {
            var departmentStructure = await db.DepartmentStructures.FindAsync(id);

            if (departmentStructure == null)
            {
                return;
            }

            departmentStructure.DepartmentUnitBg = departmentUnitBg;
            departmentStructure.DepartmentUnitEn = departmentUnitEn;
            departmentStructure.DepartmentEmail = departmentEmail;
            departmentStructure.DepartmentStructureType = departmentStructureType;

            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var departmentStructure = await db.DepartmentStructures.FindAsync(id);

            if (departmentStructure == null)
            {
                return;
            }

            foreach (var employee in departmentStructure.Employees)
            {
                db.Employees.Remove(employee);
            }

            db.DepartmentStructures.Remove(departmentStructure);
            await db.SaveChangesAsync();
        }

        public async Task<DepartmentStructureServiceModel> ByIdAsync(int id)
            => await db
                .DepartmentStructures
                .Where(a => a.Id == id)
                .ProjectTo<DepartmentStructureServiceModel>()
                .FirstOrDefaultAsync();

        public async Task<IEnumerable<DepartmentStructureServiceModel>> AllDepartmentStrucutresAsync()
            => await db
                .DepartmentStructures
                .ProjectTo<DepartmentStructureServiceModel>()
                .ToListAsync();

        public async Task<IEnumerable<DepartmentStructureServiceModel>> AllDepartmentStrucutresByDepartmentStructureTypeAsync(DepartmentStructureType depStructure)
            => await db
                .DepartmentStructures
                .Where(b => b.DepartmentStructureType == depStructure)
                .ProjectTo<DepartmentStructureServiceModel>()
                .ToListAsync();


    }
}
