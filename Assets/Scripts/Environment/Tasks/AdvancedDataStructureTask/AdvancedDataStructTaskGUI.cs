using Environment.Tasks;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class AdvancedDataStructTaskGUI : MonoBehaviour
{

    public static AdvancedDataStructTaskGUI Instance { get; private set; }

    [SerializeField] public GameObject ADSTPanel;
    [SerializeField] private Button button;
    [SerializeField] private TMP_Text computerTalkTextField;
    [SerializeField] private InputActionReference closeAction;
    [SerializeField] private PlayerMovement playerMovement;

    [SerializeField] public TMP_InputField yearsLowValueInputField;
    [SerializeField] public TMP_InputField yearsHighValueInputField;
    [SerializeField] public TMP_InputField monthLowValueInputField;
    [SerializeField] public TMP_InputField monthHighValueInputField;
    [SerializeField] public TMP_InputField dayLowValueInputField;
    [SerializeField] public TMP_InputField dayHighValueInputField;
    [SerializeField] public TMP_InputField hoursLowValueInputField;
    [SerializeField] public TMP_InputField hoursHighValueInputField;


    private AdvancedDataStructTask currentTask;

    private void Awake()
    {
        Instance = this;
        ADSTPanel.SetActive(false);
        computerTalkTextField.text = "Press the button to sort the worker data by lastEntranceInEngineRoom";

        yearsLowValueInputField.text = "2234";
        yearsHighValueInputField.text = "2234";
        monthLowValueInputField.text = "08";
        monthHighValueInputField.text = "08";
        dayLowValueInputField.text = "09";
        dayHighValueInputField.text = "09";
        hoursLowValueInputField.text = "22";
        hoursHighValueInputField.text = "23";
    }

    //Open GUI
    public void OpenGUI(AdvancedDataStructTask task)
    {
        currentTask = task;
        computerTalkTextField.text = "Press the button to sort the worker data by lastEntranceInEngineRoom";
        ADSTPanel.SetActive(true);
        playerMovement.enabled = false;

    }
    //Close Button
    public void CloseGUI()
    {
        ADSTPanel.SetActive(false);
        playerMovement.enabled = true;

    }

    //Button
    public void SortBuildAndSearchButton()
    {
        if (currentTask == null) return;

        if (!InputCheckGuard(out int yearsLowValue, out int yearsHighValue, 
            out int monthLowValue, out int monthHighValue, out int dayLowValue, out int dayHighValue, out int hoursLowValue, out int hoursHighValue)) return;

        currentTask.SortBuildAndSearch(yearsLowValue, yearsHighValue, monthLowValue, monthHighValue, dayLowValue, dayHighValue, hoursLowValue, hoursHighValue);

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
    private bool InputCheckGuard(out int yearsLowValue, out int yearsHighValue, 
        out int monthLowValue, out int monthHighValue, out int dayLowValue, 
        out int dayHighValue, out int hoursLowValue, out int hoursHighValue)
    {
        yearsLowValue = 0;
        yearsHighValue = 0;
        monthLowValue = 0;
        monthHighValue = 0;
        dayLowValue = 0;
        dayHighValue = 0;
        hoursLowValue = 0;
        hoursHighValue = 0;

        if (yearsLowValueInputField.text == "" || yearsHighValueInputField.text == "" || monthLowValueInputField.text == "" || 
            monthHighValueInputField.text == "" || dayLowValueInputField.text == "" || dayHighValueInputField.text == "" || hoursLowValueInputField.text == "" || hoursHighValueInputField.text == "")
        {
            computerTalkTextField.text = "Please enter both LOW and HIGH values between 0 - 2500";
            return false;
        }
        else if (!HasFourDigits(yearsLowValueInputField.text) || !HasFourDigits(yearsHighValueInputField.text))
        {
            computerTalkTextField.text = "Please enter exactly 4 numbers for both LOW and HIGH values";
            return false;
        }
        else if (!HasTwoDigits(monthLowValueInputField.text) || !HasTwoDigits(monthHighValueInputField.text))
        {
            computerTalkTextField.text = "Please enter exactly 2 numbers for both LOW and HIGH values";
            return false;
        }
        else if (!HasTwoDigits(dayLowValueInputField.text) || !HasTwoDigits(dayHighValueInputField.text))
        {
            computerTalkTextField.text = "Please enter exactly 2 numbers for both LOW and HIGH values";
            return false;
        }
        else if (!HasTwoDigits(hoursLowValueInputField.text) || !HasTwoDigits(hoursHighValueInputField.text))
        {
            computerTalkTextField.text = "Please enter exactly 2 numbers for both LOW and HIGH values";
            return false;
        }
        else if (!int.TryParse(yearsLowValueInputField.text, out yearsLowValue) ||  !int.TryParse(yearsHighValueInputField.text, out yearsHighValue))
        {
            computerTalkTextField.text = "Please enter ONLY numbers between 0 - 2500";
            return false;
        }
        else if (!int.TryParse(monthLowValueInputField.text, out monthLowValue) || !int.TryParse(monthHighValueInputField.text, out monthHighValue))
        {
            computerTalkTextField.text = "Please enter ONLY numbers between 0 - 31";
            return false;
        }
        else if (!int.TryParse(dayLowValueInputField.text, out dayLowValue) || !int.TryParse(dayHighValueInputField.text, out dayHighValue))
        {
            computerTalkTextField.text = "Please enter ONLY numbers between 0 - 31";
            return false;
        }
        else if (!int.TryParse(hoursLowValueInputField.text, out hoursLowValue) ||  !int.TryParse(hoursHighValueInputField.text, out hoursHighValue))
        {
            computerTalkTextField.text = "Please enter ONLY numbers between 0 - 23";
            return false;
        }
        else if (yearsLowValue < 0 || yearsLowValue > 2500 || yearsHighValue < 0 || yearsHighValue > 2500)
        {
            computerTalkTextField.text = "Please enter values between 0 - 2500";
            return false;
        }
        else if (monthLowValue < 0 || monthLowValue > 31 || monthHighValue < 0 || monthHighValue > 31)
        {
            computerTalkTextField.text = "Please enter values between 0 - 31";
            return false;
        }
        else if (dayLowValue < 0 || dayLowValue > 31 || dayHighValue < 0 || dayHighValue > 31)
        {
            computerTalkTextField.text = "Please enter values between 0 - 31";
            return false;
        }
        else if (hoursLowValue < 0 || hoursLowValue > 23 || hoursHighValue < 0 || hoursHighValue > 23)
        {
            computerTalkTextField.text = "Please enter values between 0 - 23";
            return false;
        }
        else if (yearsLowValue > yearsHighValue)
        {
            computerTalkTextField.text = "LOW value must be less or equal to HIGH value";
            return false;
        }
        //else if (monthLowValue > monthHighValue)
        //{
        //    computerTalkTextField.text = "LOW value must be less than HIGH value";
        //    return false;
        //}
        //else if (dayLowValue > dayHighValue)
        //{
        //    computerTalkTextField.text = "LOW value must be less than HIGH value";
        //    return false;
        //}
        //else if (hoursLowValue > hoursHighValue)
        //{
        //    computerTalkTextField.text = "LOW value must be less than HIGH value";
        //    return false;
        //}

        return true;
    }

    private bool HasFourDigits(string text)
    {
        if (text.Length != 4) return false;

        foreach (char c in text)
        {
            if (!char.IsDigit(c)) return false;
        }
        return true;
    }

    private bool HasTwoDigits(string text)
    {
        if (text.Length != 2) return false;
        foreach (char c in text)
        {
            if (!char.IsDigit(c)) return false;
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
