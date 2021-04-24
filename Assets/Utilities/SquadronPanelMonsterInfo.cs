using UnityEngine;
using UnityEngine.UI;

public class SquadronPanelMonsterInfo : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Image MonsterHead;
    [SerializeField]
    private Text Name, Type, TypeValue, Level, LevelValue;
#pragma warning restore 0649
    private readonly string atkMonster = "Bloren", defMonster = "BigBoss", sabMonster = "King Salek";
    public void FillTitles(bool realTutorial, MonsterType monsterType, Monster monster = null)
    {
        LanguagesFillers.FillSquadMonsterTitlesSubPanel(Type, Level, TypeValue, monsterType);
        if (realTutorial)
        {
            if (monster != null)
            {
                FillValuesWithMonsterData(monster);
            }            
        }
        else
        {
            if (monster != null)
            {
                FillValuesWithMonsterData(monster);
            }
            else
            {
                switch (monsterType)
                {
                    case MonsterType.ATTACK: FillValuesFictious(atkMonster); break;
                    case MonsterType.DEFENSE: FillValuesFictious(defMonster); break;
                    case MonsterType.SABOTAGE: FillValuesFictious(sabMonster); break;
                }
            }
        }
    }
    private void FillValuesWithMonsterData(Monster monster)
    {
        ImagesFillers.AddMonsterHead(MonsterHead, monster.MonsterName);
        Name.text = monster.MonsterName;
        LevelValue.text = monster.Stats.Level.ToString();
    }
    private void FillValuesFictious(string monsterName)
    {
        ImagesFillers.AddMonsterHead(MonsterHead, monsterName);
        Name.text = sabMonster;
        LevelValue.text = "2";
    }
}
