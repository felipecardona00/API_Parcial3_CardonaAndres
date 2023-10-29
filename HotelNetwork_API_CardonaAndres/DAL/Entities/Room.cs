using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace HotelNetwork_API_CardonaAndres.DAL.Entities
{
    public class Room
    {
        [Display(Name = "Hotel")]
        [Range(100,999, ErrorMessage = "Field {0} should be between 100 and 999")]
        [Required(ErrorMessage = "Field {0} is required")]
        public int Number { get; set; }

        [MaxLength(50, ErrorMessage = "Field {0} max number of caracters is {1}.")]
        [DefaultValue(1)]
        public int MaxGuests { get; set; }

        [DefaultValue(true)]
        public bool Availability { get; set; }

        [Display(Name = "Hotel id")]
        public Guid HotelId { get; set; }

        public Hotel? Hotel { get; set; }
    }
}
