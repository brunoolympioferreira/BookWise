﻿using BookWise.Core.Entities;
using BookWise.Core.Exceptions;
using BookWise.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookWise.Infra.Persistence.Repositories;
public class BookRepository(BookWiseDbContext dbContext) : IBookRepository
{
    public async Task AddAsync(Book book)
    {
        await dbContext.AddAsync(book);
    }

    public async Task<bool> FindByISBNAsync(string isbn)
    {
        return await dbContext.Books.AnyAsync(x => x.ISBN == isbn);
    }

    public async Task<List<Book>> GetAllAsync()
    {
        return await dbContext.Books.AsNoTracking().ToListAsync();
    }

    public async Task<List<Book>> GetAllByYearAsync(int year)
    {
        var books = await dbContext.Books
            .AsNoTracking()
            .Include(r => r.Reviews)
            .Where(r => r.Reviews.Any(x => x.CreatedAt.Year == year))
            .ToListAsync();

        return books;
    }

    public void Remove(Book book)
    {
        dbContext.Remove(book);
    }

    public async Task<Result<Book>> GetByIdAsync(Guid id)
    {
        var book = await dbContext.Books
            .AsNoTracking()
            .Include(r => r.Reviews)
                .ThenInclude(r => r.User)
            .SingleOrDefaultAsync(b => b.Id == id);

        if (book is null)
        {
            return Result<Book>.Failure($"Book with ID {id} not found");
        }

        return Result<Book>.Success(book);
    }

    public async Task<Book> GetToUpdateByIdAsync(Guid id)
    {
        var book = await dbContext.Books
            .AsNoTracking()
            .SingleOrDefaultAsync(b => b.Id == id);

        return book;
    }

    public void Update(Book book)
    {
        dbContext.Update(book);
    }
}
