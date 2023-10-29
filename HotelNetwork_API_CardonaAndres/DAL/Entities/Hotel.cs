using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HotelNetwork_API_CardonaAndres.DAL.Entities
{
    public class Hotel : AuditBase
    {
        [Display(Name = "Hotel")]
        [MaxLength(50, ErrorMessage = "Field {0} max number of caracters is {1}.")]
        [Required(ErrorMessage = "Field {0} is required")]
        public string Name { get; set; }

        [MaxLength(15, ErrorMessage = "Field {0} max number of caracters is {1}.")]
        [Required(ErrorMessage = "Field {0} is required")]
        public string City { get; set; }

        [MaxLength(80, ErrorMessage = "Field {0} max number of caracters is {1}.")]
        [Required(ErrorMessage = "Field {0} is required")]
        public string Address { get; set; }

        [MaxLength(10, ErrorMessage = "Field {0} max number of caracters is {1}.")]
        [Required(ErrorMessage = "Field {0} is required")]
        public string Phone { get; set; }

        [DefaultValue(1)]
        [Range(1,5,ErrorMessage = "Field {0} should be between 1 and 5")]
        public int Stars { get; set; }

        public ICollection<Room>? Rooms { get; set; }
    }
}
