using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace GMSBackend.Services
{
    public interface IUserService
    {
        bool IsAnExistingUser(string userName);
        bool IsValidUserCredentials(string userName, string password);
        string GetUserRole(string userName);
        Tuple<int, string> GetUserIDAndRole(string userName);
    }

    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly DBRepository _dBRepository;


        public UserService(ILogger<UserService> logger, DBRepository dBRepository)
        {
            _logger = logger;
            _dBRepository = dBRepository;
        }

        public bool IsValidUserCredentials(string userName, string password)
        {
            _logger.LogInformation($"Validating user [{userName}]");
            if (string.IsNullOrWhiteSpace(userName))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            return _dBRepository.users.FirstOrDefault(l => l.user_name == userName && l.password == password) != null;
        }

        public bool IsAnExistingUser(string userName)
        {
            return _dBRepository.users.FirstOrDefault(l => l.user_name == userName) != null;
        }

        public string GetUserRole(string userName)
        {

            var user = _dBRepository.users.FirstOrDefault(l => l.user_name == userName);

            if (user == null)
            {
                return string.Empty;
            }

            return GetRole(user.user_role_id);

        }

        public Tuple<int, string> GetUserIDAndRole(string userName)
        {

            var user = _dBRepository.users.FirstOrDefault(l => l.user_name == userName);
            var result = new Tuple<int, string>(0, string.Empty);

            if (user == null)
            {
                return result;
            }

            return new Tuple<int, string>(user.id, GetRole(user.user_role_id));
        }

        private string GetRole(int roleid)
        {
            return roleid switch
            {
                1 => "admin",
                2 => "gymboss",
                3 => "gymstaff",
                4 => "client",
                5 => "coach",
                _ => "client",
            };
        }
    }

}