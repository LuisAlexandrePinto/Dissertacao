using UnityEngine;
using UnityEngine.UI;

public class PointsPlayerManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Text Points, ForUse, ForUseValue, AllPoints, AllPointsValue;
#pragma warning restore 0649
    public void Initialize(Player player)
    {
        LanguagesFillers.FillPointsSubPanel(Points, ForUse, AllPoints);
        ForUseValue.text = player.PlayerPoints.ToString();
        AllPointsValue.text = player.PlayerMaxPoints.ToString();
    }
}
