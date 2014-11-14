using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NumberGuessingGame.Models.Rules
{
    public class Impossibrruu : ISetting
    {
        public int MaxNumberOfGuesses() { return 4; }
    }
}