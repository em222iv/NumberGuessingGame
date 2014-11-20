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

        //public ActionResult Start()
        //{

        //    var model = new HomeIndexViewModel
        //    {
        //        secretNumber = secretNumberSession,
        //        gameSettings = new GameSetting()
        //    };
        //    model.gameSettings.StartGame = true;
        //    return View("Index", model);
        //}
  
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
            if (Session.IsNewSession)
            {
                homeIndexViewModel = new HomeIndexViewModel
                {
                    secretNumber = secretNumberSession
                };
                ModelState.AddModelError(string.Empty, "Your Time Ran Out. New Game Started");
            }
            else { 
                
                if (ModelState.IsValid)
                {
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
            }
            return View(homeIndexViewModel);
        }
    }
}
