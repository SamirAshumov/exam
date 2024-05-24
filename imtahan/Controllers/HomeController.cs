using imtahan.Business.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace imtahan.Controllers
{

    public class HomeController : Controller
    {
        public ISpeakerService _speakerService;

        public HomeController(ISpeakerService speakerService)
        {
            _speakerService = speakerService;
        }

        public IActionResult Index()
        {


            var speakers = _speakerService.GetAllSpeakers();


            return View(speakers);
        }

    }
}
