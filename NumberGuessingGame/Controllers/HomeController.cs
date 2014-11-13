using NumberGuessingGame.Models;
using NumberGuessingGame.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace NumberGuessingGame.Controllers
{
    public class HomeController : Controller
    {

        protected SecretNumber secretNumberSession
        {
            get
            {
                return Session["SessionGuess"] as SecretNumber ?? (SecretNumber)(Session["SessionGuess"] = new SecretNumber());
            }
        }
        //
        // GET: /Home/
        public ActionResult Index()
        {
            var model = new HomeIndexViewModel 
            {
                secretNumber = secretNumberSession
            };
       
         
            return View(model);
        }

        public ActionResult New()
        {
            secretNumberSession.Initialize();
            return RedirectToAction("Index");
        }

        //
        // POST: /Home/Index
        [HttpPost]
        public ActionResult Index(HomeIndexViewModel homeIndexViewModel)
        {
            if (ModelState.IsValid) {
                try
                {
                    homeIndexViewModel.secretNumber = secretNumberSession;
                    homeIndexViewModel.MakeGuess(homeIndexViewModel.Guess);
                    homeIndexViewModel.enumMessage();
                    homeIndexViewModel.guessCount();
                }
                catch (Exception e)
                {
                    ModelState.AddModelError(string.Empty, e.Message);
                }
            }
            return View(homeIndexViewModel);
        }
    }
}
