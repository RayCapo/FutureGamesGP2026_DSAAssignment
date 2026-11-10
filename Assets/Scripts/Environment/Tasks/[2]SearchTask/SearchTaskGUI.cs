using Environment.Tasks;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;



public class SearchTaskGUI : MonoBehaviour
{

    public static SearchTaskGUI Instance { get; private set; }

    [SerializeField] public GameObject searchPanel;
    [SerializeField] private Button searchButton;
    [SerializeField] private TMP_Text computerTalkTextField;

    [SerializeField] public TMP_InputField lowValueInputField;
    [SerializeField] public TMP_InputField highValueInputField;


    [SerializeField] private InputActionReference closeAction;

    [SerializeField] private PlayerMovement playerMovement;


    private SearchTask currentTask;


    private void Awake()
    {
        Instance = this;
        searchPanel.SetActive(false);
        computerTalkTextField.text = "Set the value range and press the Search button to search for worker data";
        
    }

    
    public void OpenGUI(SearchTask task)
    {
        currentTask = task;
        computerTalkTextField.text = "Set the value range and press the Search button to search for worker data";
        searchPanel.SetActive(true);
        playerMovement.enabled = false;
    }
    public void CloseGUI()
    {
        searchPanel.SetActive(false);
        playerMovement.enabled = true;
        
    }

    public void SearchButton()
    {
        if (currentTask == null) return;

        if (!InputCheckGuard(out int lowValue, out int highValue)) return;
        
        currentTask.Search(lowValue, highValue);

        if (currentTask.isCompleted)
        {
            currentTask = null;
            Invoke(nameof(CloseGUI), .5f);
        }
        else
        {
            return;
        }

    }

    private bool InputCheckGuard(out int lowValue, out int highValue)
    {
        lowValue = 0;
        highValue = 0;

        if (lowValueInputField.text == "" || highValueInputField.text == "")
        {
            computerTalkTextField.text = "Please enter both LOW and HIGH values between 0 - 2500";
            return false;
        }
        else if(!HasFourDigits(lowValueInputField.text) || !HasFourDigits(highValueInputField.text))
        {
            computerTalkTextField.text = "Please enter exactly 4 numbers for both LOW and HIGH values";
            return false;
        }
        else if (!int.TryParse(lowValueInputField.text, out lowValue) || !int.TryParse(highValueInputField.text, out highValue))
        {
            computerTalkTextField.text = "Please enter ONLY numbers between 0 - 2500";
            return false;
        }
        else if (lowValue < 0 || lowValue > 2500 || highValue < 0 || highValue > 2500)
        {
            computerTalkTextField.text = "Please enter values between 0 - 2500";
            return false;
        }
        else if (lowValue >= highValue)
        {
            computerTalkTextField.text = "LOW value must be less than HIGH value";
            return false;
        }

        return true;
    }
    
    private bool HasFourDigits(string text)
    {
        if (text.Length != 4) return false;

        foreach (char c in text)
        {
            if(!char.IsDigit(c)) return false;
        }
        return true;
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
