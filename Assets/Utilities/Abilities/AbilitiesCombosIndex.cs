using System.Collections.Generic;
using System.Linq;

public static class AbilitiesCombosIndex
{
    public static List<AbilityIndex> GetCombosByAbilityIndex(AbilityIndex index)
    {
        switch (index)
        {
            case AbilityIndex.ATTACK1: return CreateList(AbilityIndex.DEFENSE1, AbilityIndex.SABOTAGE1);
            case AbilityIndex.ATTACK2: return CreateList(AbilityIndex.DEFENSE2, AbilityIndex.SABOTAGE2);
            case AbilityIndex.ATTACK3: return CreateList(AbilityIndex.DEFENSE5, AbilityIndex.SABOTAGE9);
            case AbilityIndex.ATTACK4: return CreateList(AbilityIndex.DEFENSE10);
            case AbilityIndex.ATTACK5: return CreateList(AbilityIndex.DEFENSE9);
            case AbilityIndex.ATTACK6: return CreateList(AbilityIndex.DEFENSE4, AbilityIndex.SABOTAGE10);
            case AbilityIndex.ATTACK7: return CreateList(AbilityIndex.ATTACK8, AbilityIndex.ATTACK9);
            case AbilityIndex.ATTACK8: return CreateList(AbilityIndex.ATTACK7, AbilityIndex.ATTACK9);
            case AbilityIndex.ATTACK9: return CreateList(AbilityIndex.ATTACK7, AbilityIndex.ATTACK8);
            case AbilityIndex.ATTACK10: return CreateList(AbilityIndex.DEFENSE3, AbilityIndex.SABOTAGE10);
            case AbilityIndex.DEFENSE1: return CreateList(AbilityIndex.ATTACK1, AbilityIndex.SABOTAGE1);
            case AbilityIndex.DEFENSE2: return CreateList(AbilityIndex.ATTACK2, AbilityIndex.SABOTAGE2);
            case AbilityIndex.DEFENSE3: return CreateList(AbilityIndex.ATTACK10, AbilityIndex.SABOTAGE6);
            case AbilityIndex.DEFENSE4: return CreateList(AbilityIndex.ATTACK6, AbilityIndex.SABOTAGE10);
            case AbilityIndex.DEFENSE5: return CreateList(AbilityIndex.ATTACK3, AbilityIndex.SABOTAGE9);
            case AbilityIndex.DEFENSE6: return CreateList(AbilityIndex.DEFENSE7, AbilityIndex.DEFENSE8);
            case AbilityIndex.DEFENSE7: return CreateList(AbilityIndex.DEFENSE6, AbilityIndex.DEFENSE8);
            case AbilityIndex.DEFENSE8: return CreateList(AbilityIndex.DEFENSE6, AbilityIndex.DEFENSE7);
            case AbilityIndex.DEFENSE9: return CreateList(AbilityIndex.ATTACK5);
            case AbilityIndex.DEFENSE10: return CreateList(AbilityIndex.ATTACK4);
            case AbilityIndex.SABOTAGE1: return CreateList(AbilityIndex.ATTACK1, AbilityIndex.DEFENSE1);
            case AbilityIndex.SABOTAGE2: return CreateList(AbilityIndex.ATTACK2, AbilityIndex.DEFENSE2);
            case AbilityIndex.SABOTAGE3: return CreateList(AbilityIndex.SABOTAGE4, AbilityIndex.SABOTAGE5);
            case AbilityIndex.SABOTAGE4: return CreateList(AbilityIndex.SABOTAGE3, AbilityIndex.SABOTAGE5);
            case AbilityIndex.SABOTAGE5: return CreateList(AbilityIndex.SABOTAGE3, AbilityIndex.SABOTAGE4);
            case AbilityIndex.SABOTAGE6: return CreateList(AbilityIndex.DEFENSE3, AbilityIndex.ATTACK10);
            case AbilityIndex.SABOTAGE7: return CreateList(AbilityIndex.SABOTAGE8);
            case AbilityIndex.SABOTAGE8: return CreateList(AbilityIndex.SABOTAGE7);
            case AbilityIndex.SABOTAGE9: return CreateList(AbilityIndex.DEFENSE5, AbilityIndex.ATTACK3);
            case AbilityIndex.SABOTAGE10: return CreateList(AbilityIndex.DEFENSE4, AbilityIndex.ATTACK6);
            default: return CreateList();
        }
    }

    private static List<AbilityIndex> CreateList(params AbilityIndex[] names) => names.ToList();
}
