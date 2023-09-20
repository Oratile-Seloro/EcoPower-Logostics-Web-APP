using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Models;
using Controllers;
using System.Linq.Expressions;

namespace EcoPower_Logistics.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly SuperStoreContext _context;
        public GenericRepository(SuperStoreContext context)
        {
            _context = context;
        }
        public void Create(T entity)
        {
           // _context.Set<T>().Add(entity);
           try 
            {
                _context.Add(entity);
                _context.SaveChanges();

            }
            catch (Exception ex) 
            {
                throw new Exception($"{nameof(entity)} could not be saved");
            }
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public void Update(T entity)
        { 
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(entity)} can not be null");
            }
            try
            {
                _context.Update(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated");
            }
        }
        public void Delete(T entity)
        {
            try
            {
                _context.Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception ex) 
            {
                throw new Exception($"Couldn't delete: {ex.Message}");
            }
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }
    }
}


