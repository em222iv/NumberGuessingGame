using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NumberGuessingGame.Models
{

    public class SecretNumber{
    
        
        Random rnd = new Random();
        private List<GuessedNumber> _guessedNumbers;
        private GuessedNumber _lastGuessedNumber;
        private int? _number;
        public const int MaxNumberOfGuesses = 7;



        public SecretNumber()
        {
            _guessedNumbers = new List<GuessedNumber>(MaxNumberOfGuesses);
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
                return Count < MaxNumberOfGuesses && !_guessedNumbers.Any(gn => gn.Outcome == Outcome.Right);
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

           if (guess > 100 || guess < 1)
           {
                   throw new ArgumentOutOfRangeException();
           }
        
           if (CanMakeGuess)
           {
               if (_guessedNumbers.Any(gn => gn.Number == guess)) 
               {
                   _lastGuessedNumber.Outcome = Outcome.OldGuess;  
               }
                else {
                    if (guess == _number)
                    {
                        _lastGuessedNumber.Outcome = Outcome.Right;
                    }
                    if (guess < _number)
                    {
                        _lastGuessedNumber.Outcome = Outcome.Low;
                    }
                    if (guess > _number)
                    {
                        _lastGuessedNumber.Outcome = Outcome.High;
                    }
                }
           }
           else 
           {
               _lastGuessedNumber.Outcome = Outcome.NoMoreGuesses;
           }
           _lastGuessedNumber.Number = guess;
           _guessedNumbers.Add(LastGuessedNumber);
           return _lastGuessedNumber.Outcome;
        }
    }
}