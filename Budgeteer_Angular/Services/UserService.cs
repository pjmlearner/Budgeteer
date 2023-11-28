using Budgeteer_Angular.Models;
using Budgeteer_Angular.Repositories;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace Budgeteer_Angular.Services
{
        public interface IUserService
        {
            IEnumerable<User> GetAllEntities();
            //MyEntity GetEntityById(int id);
            Task AddUserAsync(User user, CancellationToken cancellationToken = default);
            //void UpdateEntity(MyEntity entity);
            //void DeleteEntity(int id);
        }

    // EntityService.cs
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<User> GetAllEntities()
        {
            return _userRepository.GetAll().ToList<User>();
        }
        public async Task AddUserAsync(User user, CancellationToken cancellationToken = default)
        {
            await _userRepository.AddUserAsync(user, cancellationToken);
        }

        // Other business logic methods...
    }

}
