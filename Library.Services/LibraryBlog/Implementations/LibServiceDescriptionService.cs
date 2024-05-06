namespace Library.Services.LibraryBlog.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Data.Models;
    using Library.Services.LibraryBlog.Models.LibServiceDescriptions;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class LibServiceDescriptionService : ILibServiceDescriptionService
    {
        private readonly LibraryDbContext db;

        public LibServiceDescriptionService(LibraryDbContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(string serviceTypeBg,
            string serviceTypeEn,
            string descriptionBg,
            string descriptionEn,
            string priceInfoBg,
            string priceInfoEn,
            int order,
            int libServiceTypeId)
        {
            var departmentStructure = new LibServiceDescription
            {
                ServiceTypeBg = serviceTypeBg,
                ServiceTypeEn = serviceTypeEn,
                DescriptionBg = descriptionBg,
                DescriptionEn = descriptionEn,
                PriceInfoBg = priceInfoBg,
                PriceInfoEn = priceInfoEn,
                Order = order,
                LibServiceTypeId = libServiceTypeId
            };

            db.Add(departmentStructure);
            await db.SaveChangesAsync();
        }


        public async Task EditAsync(int id,
            string serviceTypeBg,
            string serviceTypeEn,
            string descriptionBg,
            string descriptionEn,
            string priceInfoBg,
            string priceInfoEn,
            int order,
            int libServiceTypeId)
        {
            var libServiceDescription = await db.LibServiceDescriptions.FindAsync(id);

            if (libServiceDescription == null)
            {
                return;
            }

            libServiceDescription.ServiceTypeBg = serviceTypeBg;
            libServiceDescription.ServiceTypeEn = serviceTypeEn;
            libServiceDescription.DescriptionBg = descriptionBg;
            libServiceDescription.DescriptionEn = descriptionEn;
            libServiceDescription.PriceInfoBg = priceInfoBg;
            libServiceDescription.PriceInfoEn = priceInfoEn;
            libServiceDescription.Order = order;
            libServiceDescription.LibServiceTypeId = libServiceTypeId;

            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var libServiceDescription = await db.LibServiceDescriptions.FindAsync(id);

            if (libServiceDescription == null)
            {
                return;
            }

            db.LibServiceDescriptions.Remove(libServiceDescription);
            await db.SaveChangesAsync();
        }

        public async Task<LibServiceDescriptionServiceModel> ByIdAsync(int id)
            => await db
                .LibServiceDescriptions
                .Where(a => a.Id == id)
                .ProjectTo<LibServiceDescriptionServiceModel>()
                .FirstOrDefaultAsync();

        public async Task<IEnumerable<LibServiceDescriptionServiceModel>> AllLibServiceDescriptionAsync()
            => await db
                .LibServiceDescriptions
                .ProjectTo<LibServiceDescriptionServiceModel>()
                .ToListAsync();
    }
}
