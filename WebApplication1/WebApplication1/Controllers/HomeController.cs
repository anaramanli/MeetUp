using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DAL;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class HomeController(MeetUpContext _context) : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View(await _context.Speakers.Select(s=> new GetSpeakersAdminVM
            {
                Description = s.Description,
                Id = s.Id,
                ImageFile = s.ImageFile,
                Name = s.Name,
                SocialMedia = s.SocialMedia,
            }).ToListAsync());
        }
    }
}
