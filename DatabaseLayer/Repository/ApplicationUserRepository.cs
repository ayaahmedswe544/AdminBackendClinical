
using Domain.Response;
using DomainLayer.IRepository;
using DomainLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLayer.Repository
{
    public class ApplicationUserRepository : BaseRepository<DomainLayer.Models.ApplicationUser>, IApplicationUserRepository
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public ApplicationUserRepository(AppDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager) : base(context)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public async Task<bool> AddRoleAsync(string userId, string roleName)
        {
            bool userExists = await _userManager.FindByIdAsync(userId) != null;
            bool roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (userExists && roleExists)
            {
                var user = await _userManager.FindByIdAsync(userId);
                var result = await _userManager.AddToRoleAsync(user, roleName);
                return result.Succeeded;

            }
            else
            {
                return false;

            }
        }

        public async Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }

        public async Task<GeneralResponse<ApplicationUser>> CreateAsync(ApplicationUser user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            return new GeneralResponse<ApplicationUser>
            {
                Success = result.Succeeded,
                Data = user,
                Message = result.Succeeded ? "User created successfully." : "Failed to create user."
            };
        }
        

        public async Task<ApplicationUser> GetByEmailAsync(string email)
        {
          
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<ApplicationUser> GetByUsernameAsync(string username)
        {
            return await _userManager.FindByNameAsync(username);
        }

        public Task<Doctor> GetDoctorbyUserIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<ApplicationUser> GetUserIdAsync(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        public Task<List<IdentityRole>> GetuserRoles(string id)
        {
            return _userManager.GetRolesAsync(new ApplicationUser { Id = id }).ContinueWith(task =>
            {
                var roles = task.Result;
                var identityRoles = new List<IdentityRole>();
                foreach (var roleName in roles)
                {
                    var role = _roleManager.FindByNameAsync(roleName).Result;
                    if (role != null)
                    {
                        identityRoles.Add(role);
                    }
                }
                return identityRoles;
            });
        }

        public async Task<GeneralResponse<ApplicationUser>> LogInAsync(ApplicationUser user, string password)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(user, password, isPersistent: false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return new GeneralResponse<ApplicationUser>
                    {
                        Success = true,
                        Data = user,
                        Message = "User logged in successfully."
                    };
                }
                else
                {
                    return new GeneralResponse<ApplicationUser>
                    {
                        Success = false,
                        Data = null,
                        Message = "Invalid login attempt."
                    };
                }
            }
            catch (Exception ex)
            {
                return new GeneralResponse<ApplicationUser>
                {
                    Success = false,
                    Data = null,
                    Message = $"An error occurred during login: {ex.Message}"
                };
            }

        }

        public async Task<ApplicationUser> UpdateAsync(ApplicationUser user)
        {
            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded ? user : null;
        }
    }
}
