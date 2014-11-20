using NumberGuessingGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using NumberGuessingGame.Controllers;

namespace NumberGuessingGame.ViewModels
{
    public class HomeIndexViewModel
    {
        public SecretNumber SecretNumber { get; set; }

        //public GameSetting gameSettings { get; set; }
        //public SelectList GameSettingChoice
        //{
        //    get
        //    {
        //        var choices = new Dictionary<GameSettingChoices, string> 
        //        {
        //            { GameSettingChoices.Four, "Four guesses"},
        //            { GameSettingChoices.Five, "Five guesses"},
        //            { GameSettingChoices.Six, "Six guesses"},
        //            { GameSettingChoices.Seven, "Seven guesses"},
        //        };
        //        return new SelectList(choices, "Key", "Value");
        //    }
        //}

        [Range(1,100, ErrorMessage="Out of range 1-100")]
        [Required (ErrorMessage="Field required")]
        public int? Guess { get; set; }

        private string _guessCountText;

        public string OutcomeText 
        { 
            get 
            {
                if (SecretNumber.LastGuessedNumber.Outcome == Outcome.Right)
                {
                    return string.Format("You made it in {0} guesses", SecretNumber.Count);
                }
                else if (!SecretNumber.CanMakeGuess)
                {
                    return string.Format("You are out of guesses. The secret number was {0}", SecretNumber.Number);
                }
                else
                {
                    return string.Format("Guess nr: {0} ", SecretNumber.Count);
                }
            } 
        }
        public string GuessCountText 
        { 
            get 
            {
                switch (SecretNumber.LastGuessedNumber.Outcome)
                {
                    case Outcome.Indefinite:
                        return "No guess";

                    case Outcome.Low:
                        return "Guess was to low";

                    case Outcome.High:
                        return "Guess was to high";

                    case Outcome.Right:
                        return string.Format("You sir, was CORRECT. The secret number was {0}", SecretNumber.Number);
                        
                    case Outcome.NoMoreGuesses:
                        return "No more guesses. Please click 'New' for another round";
                        
                    case Outcome.OldGuess:
                        return "That guess is already made";
                        
                    default:
                        return "Bad text!";
                }
            } 
        }
    }
}