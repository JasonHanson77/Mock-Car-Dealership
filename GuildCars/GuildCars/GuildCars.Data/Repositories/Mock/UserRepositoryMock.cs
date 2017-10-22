using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Repositories.Mock
{
    public class UserRepositoryMock :IUserRepository
    {
        private static List<User> _users = new List<User>();

        private static User _salesUserOne = new User
        {
            Id = "00000000-0000-0000-0000-000000000000",
            EmailConfirmed = false,
            PhoneNumberConfirmed = false,
            Email = "sales1@test.com",
            TwoFactorEnabled = false,
            LockoutEnabled = false,
            AccessFailedCount = 0,
            UserName = "Sales Test User 1"
        };

        private static User _salesUserTwo = new User
        {
            Id = "11111111-1111-1111-1111-111111111111",
            EmailConfirmed = false,
            PhoneNumberConfirmed = false,
            Email = "sales2@test.com",
            TwoFactorEnabled = false,
            LockoutEnabled = false,
            AccessFailedCount = 0,
            UserName = "Sales Test User 2"
        };

        private static User _adminUserOne = new User
        {
            Id = "33333333-3333-3333-3333-333333333333",
            EmailConfirmed = false,
            PhoneNumberConfirmed = false,
            Email = "admin1@test.com",
            TwoFactorEnabled = false,
            LockoutEnabled = false,
            AccessFailedCount = 0,
            UserName = "Admin Test User 1"
        };

        private static User _adminUserTwo = new User
        {
            Id = "44444444-4444-4444-4444-444444444444",
            EmailConfirmed = false,
            PhoneNumberConfirmed = false,
            Email = "admin2@test.com",
            TwoFactorEnabled = false,
            LockoutEnabled = false,
            AccessFailedCount = 0,
            UserName = "Admin Test User 2"
        };

        public UserRepositoryMock()
        {
            if(_users.Count != 0)
            {
                _users.Clear();
            }

            _users.Add(_salesUserOne);
            _users.Add(_salesUserTwo);
            _users.Add(_adminUserOne);
            _users.Add(_adminUserTwo);
        }

        public User GetUserById(string UserId)
        {
            return _users.FirstOrDefault(u => u.Id == UserId);
        }

        public IEnumerable<User> GetUsers()
        {
            return _users;
        }

        public void ClearUsers()
        {
            _users.Clear();
        }

        public void Insert(User user)
        {
            user.Id = "Added-Test-User";

            _users.Add(user);
        }

        public void Update(User user)
        {
            int index = _users.FindIndex(u => u.Id == user.Id);

            _users.RemoveAt(index);

            _users.Insert(index, user);
        }
    }
}
