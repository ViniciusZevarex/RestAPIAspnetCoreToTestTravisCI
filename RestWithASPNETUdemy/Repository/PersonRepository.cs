using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using RestWithASPNETUdemy.Repository.Generic;
using System;
using System.Linq;

namespace RestWithASPNETUdemy.Repository
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {

        public PersonRepository(MySQLContext context) : base(context) { }

        public Person Disable(long id)
        {
            if (!_dbContext.Persons.Any(x => x.Id == id)) return null;
            var user = _dbContext.Persons.SingleOrDefault(x => x.Id == id);

            if (user != null)
            {
                user.Enabled = false;
                try
                {
                    _dbContext.Entry(user).CurrentValues.SetValues(user);
                    _dbContext.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return user;
        }
    }
}
