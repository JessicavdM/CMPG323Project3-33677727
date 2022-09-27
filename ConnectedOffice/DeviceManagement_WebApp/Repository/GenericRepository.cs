using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using DeviceManagement_WebApp.Data;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DeviceManagement_WebApp.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ConnectedOfficeContext _context;
        public GenericRepository(ConnectedOfficeContext context)
        {
            _context = context;
        }

        //Inserts the given instance of a class into its related table in the DBContext
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        //Saves changes to the data source (uses when entries are added, deleted and edited)
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        //Inserts the given range of instances of a class into its related table in the DBContext
        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        //Finds and returns all the instances of a class that match the given search expression
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        //Tracks the changes for the given entity that will be Updated
        public void Update(T entity)
        {
            _context.Update(entity);
        }

        //Returns all the instances in the data source of a class
        public virtual IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        //Returns one instance of a class based on the given ID
        public virtual T GetById(Guid? id)
        {
            return _context.Set<T>().Find(id);
        }

        //Deletes one specified instance of a class in the related DBContext
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        //Deletes a range of specifed instances of a class in the related DBContext
        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }
    }
}
