using Data.Entities;
using Repository.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interface
{
    public interface IUserService
    {
        UserDtoOutput Create(UserDtoInput user);
    }
}
