using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TelstarRoutePlanner.Models
{
    public class Segment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ID { get; set; }
        
        public int? Cost { get; set; }

        public string City1ID { get; set; }
        public City City1 { get; set; }

        public string City2ID { get; set; }
        public City City2 { get; set; }

        public string CarrierID { get; set; }
        public Carrier Carrier { get; set; }

        public Segment() { }
        public Segment(int? cost, string city1Id, string city2Id, string carrierId)
        {
            Cost = cost;
            City1ID = city1Id;
            City2ID = city2Id;
            CarrierID = carrierId;
        }
    }
}
