using System.ComponentModel.DataAnnotations;

namespace TelstarRoutePlanner.Models
{
    public class City
    {
        [Key]
        public string ID { get; set; }

        public string Name { get; set; }

        //public virtual ICollection<Segment>? Segments { get; set; }
    }
}
