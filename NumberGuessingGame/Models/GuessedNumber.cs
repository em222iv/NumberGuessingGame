using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumberGuessingGame.Models
{
    public enum Outcome { Indefinite,Low,High,Right,NoMoreGuesses,OldGuess }
    public class GuessedNumber
    {
        public int? Number;

        public void Compute()
        {   
            var SecretNumber = new SecretNumber();

            switch (this.Outcome)
            {
                case Outcome.Indefinite:
                    this.Number > SecretNumber.Number;
                    break;
                case Outcome.Low:
                    break;
                case Outcome.High:
                    break;
                case Outcome.Right:
                    break;
                case Outcome.NoMoreGuesses:
                    break;
                case Outcome.OldGuess:
                    break;
                default:
                    break;
            }

        }


        public Outcome Outcome;
    }
}
