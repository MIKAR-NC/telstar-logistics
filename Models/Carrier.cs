using System.ComponentModel.DataAnnotations;

namespace TelstarRoutePlanner.Models
{
    public enum CarrierType
    {
        Land = 0,
        Sea = 1,
        Air = 2
    }

    public class Carrier
    {
        [Key]
        public string ID { get; set; }

        public CarrierType Type { get; set; }
        
        public virtual ICollection<Segment> Segments { get; set; }
    }
}
