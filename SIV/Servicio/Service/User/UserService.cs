using Data;
using Data.Entities;
using Repository.Dto;
using Repository.Interface;
using Repository.Repository;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Service
{
    public class UserService : IUserService
    {
        protected SivContext db;
        public IBaseRepository<User> UserRepository  { get; set; }
        public IBaseRepository<UserBranchOffice> UserBranchOfficeRepository { get; set; }
        public UserService(SivContext context)
        {
            db = context;
            UserRepository = new BaseRepository<User>(context);
            UserBranchOfficeRepository = new BaseRepository<UserBranchOffice>(context);
        }

        public UserDtoOutput Create(UserDtoInput user)
        {
            try
            {
                using var contextTran = db.Database.BeginTransaction();
                User usermodel = new User()
                {
                    UserName = "asdf",
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PasswordHash = user.Password,
                    Email = user.Email
                };

                User result = UserRepository.Create(usermodel);

                UserDtoOutput output = new UserDtoOutput()
                {
                    UserName = result.UserName,
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    Email = result.Email,
                    Password = result.PasswordHash
                };

                return output;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
