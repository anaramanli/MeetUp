using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Speaker: BaseEntity
    {
        [MaxLength(32), Required]
        public string Name { get; set; }
        [Required]
        public string ImageFile { get; set; }
        [MaxLength(256), Required]
        public string Description { get; set; }
        [Required]
        public string SocialMedia { get; set; }
    }
}
