﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Musicorum.Data;
using Musicorum.Services.Models;
using System.Linq;

namespace Musicorum.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly MusicorumDbContext db;
        private readonly ISongService songService;

        public UserService(MusicorumDbContext db, ISongService songService)
        {
            this.db = db;
            this.songService = songService;
        }

        public UserAccountModel UserDetails(string userId)
        {
            if (this.UserExists(userId))
            {
                var userAccountModel = db
                    .Users
                    .Where(u => u.Id == userId)
                    .ProjectTo<UserAccountModel>()
                    .FirstOrDefault();

                userAccountModel.LikedSongs = this.songService.GetUserLikedSongs(userId);
                userAccountModel.UserSongs = this.songService.GetSongsOfUser(userId);

                return userAccountModel;
            }
            else
            {
                return null;
            }
        }

        public bool UserExists(string userId) => this.db.Users.Any(u => u.Id == userId && u.IsDeleted == false);

        public object GetUserFullName(string id)
        {
            if (this.UserExists(id))
            {
                var user = this.db.Users.Find(id);
                return user.FirstName + " " + user.LastName;
            }
            return null;
        }

        public bool CheckIfDeleted(string userId)
        {
            throw new System.NotImplementedException();
        }

        public UserModel GetById(string id)
        {
            if (this.UserExists(id))
            {
                return Mapper.Map<UserModel>(this.db.Users.Find(id));
            }

            return null;
        }

        public void EditUser(string id, string firstName, string lastName, int age, string email, string username)
        {
            var user = this.db.Users.Find(id);

            user.FirstName = firstName;
            user.LastName = lastName;
            user.UserName = username;
            user.Age = age;
            user.Email = email;

            this.db.SaveChanges();
        }

        public void DeleteUser(string id)
        {
            var user = this.db.Users.Find(id);

            user.IsDeleted = true;

            this.db.SaveChanges();
        }

        public bool CheckIfDeletedByUserName(string username)
        {
            if (this.db.Users.Any(u => u.UserName == username))
            {
                return this.db.Users.FirstOrDefault(u => u.UserName == username).IsDeleted;
            }

            return true;
        }
    }
}