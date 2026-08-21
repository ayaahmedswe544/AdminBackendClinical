using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models;
public class DiagnosMaster : BaseModule
{
    [Required]
    [StringLength(150)]
    public string? Name { get; set; }
    public string? Description { get; set; }

    [Required]
    [StringLength(20)]
    public string Code { get; set; } = string.Empty;
}
