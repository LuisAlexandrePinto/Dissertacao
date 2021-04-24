using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class AbilityPrefabManager : MonoBehaviour
{
    [SerializeField]
    protected GameObject abilityPrefab;
    [SerializeField]
    protected Image icon, comboIcon1, comboIcon2, comboBg1, comboBg2;
    [SerializeField]
    protected Text title, counter, comboCounter1, comboCounter2, combo, description;
    [SerializeField]
    protected Button minusButton, plusButton;
    [SerializeField]
    private AudioSource ButtonSound;

    private Text userCounter, typeCounter;
    private Ability ability;
    private List<AbilityPrefabManager> combos;
    private const string iconsDir = "Sprites/AbilitiesIcons/";
    private const string bgDir = "Sprites/Backgrounds/";

    private void OnEnable() => ApplyChanges();    
    private void ApplyChanges()
    {
        if (ability != null)
        {
            CheckForComboAndApply();
            UpdateTexts();
            UpdateTextCounters();
            MarkIfCombo();
        }
    }

    public void LinkPrefabToScript(Ability ability, Text counter, Text userCounter)
    {        
        this.ability = ability;
        typeCounter = counter;
        this.userCounter = userCounter;
        ability.ApplyComboPoints();
        minusButton.onClick.AddListener(() =>
            {
                ButtonSound.Play();
                ability.DecreasePoints();
                ApplyChanges();
                UpdateComboManagers();
                ApplyBranchCountersChanges();
            }
        );
        plusButton.onClick.AddListener(() =>
            {
                ButtonSound.Play();
                ability.IncreasePoints();
                ApplyChanges();
                UpdateComboManagers();
                ApplyBranchCountersChanges();

            }
        );
        UpdateTexts();
        UpdateTextCounters();
        UpdateImages();
    }
    
    private void ApplyBranchCountersChanges() => LanguagesFillers.UpdateAbilityBranchCounter(typeCounter, userCounter, ability.AbilityType);

    private void CheckForComboAndApply() => ability.ApplyComboPoints();
    private void UpdateTexts()
    {
        title.text = ability.AbilityName;
        description.text = ability.Description;
    }
    private void UpdateTextCounters()
    {
        PutPointsAndColor(ability, counter);
        PutPointsAndColor(ability.ComboAbilities[0], comboCounter1);
        if (ability.ComboAbilities.Count > 1)
        {
            PutPointsAndColor(ability.ComboAbilities[1], comboCounter2);
        }
    }
    private void PutPointsAndColor(Ability ability, Text text)
    {
        text.text = ability.FormatedPoints();
        switch (ability.AbilityType)
        {
            case AbilityType.ATTACK: text.color = Color.red; break;
            case AbilityType.DEFENSE: text.color = Color.green; break;
            case AbilityType.SABOTAGE: text.color = Color.magenta; break;
        }
    }
    private void UpdateImages()
    {
        icon.sprite = Resources.Load<Sprite>(iconsDir + ability.AbilityIndex);
        comboIcon1.sprite = Resources.Load<Sprite>(iconsDir + ability.ComboAbilities[0].AbilityIndex);
        if (ability.ComboAbilities.Count > 1)
        {
            comboIcon2.sprite = Resources.Load<Sprite>(iconsDir + ability.ComboAbilities[1].AbilityIndex);
        }
        else
        {
            comboIcon2.transform.gameObject.SetActive(false);
            comboCounter2.transform.gameObject.SetActive(false);
            comboBg2.sprite = Resources.Load<Sprite>(bgDir + "NoComboBG");
        }
    }
    private void UpdateComboManagers()
    {
        foreach (AbilityPrefabManager manager in combos)
        {
            manager.CheckForComboAndApply();
            manager.UpdateTexts();
            manager.UpdateTextCounters();
            manager.MarkIfCombo();
        }
    }
    private void MarkIfCombo() => combo.color = ability.ComboOn() ? new Color(255.0f / 255.0f, 223.0f / 255.0f, 0.0f / 255.0f) : Color.white;
    public AbilityIndex GetIndex() => ability.AbilityIndex;
    public List<AbilityIndex> GetCombosIndexes() => ability.ComboAbilities.Select(ability => ability.AbilityIndex).ToList();
    public void PutCombosList(List<AbilityPrefabManager> combos) => this.combos = combos;
}
