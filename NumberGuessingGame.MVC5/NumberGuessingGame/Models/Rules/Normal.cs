using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NumberGuessingGame.Models.Rules
{
    public class Normal : ISetting
    {
        public int MaxNumberOfGuesses() { return 7; }
    }
}