using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels
{
    public class CreateSpeakersAdminVM
    {
        [MaxLength(32), Required]
        public string Name { get; set; }
        [Required]
        public IFormFile ImageFile { get; set; }
        [MaxLength(256), Required]
        public string Description { get; set; }
        [Required]
        public string SocialMedia { get; set; }
    }
}
