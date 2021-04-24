using System.Collections.Generic;
using System.Linq;

public abstract class Ability
{
    protected const int ZERO = 0;
    public abstract int MaxPoints { get; }
    public abstract int MaxComboPoints { get; }
    public abstract float PrimaryValue { get; }
    public abstract float SecondaryValue { get; }
    public abstract float ConditionValue { get; }
    public abstract ActionType ActionType { get; }
    public abstract AbilityIndex AbilityIndex { get; }
    public abstract AbilityType AbilityType { get; }
    public List<AbilityIndex> ComboNames { get => AbilitiesCombosIndex.GetCombosByAbilityIndex(AbilityIndex); }
    public int Points { get; private set; } = ZERO;
    public int OldPoints { get; private set; } = ZERO;
    public int ComboPoints { get; private set; } = ZERO;
    public float EffectValue { get => Points * PrimaryValue; }
    public float ChanceValue { get => Points * ConditionValue; }
    public float ComboEffectValue { get => ComboPoints * SecondaryValue; }
    public string Description => GetDescription();
    public List<Ability> ComboAbilities { get; private set; }
    public string AbilityName => GetName();
    public bool EffectApplied { get; protected set; } = false;
    public bool IsActive() => Points > ZERO;
    public bool IsChanged() => Points != OldPoints;
    public void SavePoints() => OldPoints = IsChanged() ? Points : OldPoints;
    protected void PutComboPoints(int points) => ComboPoints = IsActive() && points <= MaxComboPoints && points >= ZERO ? points : ZERO;
    public bool CanIncrement() => Points < MaxPoints && GameManager.Instance.CurrentPlayer.PlayerPoints > 0;
    public bool CanDecrement() => IsActive() && Points > 0;

    protected void ChangePoints(bool incrDecr)
    {
        Points += incrDecr ? 1 : -1;
        GameManager.Instance.CurrentPlayer.PlayerPoints += !incrDecr ? 1 : -1;
        GameManager.Instance.AbilitiesContainer.ChangeTypePoints(incrDecr, AbilityType);
        ApplyComboPoints();

    }

    public void IncreasePoints()
    {
        if (CanIncrement())
        {
            ChangePoints(true);
        }
    }
    public void DecreasePoints()
    {
        if (CanDecrement())
        {
            ChangePoints(false);
            /*Points--;
            ApplyComboPoints();
            GameManager.Instance.CurrentPlayer.PlayerPoints++;*/
        }
    }
    public string FormatedPoints() => Points + "/" + MaxPoints;
    public void InitialiazePoints(int points)
    {
        Points = OldPoints = points;
        GameManager.Instance.CurrentPlayer.PlayerPoints -= points;

    }
    public abstract void ApplyPrimaryEffect(Squadron squadron = null);
    /// <summary>
    /// Searches within the list of abilities that combo with the ability itself.
    /// In this ability the combo is based on the other abilities having all points capped.
    /// </summary>
    /// <returns></returns>
    public abstract void ApplyComboPoints();
    public abstract bool ComboOn();
    protected abstract string GetName();
    protected abstract string GetDescription();
    /// <summary>
    /// Searches within the list passed trough parameter for abilities with the respective names and links them to 
    /// the responsible container list of abilities that combo with the ability itself.
    /// </summary>
    /// <param name="abilities">List of all abilities of the game.</param>
    public void AnexComboAbilities(List<Ability> abilities) => ComboAbilities = abilities.Where(ability => ComboNames.Contains(ability.AbilityIndex)).ToList();
}
