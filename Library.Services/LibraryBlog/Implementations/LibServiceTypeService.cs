
namespace Library.Services.LibraryBlog.Implementations
{
    using Library.Data.Models;
    using Library.Data;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using Library.Services.LibraryBlog.Models.LibServiceTypes;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    public class LibServiceTypeService : ILibServiceTypeService
    {
        private readonly LibraryDbContext db;

        public LibServiceTypeService(LibraryDbContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(string serviceNameBg, string serviceNameEn, int order)
        {
            var libServiceType = new LibServiceType
            {
                ServiceNameBg = serviceNameBg,
                ServiceNameEn = serviceNameEn,
                Order = order
            };

            db.Add(libServiceType);
            await db.SaveChangesAsync();
        }


        public async Task EditAsync(int id, string serviceNameBg, string serviceNameEn, int order)
        {
            var libServiceType = await db.LibServiceTypes.FindAsync(id);

            if (libServiceType == null)
            {
                return;
            }

            libServiceType.ServiceNameBg = serviceNameBg;
            libServiceType.ServiceNameEn = serviceNameEn;
            libServiceType.Order = order;

            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var libServiceType = await db.LibServiceTypes.FindAsync(id);

            if (libServiceType == null)
            {
                return;
            }
            foreach (var description in libServiceType.LibServiceDescriptions)
            {
                db.LibServiceDescriptions.Remove(description);
            }

            db.LibServiceTypes.Remove(libServiceType);
            await db.SaveChangesAsync();
        }

        public async Task<LibServiceTypeServiceModel> ByIdAsync(int id)
            => await db
                .LibServiceTypes
                .Where(a => a.Id == id)
                .ProjectTo<LibServiceTypeServiceModel>()
                .FirstOrDefaultAsync();
        
        public async Task<IEnumerable<LibServiceTypeServiceModel>> AllLibServiceTypeAsync()
            => await db
                .LibServiceTypes
                .ProjectTo<LibServiceTypeServiceModel>()
                .ToListAsync();
    }
}
