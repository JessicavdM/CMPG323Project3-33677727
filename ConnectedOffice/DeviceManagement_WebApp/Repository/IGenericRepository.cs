using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        //Returns one instance of a class based on the given ID
        T GetById(Guid? id);

        //Returns all the instances in the data source of a class
        IEnumerable<T> GetAll();

        //Finds and returns all the instances of a class that match the given search expression
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);

        //Tracks the changes for the given entity that will be Updated
        void Update(T entity);

        //Inserts the given instance of a class into its related table in the DBContext
        void Add(T entity);

        //Saves changes to the data source (uses when entries are added, deleted and edited)
        Task SaveChanges();

        //Inserts the given range of instances of a class into its related table in the DBContext
        void AddRange(IEnumerable<T> entities);

        //Deletes one specified instance of a class in the related DBContext
        void Remove(T entity);

        //Deletes a range of specifed instances of a class in the related DBContext
        void RemoveRange(IEnumerable<T> entities);
    }
}
