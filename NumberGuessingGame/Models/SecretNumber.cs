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
        public int Op1;

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
                return _guessedNumbers.Count;
            } 
        }
        public IList<GuessedNumber> GuessNumbers { get { return _guessedNumbers.AsReadOnly(); } }
        GuessedNumber LastGuessedNumber { get { return _lastGuessedNumber;} }
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
            _guessedNumbers.Clear();
            Number = rnd.Next(1, 101);       
        }

       public Outcome MakeGuess(int guess) {

            return (Outcome)guess;
        
        }
        public SecretNumber() {
   
        }


    }
}