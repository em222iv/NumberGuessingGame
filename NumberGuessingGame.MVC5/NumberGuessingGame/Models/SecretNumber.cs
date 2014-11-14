using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using NumberGuessingGame.Models.Rules;

namespace NumberGuessingGame.Models
{

    public class SecretNumber
    {

        Random rnd = new Random();
        private List<GuessedNumber> _guessedNumbers;
        private GuessedNumber _lastGuessedNumber = new GuessedNumber();
        private int? _number;
        private int MaxNumberOfGuesses = 7;



        public SecretNumber()
        {
            _guessedNumbers = new List<GuessedNumber>(MaxNumberOfGuesses);
            Initialize();
        }

        public void Initialize()
        {
            Random random = new Random();
            _number = random.Next(1, 101);
            _guessedNumbers.Clear();
            _lastGuessedNumber.Number = null;
            _lastGuessedNumber.Outcome = Outcome.Indefinite;
        }




        //public int MaxNumberOfGuesses { get { return _maxNumberOfGuesses; } }

        //public void setAmountOfGuesses(ISetting setting)
        //{
        //    _maxNumberOfGuesses = setting.MaxNumberOfGuesses();
        //}



        public int Count
        {
            get
            {
                return _guessedNumbers.Count;
            }
        }
        public bool CanMakeGuess
        {
            get
            {
                return Count < MaxNumberOfGuesses && !GuessedNumbers.Any(gn => gn.Outcome == Outcome.Right);
            }


        }

        public IList<GuessedNumber> GuessedNumbers { get { return _guessedNumbers.AsReadOnly(); } }
        public GuessedNumber LastGuessedNumber { get { return _lastGuessedNumber; } }
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

        public Outcome MakeGuess(int guess)
        {
            if (guess < 1 || guess > 100)
            {
                throw new ArgumentOutOfRangeException("Valid range 1-100");
            }

            if (CanMakeGuess)
            {
                if (GuessedNumbers.Any(gn => gn.Number == guess))
                {
                    _lastGuessedNumber.Outcome = Outcome.OldGuess;
                }
                else
                {
                    _lastGuessedNumber = new GuessedNumber();
                    _lastGuessedNumber.Number = guess;
                    _guessedNumbers.Add(_lastGuessedNumber);

                    if (guess > _number)
                    {
                        _lastGuessedNumber.Outcome = Outcome.High;
                    }
                    if (guess < _number)
                    {
                        _lastGuessedNumber.Outcome = Outcome.Low;
                    }
                    if (guess == _number)
                    {
                        _lastGuessedNumber.Outcome = Outcome.Right;
                    }
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