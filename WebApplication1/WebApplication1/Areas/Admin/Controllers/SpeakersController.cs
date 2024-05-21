using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DAL;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpeakersController(MeetUpContext _context, IWebHostEnvironment _env) : Controller
    {
        // GET: SpeakersController
        public async Task<ActionResult> Index()
        {
            return View(await _context.Speakers.Select(s => new GetSpeakersAdminVM
            {
                Description = s.Description,
                ImageFile = s.ImageFile,
                Name = s.Name,
                SocialMedia = s.SocialMedia,
                Id = s.Id,
            }).ToListAsync());
        }


        // GET: SpeakersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SpeakersController/Create
        [HttpPost]
        public async Task<IActionResult> Create(CreateSpeakersAdminVM speakersvm)
        {
            if (!ModelState.IsValid) return View(speakersvm);

            string fileName = Guid.NewGuid().ToString() + speakersvm.ImageFile.FileName;
            string path = Path.Combine(_env.WebRootPath, "assets", "img", fileName);
            FileStream file = new FileStream(path, FileMode.Create);
            await speakersvm.ImageFile.CopyToAsync(file);
            await _context.Speakers.AddAsync(new Speaker
            {
                ImageFile = fileName,
                Name = speakersvm.Name,
                Description = speakersvm.Description,
                SocialMedia = speakersvm.SocialMedia,
            });
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");


        }

        // GET: SpeakersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SpeakersController/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SpeakersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SpeakersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
