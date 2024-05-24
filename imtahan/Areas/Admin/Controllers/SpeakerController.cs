using imtahan.Business.Exceptions;
using imtahan.Business.Services.Abstracts;
using imtahan.Business.Services.Concretes;
using imtahan.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace imtahan.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = ("Admin"))]
    public class SpeakerController : Controller
    {
        private readonly ISpeakerService _speakerService;

        public SpeakerController(ISpeakerService speakerService)
        {
            _speakerService = speakerService;
        }

        public IActionResult Index()
        {

            var members = _speakerService.GetAllSpeakers();


            return View(members);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Speaker speaker)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                _speakerService.AddSpeaker(speaker);
            }
            catch (FileRequiredException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
                return View();
            }
            catch (FileContentTypeException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
                return View();
            }
            catch (FileSizeException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return RedirectToAction("Index");

        }

        public IActionResult Update(int id)
        {
            var exist = _speakerService.GetSpeaker(x => x.Id == id);
            if (exist == null)
                return View("Error");

            return View(exist);
        }


        [HttpPost]
        public IActionResult Update(Speaker speaker)
        {
            if (speaker == null)
                return View("Error");


            try
            {
                _speakerService.UpdateSpeaker(speaker);
            }
            catch (EntityNotFoundException ex)
            {
                return View("Error");
            }
            catch (FileContentTypeException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
                return View();
            }
            catch (FileSizeException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return RedirectToAction("Index");

        }


        public IActionResult Delete(int id)
        {
            var exist = _speakerService.GetSpeaker(x => x.Id == id);
            if (exist == null)
                return View("Error");

            return View(exist);
        }

        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            var exist = _speakerService.GetSpeaker(x => x.Id == id);
            if (exist == null)
                return View("Error");


            try
            {
                _speakerService.RemoveSpeaker(id);
            }
            catch (EntityNotFoundException ex)
            {
                return View("Error");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return RedirectToAction("Index");
        }


    }
}
