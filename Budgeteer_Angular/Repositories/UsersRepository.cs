using Budgeteer_Angular.Data;
using Budgeteer_Angular.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Budgeteer_Angular.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        //MyEntity GetById(int id);
        //void Add(MyEntity entity);
        //void Update(MyEntity entity);
        //void Delete(int id);
    }

    // EntityRepository.cs
    public class UserRepository : IUserRepository
    {
        private readonly AppContext _appContext;

        public UserRepository(AppContext appContext)
        {
            _appContext = appContext;
        }

        public IEnumerable<User> GetAll()
        {
            return _appContext.Users;
        }

        // Other CRUD methods...
    }

}
