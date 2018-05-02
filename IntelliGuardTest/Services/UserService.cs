using IntelliGuardTest.Common;
using IntelliGuardTest.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace IntelliGuardTest.Services
{
    public class UserService
    {
        private readonly DatabaseAccess _databaseAccess;
        public UserService()
        {
            _databaseAccess = new DatabaseAccess();
        }

        public IEnumerable<User> SelectAll()
        {
            return _databaseAccess.Query<User>("users.SelectAll");
        }

        /// <summary>
        /// Inserts the new user and returns the user id
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int Add(User user)
        {
            return _databaseAccess.ExecuteScalar<int>("users.AddUser", new SqlParameter[] {
                new SqlParameter("@FirstName",user.FirstName),
                new SqlParameter("@LastName",user.LastName),
                new SqlParameter("@Email",user.Email)
            });
        }

        public void Edit(User user)
        {
            throw new NotImplementedException();
        }
    }
}
