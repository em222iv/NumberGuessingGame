using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NumberGuessingGame.Models
{
    public class SecretNumber
    {
        public int guess;
        Random rnd = new Random();
        private List<GuessedNumber> _guessedNumbers;
        private GuessedNumber _lastGuessedNumber;
        private int? _number;
        public const int MaxNumberOfGuesses = 7; 

        public bool CanMakeGuess { 
            get { 
                if (Count > 7) { 
                    return false; }
                else { 
                    return true;
                } 
            } 
        }
        public int Count {
            get { 
                return 1;
            } 
        }
        public IList<GuessedNumber> GuessedNumbers { get { return _guessedNumbers.AsReadOnly(); } }
        public GuessedNumber LastGuessedNumber { get { return _lastGuessedNumber;} }
        public int? Number
        { 
            get
            {
                return _number;
            }
            private set
            {
                if(CanMakeGuess == true) {_number = null;} else { _number = value;}
            }
        }
        
        public void Initialize() {
        
            Number = rnd.Next(1, 101);
        }

       public Outcome MakeGuess(int guess) {

           var GuessedNumberInstance = new GuessedNumber();
           GuessedNumberInstance.Number = guess;
           Outcome outcome = GuessedNumberInstance.Outcome;

           return outcome;
        
        }
        public SecretNumber() {
   
        }


    }
}