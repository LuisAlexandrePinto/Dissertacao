using UnityEngine;
using UnityEngine.UI;

public class MonstersPlayerManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Text 
        Monsters, Saw, SawValue, NonCaptured, NonCapturedValue, Captured, 
        CapturedValue, Common, CommonValue, Incommon, IncommonValue, Rare, 
        RareValue, Mythic, MythicValue, CaptureRatio, CaptureRatioValue;
#pragma warning restore 0649
    public void Initialize(MonsterManager monsterManager)
    {            
        LanguagesFillers.FillMonstersSubPanel(Monsters, Saw, NonCaptured, Captured, Common, Incommon, Rare, Mythic, CaptureRatio);
        SawValue.text = monsterManager.TotalSaw.ToString();
        NonCapturedValue.text = monsterManager.TotalNonCaptured.ToString();
        CapturedValue.text = monsterManager.TotalCaught.ToString();
        CommonValue.text = monsterManager.HowManyCaught(MonsterRarity.COMMON).ToString();
        IncommonValue.text = monsterManager.HowManyCaught(MonsterRarity.UNCOMMON).ToString();
        RareValue.text = monsterManager.HowManyCaught(MonsterRarity.RARE).ToString();
        MythicValue.text = monsterManager.HowManyCaught(MonsterRarity.MYTHIC).ToString();
        CaptureRatioValue.text = monsterManager.CaptureRatio().ToString();
    }
}
