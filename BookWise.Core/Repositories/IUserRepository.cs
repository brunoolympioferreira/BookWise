﻿using BookWise.Core.Entities;

namespace BookWise.Core.Repositories;
public interface IUserRepository
{
    Task AddAsync(User user);
    Task<bool> ExistUserByEmail(string email, Guid id);
}
