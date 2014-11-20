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

        private string _outcomeText;

        private string _guessCountText;
        public string OutcomeText { set { _outcomeText = value; } get { return _outcomeText; } }
        public string GuessCountText { set { _guessCountText = value; } get { return _guessCountText; } }
    
        public void MakeGuess(int guess)
        {
            secretNumber.MakeGuess(guess);
            
        }

        public void guessCount()
        {
            if (secretNumber.LastGuessedNumber.Outcome == Outcome.Right) 
            {
                _guessCountText = string.Format("You made it in {0} guesses", secretNumber.Count);
            }
            else if (!secretNumber.CanMakeGuess)
            {
                _guessCountText = string.Format("You are out of guesses. The secret number was {0}", secretNumber.Number);
               
            }
            else {
                _guessCountText = string.Format("Guess nr: {0} ", secretNumber.Count);
            }

        }
        public void enumMessage()
        {
            switch (secretNumber.LastGuessedNumber.Outcome)
            {
                case Outcome.Indefinite:
                    _outcomeText = "No guess";
                    break;
                case Outcome.Low:
                    _outcomeText = "Guess was to low";
                    break;
                case Outcome.High:
                    _outcomeText = "Guess was to high";
                    break;
                case Outcome.Right:
                    _outcomeText = string.Format("You sir, was CORRECT. The secret number was {0}", secretNumber.Number);
                    break;
                case Outcome.NoMoreGuesses:
                    _outcomeText = "No more guesses. Please click 'New' for another round";
                    break;
                case Outcome.OldGuess:
                    _outcomeText = "That guess is already made";
                    break;
                default:
                    break;
            }
         
        }

    }
}