using Budgeteer_Angular.Data;
using Budgeteer_Angular.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace Budgeteer_Angular.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        //MyEntity GetById(int id);
        Task AddUserAsync(User user, CancellationToken cancellationToken = default);
        //void Update(MyEntity entity);
        //void Delete(int id);
    }

    // EntityRepository.cs
    public class UserRepository : IUserRepository
    {
        private readonly BudgetAppContext _budgetAppContext;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(BudgetAppContext budgetAppContext, ILogger<UserRepository> logger)
        {
            _budgetAppContext = budgetAppContext;
            _logger = logger;
        }

        public IEnumerable<User> GetAll()
        {
            return _budgetAppContext.Users;
        }

        public async Task AddUserAsync(User user, CancellationToken cancellationToken = default)
        {
            try
            {
                _budgetAppContext.Users.Add(user);
                _budgetAppContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Unable to create user. {ex.GetBaseException().Message}");
                throw new Exception("Unable to create user.", ex);
            }

        }

        //public List<string> GetUsersEmail()
        //{
        //    var emails = new List<string>();
        //    foreach (User user in _budgetAppContext.Users)
        //    {

        //    }
        //    //to do 
        //    var users = _budgetAppContext.Users;
        //   for (User user in  users)
        //    {
        //        if
        //    }
        //}
        // Other CRUD methods...
    }

}
