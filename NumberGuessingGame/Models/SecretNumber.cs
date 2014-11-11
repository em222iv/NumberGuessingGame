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
        Random rnd = new Random();
        private List<GuessedNumber> _guessedNumbers;
        private GuessedNumber _lastGuessedNumber;
        private int? _number;
        public const int MaxNumberOfGuesses = 7;


        public SecretNumber()
        {
            _guessedNumbers = new List<GuessedNumber>();
            Initialize();
        }
        public void Initialize()
        {
            _lastGuessedNumber = new GuessedNumber();
            Random random = new Random();
            _number = random.Next(1, 101);
            _guessedNumbers.Clear();
            _lastGuessedNumber.Outcome = Outcome.Indefinite;
        }
        public int Count {
            get
                {
                    return _guessedNumbers.Count;
                }
        }
        public bool CanMakeGuess
        {
            get
            {
                if (Count < MaxNumberOfGuesses)
                {
                    return true;
                }
                return false;
            }
        }

        public IList<GuessedNumber> GuessedNumbers { get { return _guessedNumbers.AsReadOnly(); } }
        public GuessedNumber LastGuessedNumber { get { return _lastGuessedNumber;} }
        public int? Number
        {
            get
            {
                if (CanMakeGuess)
                {
                    return null;
                }
                else
                {
                    return _number;
                }
            }
        }
        
       public Outcome MakeGuess(int guess) {

           _lastGuessedNumber.Number = guess;
           if (CanMakeGuess)
           {
               if (guess < 100 && guess > 1)
               {
                   if (_lastGuessedNumber.Number == _number)
                   {
                       _lastGuessedNumber.Outcome = Outcome.Right;
                   }

                   if (_lastGuessedNumber.Number < _number)
                   {
                       _lastGuessedNumber.Outcome = Outcome.Low;
                   }
                   if (_lastGuessedNumber.Number > _number)
                   {
                       _lastGuessedNumber.Outcome = Outcome.High;
                   }
                   if (_guessedNumbers.Contains(LastGuessedNumber))
                   {
                       _lastGuessedNumber.Outcome = Outcome.OldGuess;
                   }
               }
               else
               {
                   throw new ArgumentOutOfRangeException();
               }
           }
           else 
           {
               _lastGuessedNumber.Outcome = Outcome.NoMoreGuesses;
           }
           return _lastGuessedNumber.Outcome;
        }
    }
}