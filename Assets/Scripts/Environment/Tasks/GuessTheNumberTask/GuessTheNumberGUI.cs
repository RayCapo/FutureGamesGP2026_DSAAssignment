using Player;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


namespace Environment.Tasks
{
    public class GuessTheNumberGUI : MonoBehaviour
    {
        public static GuessTheNumberGUI Instance { get; private set; }

        [SerializeField] public GameObject guessPanel;
        [SerializeField] private TMP_InputField inputField; // input field for the player to enter their guess
        [SerializeField] private TMP_Text computerTalkTextField; // Text field for the computers output
        [SerializeField] private InputActionReference closeAction;

        [SerializeField] private PlayerMovement playerMovement;

        private GuessTheNumberTask currentTask;


        private void Awake()
        {
            Instance = this;
            guessPanel.SetActive(false);
            inputField.onSubmit.AddListener(WhenSubmit);
        }

        public void OpenGUI(GuessTheNumberTask task)
        {
            currentTask = task;
            computerTalkTextField.text = "You must type a number between 1-10.";
            inputField.text = "";
            guessPanel.SetActive(true);
            inputField.ActivateInputField();
            playerMovement.enabled = false;
        }
        public void CloseGUI()
        {
            guessPanel.SetActive(false);
            playerMovement.enabled = true;
        }

        private void WhenSubmit(string text)
        {
            if (currentTask == null) return;

            computerTalkTextField.text = currentTask.NumberToGuess(text);
            inputField.text = "";

            if (currentTask.isCompleted)
            {
                currentTask = null;
                Invoke(nameof(CloseGUI), .5f);

            }
            else
            {
                inputField.ActivateInputField();
            }


        }

        //Press Escape and close UI

        private void OnEnable()
        {
            closeAction.action.performed += CloseKeyPressed;
            closeAction.action.Enable();
        }

        private void OnDisable()
        {
            closeAction.action.performed -= CloseKeyPressed;
            closeAction.action.Disable();
        }

        private void CloseKeyPressed(InputAction.CallbackContext context)
        {
            CloseGUI();
        }
        //-----------------------------------------------------------------

    }

}
