using Environment.Tasks;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class SortJsonTaskGUI : MonoBehaviour
{

    public static SortJsonTaskGUI Instance { get; private set; }

    [SerializeField] public GameObject sortJsonPanel;
    [SerializeField] private Button sortbutton;
    [SerializeField] private TMP_Text computerTalkTextField;
    [SerializeField] private InputActionReference closeAction;
    [SerializeField] private PlayerMovement playerMovement;

    private SortJsonTask currentTask;

    private void Awake()
    {
        Instance = this;
        sortJsonPanel.SetActive(false);
        computerTalkTextField.text = "Press the button to sort the worker data by lastEntranceInEngineRoom";
    }

    
    public void OpenGUI(SortJsonTask task)
    {
        currentTask = task;
        computerTalkTextField.text = "Press the button to sort the worker data by lastEntranceInEngineRoom";
        sortJsonPanel.SetActive(true);
        playerMovement.enabled = false;

    }
    public void CloseGUI()
    {
        sortJsonPanel.SetActive(false);
        playerMovement.enabled = true;

    }

    public void SortWorkerData()
    {
        if (currentTask == null) return;

        currentTask.SortData();

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
