using System.ComponentModel.DataAnnotations;

namespace Airlines.Model
{
    public class Airline
    {
        [Key]
        public string Id { get; set; }
        public string? Name { get; set; }
        public int FoundingYear { get; set; }
        public string? OriginCountry { get; set; }
    }
}
