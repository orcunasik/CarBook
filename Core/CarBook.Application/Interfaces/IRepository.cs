﻿namespace CarBook.Application.Interfaces;

public interface IRepository<T> where T : class
{
    Task<IList<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task RemoveAsync(T entity);
}