using UnityEngine;
using UnityEngine.UI;

public class SquadronMenuManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Image Background;
    [SerializeField]
    private MenuHeaderManager headerManager;    
    [SerializeField]
    private GameObject TutorialUI;
    [SerializeField]
    private Button HelpBtn;
#pragma warning restore 0649
    private void Awake() => HelpBtn.onClick.AddListener(() => TurnOnTutorial());
    private void OnEnable()
    {
        CheckTutorial();
        ImagesFillers.AddRandomMenuBackground(Background);
       
        headerManager.Initialize();             
    }
    private void TurnOnTutorial() => TutorialUI.SetActive(true);
    private void CheckTutorial()
    {
        if (PlayerPrefs.GetInt(SquadUpConstants.SQUADRON_TUTORIAL) == 0)
        {
            TurnOnTutorial();
        }
    }
}
