using Forum.App.Contracts;
using Forum.Data;
using Forum.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forum.App.Services
{
    class UserService : IUserService
    {
        private ForumData forumData;
        private ISession session;

        public UserService(ForumData forumData, ISession session)
        {
            this.forumData = forumData;
            this.session = session;
        }

        public User GetUserById(int userId)
        {
            var user = this.forumData.Users.FirstOrDefault(x=>x.Id == userId);
            return user;
        }

        public string GetUserName(int userId)
        {
            var user = this.forumData.Users.FirstOrDefault(x => x.Id == userId);
            return user.Username;
        }

        public bool TryLogInUser(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            var user = this.forumData.Users.FirstOrDefault(x=>x.Username == username&& x.Password == password);
            if (user == null)
            {
                return false;
            }

            this.session.Reset();
            this.session.LogIn(user);
            return true;
        }

        public bool TrySignUpUser(string username, string password)
        {
            bool usernameValid = !string.IsNullOrWhiteSpace(username) && username.Length > 3;
            bool passwordValid = !string.IsNullOrWhiteSpace(password) && password.Length > 3;

            if(!usernameValid || !passwordValid)
            {
                throw new ArgumentException("Username and Password must be longer than three symbols!");
            }

            bool userAlreadyExists = this.forumData.Users.Any(x=>x.Username == username);

            if (userAlreadyExists)
            {
                throw new InvalidOperationException("Username takes!");
            }

            int userId = this.forumData.Users.LastOrDefault()?.Id + 1 ?? 1;

            User user = new User(userId,username,password);

            this.forumData.Users.Add(user);
            this.forumData.SaveChanges();

            this.TryLogInUser(username, password);
            return true;
        }
    }
}
