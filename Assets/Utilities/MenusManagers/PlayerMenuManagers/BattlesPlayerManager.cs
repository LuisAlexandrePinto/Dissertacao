using UnityEngine;
using UnityEngine.UI;

public class BattlesPlayerManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Text 
        Battles, TotalBattles, TotalBattlesValue, Retreat, RetreatValue,
        Lost, LostValue, Won, WonValue, WinRatio, WinRatioValue;
#pragma warning restore 0649
    public void Initialize(Player player)
    {
        LanguagesFillers.FillBatlesSubPanel(Battles, TotalBattles, Retreat, Lost, Won, WinRatio);
        TotalBattlesValue.text = player.TotalBattles.ToString();
        RetreatValue.text = player.RetreatBattles.ToString();
        LostValue.text = player.LostBattles.ToString();
        WonValue.text = player.WonBattles.ToString();
        WinRatioValue.text = player.WinRatio.ToString();
    }
}
