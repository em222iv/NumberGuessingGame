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
        public Outcome Outcome;
    }

}
