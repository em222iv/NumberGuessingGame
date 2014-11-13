using NumberGuessingGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using NumberGuessingGame.Controllers;

namespace NumberGuessingGame.ViewModels
{
    public class HomeIndexViewModel
    {
        public SecretNumber secretNumber { get; set; }
        public int Guess { get; set; }
        public string _guessOutcome;

        public string guessesLeft;

        public void MakeGuess(int guess)
        {
            secretNumber.MakeGuess(guess);
        }


        public void guessCount()
        {
            if (secretNumber.LastGuessedNumber.Outcome == Outcome.Right) 
            {
                guessesLeft = string.Format("Du klarade det på {0} gissningar", secretNumber.Count);
            }
            else if (!secretNumber.CanMakeGuess)
            {
                guessesLeft = string.Format("Du har slut på gissningar");
            }
            else { 
                guessesLeft = string.Format("Gissning nr: {0} ",secretNumber.Count);
            }

        }
        public void enumMessage()
        {
            switch (secretNumber.LastGuessedNumber.Outcome)
            {
                case Outcome.Indefinite:
                    _guessOutcome = "Ingen gissning";
                    break;
                case Outcome.Low:
                    _guessOutcome = "Gissningen var för låg";
                    break;
                case Outcome.High:
                    _guessOutcome = "Gissningen var för hög";
                    break;
                case Outcome.Right:
                    _guessOutcome = "Gissningen var KORREKT";
                    break;
                case Outcome.NoMoreGuesses:
                    _guessOutcome = "Inga fler gissningar. Starta nytt spel";
                    break;
                case Outcome.OldGuess:
                    _guessOutcome = "Gissningen var redan gjord";
                    break;
                default:
                    break;
            }
         
        }

    }
}