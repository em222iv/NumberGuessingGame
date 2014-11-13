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
        public string GuessOutcome;

        public void MakeGuess(int guess)
        {
            secretNumber.MakeGuess(guess);
        }  

        public void enumMessage()
        {
            switch (secretNumber.LastGuessedNumber.Outcome)
            {
                case Outcome.Indefinite:
                    GuessOutcome = "Ingen gissning";
                    break;
                case Outcome.Low:
                    GuessOutcome = "Gissningen var för låg";
                    break;
                case Outcome.High:
                    GuessOutcome = "Gissningen var för hög";
                    break;
                case Outcome.Right:
                    GuessOutcome = "Gissningen var KORREKT";
                    break;
                case Outcome.NoMoreGuesses:
                    GuessOutcome = "Inga fler gissningar";
                    break;
                case Outcome.OldGuess:
                    GuessOutcome = "Gissningen var redan gjord";
                    break;
                default:
                    break;
            }
        }

        public void loopList()
        {
        }
    }
}