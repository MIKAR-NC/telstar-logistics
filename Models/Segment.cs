using System.ComponentModel.DataAnnotations;

namespace TelstarRoutePlanner.Models
{
    public class Segment
    {
        [Key]
        public string ID { get; set; }
        
        public int Cost { get; set; }

        public string City1ID { get; set; }
        public City City1 { get; set; }

        public string City2ID { get; set; }
        public City City2 { get; set; }

        public string CarrierID { get; set; }
        public Carrier Carrier { get; set; }
    }
}
