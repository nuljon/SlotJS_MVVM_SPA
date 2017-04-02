using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SlotJS_MVVM_SPAS.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
    // rememcer to action result method for Spawn nuljon.com
}
