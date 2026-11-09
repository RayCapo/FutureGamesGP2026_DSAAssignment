
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace Environment.Tasks
{
    [CreateAssetMenu(fileName = "GuessTheNumber Task", menuName = "Scriptable Objects/GuessTheNumber Task")]
    public class GuessTheNumberTask : Task
    {
       
        private int numberToGuess;

        [SerializeField]
        private string textToPrint = "Welcome to the number guessing game!";

        public override void Execute()
        {
            isCompleted = false;
            numberToGuess = Random.Range(1, 11);
            Debug.Log(numberToGuess + " Is the number");

            GuessTheNumberGUI.Instance.OpenGUI(this);
        }

        public override void Resume()
        {
            GuessTheNumberGUI.Instance.OpenGUI(this);
        }


        public string NumberToGuess(string input)
        {
            int guessedNumber; 

            if(!int.TryParse(input, out guessedNumber))
            {
                return "Enter a number!";
            }

            if(guessedNumber < 1 || guessedNumber > 10)
            {
                return "Must be a number between 1-10";
            } 

            if(guessedNumber == numberToGuess)
            {
                Complete();
                return "You guessed the right number!";
            }

            if(guessedNumber < numberToGuess)
            {
                return "Number to guess is Higher!";
            }
            else
            {
                return "Number to guess is Lower!";
            }

            
        }



    }
}

