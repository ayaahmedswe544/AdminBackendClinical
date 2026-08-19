using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public class ApplicationUser : IdentityUser
{
   
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string jobTitle { get; set; } = string.Empty;
}


public class Doctor :BaseModule
{
    public string Specialization { get; set; } = string.Empty;
    public string ClinicName { get; set; } = string.Empty;
    public string ClinicAddress { get; set; } = string.Empty;
    public string ClinicPhoneNumber { get; set; } = string.Empty;
    public string ClinicEmail { get; set; } = string.Empty;

    [Required]
    [ForeignKey("ApplicationUser")]
    public string? UserId { get; set; }
    public ApplicationUser? ApplicationUser { get; set; } 
}

public class Patient : BaseModule
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string gender { get; set; } = string.Empty;
}