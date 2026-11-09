using Environment.Tasks;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class GatherJsonTaskGUI : MonoBehaviour
{

    public static GatherJsonTaskGUI Instance { get; private set; }

    [SerializeField] public GameObject jsonPanel;
    [SerializeField] private Button downloadbutton;
    [SerializeField] private TMP_Text computerTalkTextField;
    [SerializeField] private InputActionReference closeAction;

    [SerializeField] private PlayerMovement playerMovement;
    private GatherJsonTask currentTask;


    private void Awake()
    {
        Instance = this;
        jsonPanel.SetActive(false);
        computerTalkTextField.text = "Press the Download button to gather the worker data";
        
    }

    
    public void OpenGUI(GatherJsonTask task)
    {
        currentTask = task;
        computerTalkTextField.text = "Press the Download button to gather the worker data";
        jsonPanel.SetActive(true);
        playerMovement.enabled = false;
    }
    public void CloseGUI()
    {
        jsonPanel.SetActive(false);
        playerMovement.enabled = true;
    }

    public void DownloadJson()
    {
        if (currentTask == null) return;

        currentTask.SendData();

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
