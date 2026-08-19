using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class VitalSign:BaseModule
    {
        [ForeignKey("VitalSignMaster")]
        public Guid VitalSignMasterId { get; set; }
        public VitalSignMaster VitalSignMaster { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string dataTypeName { get; set; }
        public string maxValue { get; set; }
        public string minValue { get; set; }
        public List<string> listValues { get; set; }
    }
}
