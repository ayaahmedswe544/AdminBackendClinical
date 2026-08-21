using Domain.Response;
using DomainLayer;
using DomainLayer.Models;
using ServiceLayer.ApplicationUser.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.ApplicationUser
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ApplicationUserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<GeneralResponse<UserDto>> LogInAsync(LoginDto loginDto)
        {
            if (loginDto == null) {
                return new GeneralResponse<UserDto>
                {
                    Success = false,
                    Message = "Login data is null."

                };  
            }
            var usernameExists = await _unitOfWork.ApplicationUserRepository.GetByUsernameAsync(loginDto.UserName);
            if(usernameExists == null)
            {
                return new GeneralResponse<UserDto>
                {
                    Success = false,
                    Message = "Username does not exist."
                };
            }
            DomainLayer.Models.ApplicationUser user = await _unitOfWork.ApplicationUserRepository.GetByUsernameAsync(loginDto.UserName);
            bool passwordValid = await _unitOfWork.ApplicationUserRepository.CheckPasswordAsync(user, loginDto.Password);
            if (!passwordValid)
            {
                return new GeneralResponse<UserDto>
                {
                    Success = false,
                    Message = "Invalid password."
                };
            }

            var logRes = await _unitOfWork.ApplicationUserRepository.LogInAsync(user, loginDto.Password);
            if (logRes.Success != true)
            {
                return new GeneralResponse<UserDto>
                {
                    Success = false,
                    Message="User is not logged in, check info and try again"

                };
            }
            else
            {
                return new GeneralResponse<UserDto>
                {
                    Success = true,
                    Message = "User is logged in successfully"

                };
            }


        }
    }
}
