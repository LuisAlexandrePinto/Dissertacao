using UnityEngine;
using UnityEngine.UI;

public class MonsterDamagePanel : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Image MonsterHead;
    [SerializeField]
    private Text NormalDmg, CriticalDmg, PassiveDmg, FaintedState, RevivedState, Heal;
#pragma warning restore 0649
    public void Initialize(string name, string normal, string critical, string passive, 
        bool fainted, bool revive, string heal)
    {
        ImagesFillers.AddMonsterHead(MonsterHead, name);        
        NormalDmg.text = normal;
        CriticalDmg.text = critical;
        PassiveDmg.text = passive;
        LanguagesFillers.FillDamageSubPanel(fainted, FaintedState, revive, RevivedState);
        Heal.text = heal;
    }
}
