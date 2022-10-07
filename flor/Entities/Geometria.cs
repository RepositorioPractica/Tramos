using System.ComponentModel.DataAnnotations.Schema;

namespace flor.Entities
{
    public class Geometria
    {
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public Tramo tramo { get; set; }
        [ForeignKey("Id")]
        public int TramoId { get; set; }
      


    }
}
