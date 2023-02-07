using Microsoft.EntityFrameworkCore;
using RestWithASPNETUdemy.Model.Base;
using RestWithASPNETUdemy.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNETUdemy.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {

        protected readonly MySQLContext _dbContext;
        private DbSet<T> _dataset;

        public GenericRepository(MySQLContext mySQLDbContext)
        {
            _dbContext = mySQLDbContext;
            _dataset = _dbContext.Set<T>();
        }


        public T Create(T item)
        {
            try
            {
                _dataset.Add(item);
                _dbContext.SaveChanges();
                return item;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void Delete(long id)
        {
            var result = _dataset.SingleOrDefault(p => p.Id == id);

            if (result != null)
            {
                try
                {
                    _dataset.Remove(result);
                    _dbContext.SaveChanges();
                }
                catch (Exception e)
                {
                    throw;
                }
            }
        }

        public T Update(T item)
        {
            var result = _dataset.SingleOrDefault(p => p.Id == item.Id);

            if (result != null)
            {
                try
                {
                    _dbContext.Entry(result).CurrentValues.SetValues(item);
                    _dbContext.SaveChanges();
                    return result;
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }

        public bool Exists(long id)
        {
            return _dataset.Any(p => p.Id == id);
        }

        public List<T> FindAll()
        {
            return _dataset.ToList();
        }

        public T FindById(long id)
        {
            return _dataset.SingleOrDefault(p => p.Id == id);
        }


    }
}
