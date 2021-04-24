using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Slider plAtkSlider, plDefSlider, plSabSlider, enAtkSlider, enDefSlider, enSabSlider;
    [SerializeField]
    private Gradient plAtkGradient, plDefGradient, plSabGradient, enAtkGradient, enDefGradient, enSabGradient;
    [SerializeField]
    private Image plAtkFill, plDefFill, plSabFill, enAtkFill, enDefFill, enSabFill,
        plAtkIcon, plDefIcon, plSabIcon, enAtkIcon, enDefIcon, enSabIcon;
    [SerializeField]
    private Text PlayerAttackHP, PlayerDefenseHP, PlayerSabotageHP, EnemyAttackHP, EnemyDefenseHP, EnemySabotageHP, PlayerTeam, BotTeam;
#pragma warning restore 0649

    private float plAtkHP, plDefHP, plSabHP, enAtkHP, enDefHP, enSabHP;

    private void Awake()
    {
        LanguagesFillers.FillDuelTeamsSides(PlayerTeam, BotTeam);
    }
    public void UpdateHPs(Squadron squadron, bool playerEnemy)
    {
        float 
            atk = squadron.AtkPowers.HealthPower.CurrentHp,
            def = squadron.DefPowers.HealthPower.CurrentHp,
            sab = squadron.SabPowers.HealthPower.CurrentHp;
        if (playerEnemy)
        {
            UpdatePlayerAttackSlider(atk);
            UpdatePlayerDefenseSlider(def);
            UpdatePlayerSabotageSlider(sab);
            UpdatePlayerMonstersSubtitles(atk, def, sab);
        }
        else
        {
            UpdateEnemyAttackSlider(atk);
            UpdateEnemyDefenseSlider(def);
            UpdateEnemySabotageSlider(sab);
            UpdateEnemyMonstersSubtitles(atk, def, sab);
        }
    }

    public void UpdatePlayerAttackSlider(float hp) => UpdateHealthBar(hp, plAtkSlider, plAtkGradient, plAtkFill);
    public void UpdatePlayerDefenseSlider(float hp) => UpdateHealthBar(hp, plDefSlider, plDefGradient, plDefFill);
    public void UpdatePlayerSabotageSlider(float hp) => UpdateHealthBar(hp, plSabSlider, plSabGradient, plSabFill);
    public void UpdateEnemyAttackSlider(float hp) => UpdateHealthBar(hp, enAtkSlider, enAtkGradient, enAtkFill);
    public void UpdateEnemyDefenseSlider(float hp) => UpdateHealthBar(hp, enDefSlider, enDefGradient, enDefFill);
    public void UpdateEnemySabotageSlider(float hp) => UpdateHealthBar(hp, enSabSlider, enSabGradient, enSabFill);
    public void StartPlayerHPs(Squadron squadron)
    {
        plAtkHP = squadron.AtkPowers.HealthPower.MaxHp;
        plDefHP = squadron.DefPowers.HealthPower.MaxHp;
        plSabHP = squadron.SabPowers.HealthPower.MaxHp;
        ImagesFillers.AddSquadronMonsterHeads(plAtkIcon, plDefIcon, plSabIcon, squadron);
        StartSquadHPs(plAtkSlider, plDefSlider, plSabSlider, plAtkHP, plDefHP, plSabHP);
        StartGradient(plAtkGradient, plDefGradient, plSabGradient, plAtkFill, plDefFill, plSabFill);
        UpdatePlayerMonstersSubtitles(plAtkHP, plDefHP, plSabHP);

    }
    private void UpdatePlayerMonstersSubtitles(float atkHP, float defHP, float sabHP)
    {
        PlayerAttackHP.text = atkHP + "/" + plAtkHP;
        PlayerDefenseHP.text = defHP + "/" + plDefHP;
        PlayerSabotageHP.text = sabHP + "/" + plSabHP;
    }
    private void UpdateEnemyMonstersSubtitles(float atkHP, float defHP, float sabHP)
    {
        EnemyAttackHP.text = enAtkHP + "/" + atkHP;
        EnemyDefenseHP.text = enDefHP + "/" + defHP;
        EnemySabotageHP.text = enSabHP + "/" + sabHP;
    }
    public void StartEnemyHPs(Squadron squadron)
    {
        enAtkHP = squadron.AtkPowers.HealthPower.MaxHp;
        enDefHP = squadron.DefPowers.HealthPower.MaxHp;
        enSabHP = squadron.SabPowers.HealthPower.MaxHp;
        ImagesFillers.AddSquadronMonsterHeads(enAtkIcon, enDefIcon, enSabIcon, squadron);
        StartSquadHPs(enAtkSlider, enDefSlider, enSabSlider, enAtkHP, enDefHP, enSabHP);
        StartGradient(enAtkGradient, enDefGradient, enSabGradient, enAtkFill, enDefFill, enSabFill);
        UpdateEnemyMonstersSubtitles(enAtkHP, enDefHP, enSabHP);
    }
    private void StartSquadHPs(Slider attack, Slider defense, Slider sabotage, float attackMaxHp, float defenseMaxHp, float sabotageMaxHp)
    {
        attack.value = attack.maxValue = attackMaxHp;
        defense.value = defense.maxValue = defenseMaxHp;
        sabotage.value = sabotage.maxValue = sabotageMaxHp;
    }
    private void StartGradient(Gradient attackGradient, Gradient defenseGradient, Gradient sabotageGradient, Image attackFill, Image defenseFill, Image sabotageFill)
    {
        attackFill.color = attackGradient.Evaluate(1f);
        defenseFill.color = defenseGradient.Evaluate(1f);
        sabotageFill.color = sabotageGradient.Evaluate(1f);
    }
    private void UpdateHealthBar(float hp, Slider slider, Gradient gradient, Image fill)
    {
        float inc = 0.001f;
        while (inc < hp)
        {
            slider.value -= inc;
            fill.color = gradient.Evaluate(slider.normalizedValue);

            inc += 0.001f;
        }
        slider.value = hp;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
