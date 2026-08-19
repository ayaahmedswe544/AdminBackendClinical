using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Domain.Response;
using Domain.IRepository;

namespace DomainLayer.IRepository;

public interface IApplicationUserRepository : IBaseRepository<ApplicationUser>
{
      
    public Task<ApplicationUser> GetByUsernameAsync(string username);
    public  Task<ApplicationUser> GetByEmailAsync(string email);
    public Task<GeneralResponse<ApplicationUser>> CreateAsync(ApplicationUser user, string password);
    public Task<ApplicationUser> UpdateAsync(ApplicationUser user);
    public Task<List<IdentityRole>> GetuserRoles(string id);
    public  Task<bool> AddRoleAsync(string userId, string roleName);
    public Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
    public Task<ApplicationUser> GetUserIdAsync(string userId);
    public Task<Doctor> GetDoctorbyUserIdAsync(string userId);

}
