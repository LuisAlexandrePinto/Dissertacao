using UnityEngine;
using UnityEngine.UI;
public class XPPlayerManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Text Xp, ActualXp, ActualValue, NeededXp, NeededValue;
#pragma warning restore 0649
    public void Initialize(Player player)
    {
        LanguagesFillers.FillXpSubPanel(Xp, ActualXp, NeededXp);
        ActualValue.text = player.Xp.ToString();
        NeededValue.text = player.NeededXp.ToString();
    }
}
