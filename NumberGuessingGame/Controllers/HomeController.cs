using NumberGuessingGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NumberGuessingGame.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var model = new SecretNumber();
            return View(model);
        }
        //
        // POST: /Home/Index
        [HttpPost]
        public ActionResult Index_POST()
        {
            var model = new SecretNumber();
            model.MakeGuess(model.guess);
            return View(model);
           
        }
    }
}
