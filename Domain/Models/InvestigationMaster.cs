using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public class InvestigationMaster :BaseModule
{
    [Required]
    [StringLength(30)]
    public string Code { get; set; } = string.Empty;

    [Required]
    [StringLength(200)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string Category { get; set; } = "Laboratory"; // Laboratory, Radiology, etc.
}
