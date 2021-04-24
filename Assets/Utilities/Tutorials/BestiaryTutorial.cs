using UnityEngine;
using UnityEngine.UI;

public class BestiaryTutorial : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private GameObject TutorialUI, Types, Rarities, Plates, MonsterList;
    [SerializeField]
    private Text typesSubtitle, raritiesSubtitle, platesSubtitle, monsterListSubtitle;
    [SerializeField]
    private Button Close, Previous, Next;
    [SerializeField]
    private TutorialFooterManager footerManager;
#pragma warning restore 0649
    private int state;
    private void Awake()
    {
        Close.onClick.AddListener(() => CloseTutorial());        
        Previous.onClick.AddListener(() => PresentTutorial(false));
        Next.onClick.AddListener(() => PresentTutorial(true));
    }
    private void OnEnable()
    {
        state = -1;
        footerManager.Initialize(true);
        LanguagesFillers.FillBestiaryTutorial(typesSubtitle, raritiesSubtitle, platesSubtitle, monsterListSubtitle);
        PresentTutorial(true);
    }
    private void StateManager(bool incrDecr, int max)
    {        
        state = incrDecr ? state + 1 : state - 1;
        state = state < 0 ? 0 : state;
        state = state > max ? max : state;
    }
    private void PresentTutorial(bool nextPrevious)
    {
        StateManager(nextPrevious, 4);
        if(state == 0)
        {
            TurnOptionsOff();
            TurnOptionOn(Types);
        }
        if (state == 1)
        {
            TurnOptionsOff();
            TurnOptionOn(Rarities);
        }
        if (state == 2)
        {
            TurnOptionsOff();
            TurnOptionOn(Plates);
            footerManager.Initialize(true);
        }
        if (state == 3)
        {
            TurnOptionsOff();
            TurnOptionOn(MonsterList);
            footerManager.Initialize(false);
        }
        if (state == 4)
        {
            CloseTutorial();
        }        
    }
    private void CloseTutorial()
    {
        footerManager.MarkTutorial();
        TutorialUI.SetActive(false);
    }
    private void TurnOptionOn(GameObject option) => option.SetActive(true);
    private void TurnOptionsOff()
    {
        Types.SetActive(false);
        Rarities.SetActive(false);
        Plates.SetActive(false);
        MonsterList.SetActive(false);
    }
}
