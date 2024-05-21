using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DAL;

namespace WebApplication1.Controllers
{
    public class HomeController(MeetUpContext _context) : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View(await _context.Speakers.ToListAsync());
        }
    }
}
