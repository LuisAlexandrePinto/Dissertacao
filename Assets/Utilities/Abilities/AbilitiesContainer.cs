using System;
using System.Collections.Generic;
using System.Linq;

public class AbilitiesContainer
{
    private Dictionary<ActionType, List<Ability>> actionAbilities = new Dictionary<ActionType, List<Ability>>();
    private Dictionary<AbilityType, List<Ability>> typeAbilities = new Dictionary<AbilityType, List<Ability>>();
    private List<AbilityData> abilitiesData = new List<AbilityData>();
    private List<Ability> allAbilities = new List<Ability>();

    public int AttackPoints { get; private set; } = 0;
    public int DefensePoints { get; private set; } = 0;
    public int SabotagePoints { get; private set; } = 0;
    public List<AbilityData> GetAbilitiesData() => abilitiesData;
    public AbilitiesContainer(List<AbilityData> playerAbilitiesData = null)
    {
        abilitiesData = playerAbilitiesData != null ? playerAbilitiesData : abilitiesData;
        allAbilities = CreateAbilities();
        FillContainners();
        if (abilitiesData != null && abilitiesData.Count > 0)
        {
            abilitiesData.ForEach(data => allAbilities.Find(ability => ability.AbilityIndex == data.Index).InitialiazePoints(data.Points));
            UpdateEffectValues();
        }
        UpdatePoints();
    }

    public AbilitiesContainer(int attackPoints, int defensePoints, int sabotagePoints)
    {
        allAbilities = CreateAbilities();
        FillContainners();
        FillAbilitiesRandom(attackPoints, AbilityType.ATTACK);
        FillAbilitiesRandom(defensePoints, AbilityType.DEFENSE);
        FillAbilitiesRandom(sabotagePoints, AbilityType.SABOTAGE);
        UpdateEffectValues();
        UpdatePoints();
    }

    public int GetPoints(AbilityType type) => GetTypeAbilities(type, true).Sum(ability => ability.Points);
    public string GetPointsToMax(AbilityType type) => GetPoints(type) + "/" + 40;
    private void FillAbilitiesRandom(int linePoints, AbilityType abilityType)
    {
        List<Ability> abilities = GetTypeAbilities(abilityType, false);
        Random rng = new Random();
        int[] indexes = Enumerable.Range(0, abilities.Count).OrderBy(i => rng.Next()).ToArray();
        for (int i = 0; i < indexes.Length; i++)
        {
            int maxPoints = abilities[indexes[i]].MaxPoints;
            abilities[indexes[i]].InitialiazePoints(linePoints >= maxPoints ? maxPoints : linePoints);
            linePoints -= linePoints >= maxPoints ? maxPoints : linePoints;
            if (linePoints <= 0)
            {
                break;
            }
        }
    }  
    public void ApplyEffects(Squadron squadron) => allAbilities.ForEach(ability => ability.ApplyPrimaryEffect(squadron));
    public void ApplyEffectsByAbilityType(Squadron squadron, AbilityType type) => GetTypeAbilities(type, true).ForEach(ability => ability.ApplyPrimaryEffect(squadron));
    public void ApplyEffectsByActionType(Squadron squadron, ActionType actionType) => GetActionAbilities(actionType, true).ForEach(ability => ability.ApplyPrimaryEffect(squadron));
    private void FillContainners()
    {
        Enum.GetValues(typeof(ActionType)).Cast<ActionType>().ToList().ForEach(type => actionAbilities.Add(type, new List<Ability>()));
        Enum.GetValues(typeof(AbilityType)).Cast<AbilityType>().ToList().ForEach(type => typeAbilities.Add(type, new List<Ability>()));
        allAbilities.ForEach(ability => ability.AnexComboAbilities(allAbilities));
        allAbilities.ForEach(ability =>
        {
            actionAbilities[ability.ActionType].Add(ability);
            typeAbilities[ability.AbilityType].Add(ability);
        });
    }

    public void UpdateEffectValues() => allAbilities.ForEach(data => data.ApplyComboPoints());
    public void UpdateAbilitiesValuesWithData()
    {
        allAbilities.ForEach(ability => ability.SavePoints());
        abilitiesData.Clear();
        UpdateAbilitiesData(allAbilities);
    }
    private List<Ability> CreateAbilities()
    {
        return new List<Ability>
        {
            new AtI(),new AtII(),new AtIII(), new AtIV(), new AtV(), new AtVI(), new AtVII(), new ATVIII(), new AtIX(), new AtX(),
            new DfI(),new DfII(), new DfIII(), new DfIV(), new DfV(), new DfVI(), new DfVII(), new DfVIII(), new DfIX(), new DfX(),
            new SabI(),new SabII(),new SabIII(), new SabIV(), new SabV(), new SabVI(), new SabVII(), new SabVIII(), new SabIX(), new SabX()
        };
    }
    private void UpdateAbilitiesData(List<Ability> abilities) => abilities.ForEach(ability => abilitiesData.Add(new AbilityData(ability)));
    public List<Ability> GetActionAbilities(ActionType actionType, bool active) => active ? actionAbilities[actionType].Where(x => x.IsActive()).ToList() : actionAbilities[actionType];
    public List<Ability> GetTypeAbilities(AbilityType abilityType, bool active) => active ? typeAbilities[abilityType].Where(x => x.IsActive()).ToList() : typeAbilities[abilityType];
    public List<Ability> GetNotAppliedTypeAbilities(AbilityType abilityType, bool active) => GetTypeAbilities(abilityType, active).Where(x => !x.EffectApplied).ToList();
    public void ActivatePassiveAbilities(Squadron squadron) => actionAbilities[ActionType.PASSIVE].ForEach(ability => ability.ApplyPrimaryEffect(squadron));    
    private void UpdatePoints()
    {
        AttackPoints = GetTypeAbilities(AbilityType.ATTACK, true).Sum(ability => ability.Points);
        DefensePoints = GetTypeAbilities(AbilityType.DEFENSE, true).Sum(ability => ability.Points);
        SabotagePoints = GetTypeAbilities(AbilityType.SABOTAGE, true).Sum(ability => ability.Points);
    }
    public void ChangeTypePoints(bool incrDecr, AbilityType type)
    {
        switch (type)
        {
            case AbilityType.ATTACK: AttackPoints += incrDecr ? 1 : -1; break;
            case AbilityType.DEFENSE: DefensePoints += incrDecr ? 1 : -1; break;
            case AbilityType.SABOTAGE: SabotagePoints += incrDecr ? 1 : -1; break;
        }
    }    
    public int GetTypePoints(AbilityType type)
    {
        switch (type)
        {
            case AbilityType.NONE: return 0;
            case AbilityType.ATTACK: return AttackPoints;
            case AbilityType.DEFENSE: return DefensePoints;
            case AbilityType.SABOTAGE: return SabotagePoints;
            default: return 0;
        }
    }
}
