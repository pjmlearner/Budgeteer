using Budgeteer_Angular.Models;
using Budgeteer_Angular.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Budgeteer_Angular.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAllEntities();
        //MyEntity GetEntityById(int id);
        //void AddEntity(MyEntity entity);
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

        // Other business logic methods...
    }

}
