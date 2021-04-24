using UnityEngine;
using UnityEngine.UI;

public class CaptureResultManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Text Title, Name, SawTitle, SawValue, CaptureTitle, CaptureValue, 
        LevelTitle, LevelValue, BackBtnTitle, PotionsTitle, HPTitle, HPValue, InspTitle, InspValue;
    [SerializeField]
    private Image MonsterHead;
    [SerializeField]
    private GameObject Capture, Level;
    [SerializeField]
    private Button BackBtn;
#pragma warning restore 0649    
    public void Initialize(string monsterName, bool captured, bool evolved)
    {
        Monster monster = GameManager.Instance.MonsterManager.GetMonsterByName(monsterName);        
        ImagesFillers.AddMonsterHead(MonsterHead, monsterName);       
        LanguagesFillers.FillCaptureResult(Title, BackBtnTitle, SawTitle, CaptureTitle, 
            LevelTitle, evolved, captured, PotionsTitle, HPTitle, InspTitle);
        FillMonsterStats(monster, captured);
        FillPotionsValues(captured);
        BackBtn.onClick.AddListener(() => SceneTransitionManager.Instance.GoToScene(SquadUpConstants.SCENE_WORLD));
    }
    private void FillMonsterStats(Monster monster, bool captured)
    {
        Name.text = monster.MonsterName;
        SawValue.text = monster.Stats.SeenAmount.ToString();
        CaptureValue.text = monster.Stats.CatchedAmount.ToString();
        LevelValue.text = monster.Stats.Catched ? monster.Stats.Level.ToString() : "1";
        Capture.SetActive(captured);
        Level.SetActive(captured);
    }   
    private void FillPotionsValues(bool captured)
    {
        string add = "+";
        int min = 0, max = captured ? 6 : 4;        
        int hp = MathConts.RandomInt(min, max), insp = MathConts.RandomInt(min, max);
        HPValue.text = add + hp.ToString();
        InspValue.text = add + insp.ToString();
        GameManager.Instance.CurrentPlayer.HpPotions += hp;
        GameManager.Instance.CurrentPlayer.InspPotions += insp;
    }
}
