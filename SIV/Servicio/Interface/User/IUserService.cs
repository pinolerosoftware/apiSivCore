using Data.Entities;
using Dto;
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
