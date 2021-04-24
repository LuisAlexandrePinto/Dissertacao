using System;

[Serializable]
public class AbilityData
{
    public AbilityIndex Index { get; private set; }
    public ActionType ActionType { get; private set; }
    public int Points { get; private set; }
    public AbilityData(Ability ability)
    {
        Index = ability.AbilityIndex;
        Points = ability.Points;
        ActionType = ability.ActionType;
    }
}
