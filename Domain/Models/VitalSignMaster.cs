
namespace Domain.Models;
public class VitalSignMaster : BaseModule
{
    public string Name { get; set; }
    public List<VitalSign>? VitalSigns { get; set; } = new List<VitalSign>();

}