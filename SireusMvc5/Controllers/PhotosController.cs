using System.Web.Mvc;

namespace SireusMvc5.Controllers
{
    public class PhotosController : Controller
    {
        //
        // GET: /Photos/

        public ActionResult Index(int arg1, string arg2)
        {
            ViewData["ShowPage"] = "Home";
            ViewBag.AlbumID = arg1;
            ViewData["Caption"] = arg2;
            return View();
        }
    }
}