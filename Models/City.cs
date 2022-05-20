using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace TelstarRoutePlanner.Models
{
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ID { get; set; }

        public string Name { get; set; }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(this);
        }

        //public virtual ICollection<Segment>? Segments { get; set; }
    }

}
