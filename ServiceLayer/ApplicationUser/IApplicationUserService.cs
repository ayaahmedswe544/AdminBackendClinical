using Domain.Response;
using System;
using System.Collections.Generic;
using System.Text;
using DomainLayer.Models;
using ServiceLayer.ApplicationUser.DTOs;

namespace ServiceLayer.ApplicationUser
{
    public interface IApplicationUserService
    {
        Task<GeneralResponse<UserDto>> LogInAsync(LoginDto loginDto);
    }
}
