using Domain.Models;
using Domain.Response;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLayer.Repository
{
    public class ApplicationUserRepository : BaseRepository<Domain.Models.ApplicationUser>, DomainLayer.IRepository.IApplicationUserRepository
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public ApplicationUserRepository(AppDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager) : base(context)
        {
            _context = context;
            _userManager = userManager;
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

        public async Task<ApplicationUser> UpdateAsync(ApplicationUser user)
        {
            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded ? user : null;
        }
    }
}
