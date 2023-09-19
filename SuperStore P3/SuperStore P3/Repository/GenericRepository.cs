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

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
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
        public void DeleteConfirmed(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }
    }
}


