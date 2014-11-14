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
        public SecretNumber secretNumber { get; set; }
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
        public int Guess { get; set; }


        public string outcomeText;
        public string guessCountText;

    
        public void MakeGuess(int guess)
        {
            secretNumber.MakeGuess(guess);
            
        }

        public void guessCount()
        {
            if (secretNumber.LastGuessedNumber.Outcome == Outcome.Right) 
            {
                guessCountText = string.Format("You made it in {0} guesses", secretNumber.Count);
            }
            else if (!secretNumber.CanMakeGuess)
            {
                guessCountText = string.Format("You are out of guesses. The secret number was {0}", secretNumber.Number);
               
            }
            else {
                guessCountText = string.Format("Guess nr: {0} ", secretNumber.Count);
            }

        }
        public void enumMessage()
        {
            switch (secretNumber.LastGuessedNumber.Outcome)
            {
                case Outcome.Indefinite:
                    outcomeText = "No guess";
                    break;
                case Outcome.Low:
                    outcomeText = "Guess was to low";
                    break;
                case Outcome.High:
                    outcomeText = "Guess was to high";
                    break;
                case Outcome.Right:
                    outcomeText = string.Format("You sir, was CORRECT. The secret number was {0}", secretNumber.Number);
                    break;
                case Outcome.NoMoreGuesses:
                    outcomeText = "No more guesses. Please click 'New' for another round";
                    break;
                case Outcome.OldGuess:
                    outcomeText = "That guess is already made";
                    break;
                default:
                    break;
            }
         
        }

    }
}