using System.Threading.Tasks;
using UnityEngine;
using System;



namespace Environment.Tasks
{
    [CreateAssetMenu(fileName = "GuessTheNumber Task", menuName = "GuessTheNumber Task")]
    public class GuessTheNumberTask : Task
    {
        bool isTaskCompleted = false;
        int numberToGuess = UnityEngine.Random.Range(1, 11);
        int guessedNumber = 0;


        [SerializeField]
        private string textToPrint = "Hi, I'm a test task!";

        public override void Execute() {

            Debug.Log(textToPrint);

            if(isTaskCompleted) return;
            
            Debug.Log("Please enter a number between 1 and 10:");
            string input = Console.ReadLine();
            guessedNumber = Convert.ToInt32(input);

            if (guessedNumber == numberToGuess)
            {
                Debug.Log("Congratulations! You guessed the correct number: " + numberToGuess);
                isTaskCompleted = true;
            }

            if (guessedNumber < numberToGuess)
            {
                Debug.Log("Too low! Try again.");
            }
            else if (guessedNumber > numberToGuess)
            {
                Debug.Log("Too high! Try again.");
            }
           
        }
    }
}

