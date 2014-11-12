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
                if (Session["SessionGuess"] == null)
                {
                    Session["SessionGuess"] = new SecretNumber();
              
                }
                return Session["SessionGuess"] as SecretNumber;
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



        //
        // POST: /Home/Index
        [HttpPost]
        public ActionResult Index(HomeIndexViewModel homeIndexViewModel)
        {

            homeIndexViewModel.secretNumber = secretNumberSession;
            homeIndexViewModel.MakeGuess(homeIndexViewModel.MyGuess);

            homeIndexViewModel.enumMessage();

            return View(homeIndexViewModel);
        }
    }
}
