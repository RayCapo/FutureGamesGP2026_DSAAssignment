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

    private AdvancedDataStructTask currentTask;

    private void Awake()
    {
        Instance = this;
        ADSTPanel.SetActive(false);
        computerTalkTextField.text = "Press the button to sort the worker data by lastEntranceInEngineRoom";
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
    public void SortWorkerData()
    {
        if (currentTask == null) return;

        //currentTask.SortData();

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
