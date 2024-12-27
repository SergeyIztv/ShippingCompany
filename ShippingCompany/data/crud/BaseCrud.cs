using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShippingCompany.Exceptions;

namespace ShippingCompany.data.crud;

public class BaseCrud<T> : IBaseCrud<T> where T : class
{
    protected readonly ShippingCompanyDbContext _context;
    protected readonly DbSet<T> _entities;

    protected BaseCrud()
    {
        _context = ShippingCompanyDbContext.GetInstance();
        this._entities = _context.Set<T>();
    }

    public virtual void Create(T entity)
    {
        try
        {
            _entities.Add(entity);
            _context.SaveChanges();
        }
        catch (DbUpdateException ex)
        {
            throw new DatabaseOperationException("Error creating data", ex);
        }
    }
    
    public virtual List<T> ReadAll()
    {
        try
        {
            return _entities.ToList();
        }
        catch (Exception ex)
        {
            throw new DataNotFoundException("Data not found.");
        }
    }

    public virtual T ReadById(long id)
    {
        var entity = _entities.Find(id);
        if (entity == null)
        {
            throw new EntityNotFoundException(id);
        }
        return entity;
    }
    
    public virtual void Update(T entity)
    {
        try
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
        catch (DbUpdateException ex)
        {
            throw new DatabaseOperationException("Error updating data", ex);
        }
    }   

    public virtual void Delete(T entity)
    {
        try
        {
            _entities.Remove(entity);
            _context.SaveChanges();
        }
        catch (DbUpdateException ex)
        {
            throw new DatabaseOperationException("Error deleting data", ex);
        }
    }
}