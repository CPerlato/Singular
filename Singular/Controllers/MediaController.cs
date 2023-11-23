using Microsoft.AspNetCore.Mvc;
using Singular.Models;

namespace Singular.Controllers
{
    public class MediaController : Controller
    {
        public IActionResult CalcularMedia()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CalcularMedia(MediaModel model)
        {
            if (ModelState.IsValid)
            {
                // Calcula a média
                double media = (model.Nota1 + model.Nota2 + model.Nota3) / 3;

                // Passe a média para a visão
                ViewBag.Media = media;

                return View();
            }
            return View(model);
        }
    }
}
