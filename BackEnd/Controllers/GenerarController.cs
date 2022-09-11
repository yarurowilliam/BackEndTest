using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;

namespace BackEnd.Controllers
{
    public class GenerarController : Controller
    {
        public IActionResult Index()
        {
            return new ViewAsPdf("Index")
            {

            };
        }
    }
}
