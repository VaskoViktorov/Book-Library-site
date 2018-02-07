﻿namespace Library.Services.LibraryBlog.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Common.Infrastructure.Extensions;
    using Data;
    using Data.Models;
    using LibraryBlog;
    using Microsoft.EntityFrameworkCore;
    using Models.Books;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using static ServicesConstants;

    class BookService : IBookService
    {
        private readonly LibraryDbContext db;

        public BookService(LibraryDbContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(string authorName, string bookTitle, string bookDescription, string cityIssued,
            string press, DepartmentType department, int publishDate, DateTime date, int pages, int size, string genre, string imageUrl, Language language)
        {
            var book = new Book
            {
                AuthorName = authorName,
                BookTitle = bookTitle,
                BookDescription = bookDescription,
                CityIssued = cityIssued,
                Press = press,
                Department = department,
                PublishDate = publishDate,
                Date = date,
                Pages = pages,
                Size = size,
                Genre = genre,
                ImageUrl = imageUrl,
                Language = language
            };

            this.db.Add(book);
            await this.db.SaveChangesAsync();
        }

        public async Task<bool> UniqueCheckAsync(string bookTitle, string authorName)
        {
            if (await this.db.Books.AnyAsync(b => b.BookTitle == bookTitle && b.AuthorName == authorName))
            {
                return true;
            }

            return false;
        }

        public async Task EditAsync(int id, string authorName, string bookTitle, string bookDescription, string cityIssued,
            string press, DepartmentType department, int publishDate, int pages, int size, string genre, string imageUrl, Language language)
        {
            var book = await this.db.Books.FindAsync(id);

            if (book == null)
            {
                return;
            }

            book.AuthorName = authorName;
            book.BookTitle = bookTitle;
            book.BookDescription = bookDescription;
            book.CityIssued = cityIssued;
            book.Press = press;
            book.Department = department;
            book.PublishDate = publishDate;
            book.Pages = pages;
            book.Size = size;
            book.Genre = genre;
            book.Language = language;

            if (imageUrl != null)
            {
                if (imageUrl != "\\images\\BookCovers\\default.jpg")
                {
                    FileExtensions.DeleteImage(book.ImageUrl);
                }

                book.ImageUrl = imageUrl;
            }

            await this.db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var book = await this.db.Books.FindAsync(id);

            if (book == null)
            {
                return;
            }

            this.db.Books.Remove(book);
            await this.db.SaveChangesAsync();

            if (book.ImageUrl != "\\images\\BookCovers\\default.jpg")
            {
                FileExtensions.DeleteImage(book.ImageUrl);
            }
        }

        public async Task<BookServiceModel> ByIdAsync(int id)
            => await this.db
                .Books
                .Where(a => a.Id == id)
                .ProjectTo<BookServiceModel>()
                .FirstOrDefaultAsync();

        public async Task<IEnumerable<BookListingServiceModel>> AllBooksAsync(int page = 1)
            => await this.db
                .Books
                .OrderByDescending(b => b.Date)
                .Where(b => b.Language == Language.Bg)
                .Skip((page - 1) * BooksPageSize)
                .Take(BooksPageSize)
                .ProjectTo<BookListingServiceModel>()
                .ToListAsync();

        public async Task<IEnumerable<BookListingServiceModel>> AllBooksForChildrenAsync(int page = 1)
            => await this.db
                .Books
                .OrderByDescending(b => b.Date)
                .Where(b => b.Department == DepartmentType.Kids && b.Language == Language.Bg)
                .Skip((page - 1) * BooksPageSize)
                .Take(BooksPageSize)
                .ProjectTo<BookListingServiceModel>()
                .ToListAsync();

        public async Task<IEnumerable<BookListingServiceModel>> AllBooksForLandLandAsync(int page = 1)
            => await this.db
                .Books
                .OrderByDescending(b => b.Date)
                .Where(b => b.Department == DepartmentType.Land && b.Language == Language.Bg)
                .Skip((page - 1) * BooksPageSize)
                .Take(BooksPageSize)
                .ProjectTo<BookListingServiceModel>()
                .ToListAsync();

        public async Task<int> TotalAsync()
        => await this.db
                    .Books
                    .Where(b => b.Language == Language.Bg)
                    .CountAsync();

        public async Task<int> TotalForKidsAsync()
            => await this.db
                .Books
                .Where(b => b.Department == DepartmentType.Kids && b.Language == Language.Bg)
                .CountAsync();

        public async Task<int> TotalForLandAsync()
           => await this.db
               .Books
               .Where(b => b.Department == DepartmentType.Land && b.Language == Language.Bg)
               .CountAsync();

        public async Task<IEnumerable<BookListingServiceModel>> AllBooksEnAsync(int page = 1)
            => await this.db
                .Books
                .OrderByDescending(b => b.Date)
                .Where(b => b.Language == Language.En)
                .Skip((page - 1) * BooksPageSize)
                .Take(BooksPageSize)
                .ProjectTo<BookListingServiceModel>()
                .ToListAsync();

        public async Task<IEnumerable<BookListingServiceModel>> AllBooksForChildrenEnAsync(int page = 1)
            => await this.db
                .Books
                .OrderByDescending(b => b.Date)
                .Where(b => b.Department == DepartmentType.Kids && b.Language == Language.En)
                .Skip((page - 1) * BooksPageSize)
                .Take(BooksPageSize)
                .ProjectTo<BookListingServiceModel>()
                .ToListAsync();

        public async Task<IEnumerable<BookListingServiceModel>> AllBooksForLandEnAsync(int page = 1)
            => await this.db
                .Books
                .OrderByDescending(b => b.Date)
                .Where(b => b.Department == DepartmentType.Land && b.Language == Language.En)
                .Skip((page - 1) * BooksPageSize)
                .Take(BooksPageSize)
                .ProjectTo<BookListingServiceModel>()
                .ToListAsync();

        public async Task<int> TotalEnAsync()
            => await this.db
                .Books
                .Where(b => b.Language == Language.En)
                .CountAsync();

        public async Task<int> TotalForKidsEnAsync()
            => await this.db
                .Books
                .Where(b => b.Department == DepartmentType.Kids && b.Language == Language.En)
                .CountAsync();

        public async Task<int> TotalForLandEnAsync()
            => await this.db
                .Books
                .Where(b => b.Department == DepartmentType.Land && b.Language == Language.En)
                .CountAsync();
    }
}