using UnityEngine;
using UnityEngine.UI;

public class BestiaryPlateManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Text monsterName;
    [SerializeField]
    private Image monsterFace, monsterTypeIcon, monsterPlateBG;
    [SerializeField]
    private Button monsterButton;
#pragma warning restore 0649

    private const string NOT_CATCHED = "???";
    private MonsterRarity rarity;
    public void LinkPrefabToScript(Monster monster, GameObject panelController)
    {
        rarity = monster.GetRarity;
        ImagesFillers.AddMonsterPlate(monsterFace, monsterTypeIcon, monsterPlateBG, monster);
        monsterName.text = !monster.Stats.Catched ? NOT_CATCHED : monster.MonsterName;
        monsterName.color = !monster.Stats.Catched ? Color.white : (monster.Stats.Catched ? Color.green : Color.yellow);
        if (monster.Stats.Catched)
        {
            PanelController controller = panelController.GetComponent<PanelController>();
            monsterButton.onClick.AddListener(() => controller.GoToMonsterPanel(controller.monsterMenu, monster));
        }
    }

    public MonsterRarity GetMonsterRarity() => rarity;
}
