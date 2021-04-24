using System;
using UnityEngine;
using UnityEngine.UI;

public static class LanguagesFillers
{
    public static Consts Lang => SettingsManager.Instance.PlayerPreferences.Lang;
    public static void FillAddToSquadButtonState(Text btnText, bool isAdded) => btnText.text = !isAdded ? Lang.AddToSquad : Lang.AddedToSquad;

    public static void FillMonsterTutorial(Text addSubtitle, Text statsSubtitle, Text helpSubtitle)
    {
        addSubtitle.text = Lang.MonsterTutorialAddButton;
        statsSubtitle.text = Lang.MonsterTutorialStats;
        helpSubtitle.text = Lang.MonsterTutorialHelpButton;
    }

    public static void FillMenuHeader(Text title, Text back, Text help, MenusIdentifier identifier, string monster = null,
        AbilityType abilityType = AbilityType.NONE, Text points = null, Text atkPoints = null,
        Text defPoints = null, Text sabPoints = null, Text userPoints = null)
    {        
        switch (identifier)
        {
            case MenusIdentifier.Menu: title.text = Lang.Menu; break;
            case MenusIdentifier.Definitions: title.text = Lang.Definitions; break;
            case MenusIdentifier.Bestiary: title.text = Lang.Bestiary; break;
            case MenusIdentifier.Monster: title.text = monster ?? ""; break;
            case MenusIdentifier.Player: title.text = GameManager.Instance.CurrentPlayer.Username + "\n" + 
                    Lang.Level + " " + GameManager.Instance.CurrentPlayer.Level; break;
            case MenusIdentifier.Squad: title.text = Lang.Squadron; break;
            case MenusIdentifier.Abilities: title.text = Lang.Abilities; break;
            case MenusIdentifier.AbilitiesLine: AbilitiesBranchMenuTextFiller(title, abilityType, points, atkPoints, defPoints, sabPoints, userPoints); break;
        }
        back.text = Lang.BackBtn;
        help.text = Lang.Help;
    }

    public static void FillMobileRequestExplanation(Text Title, Text YesBtn, Text NoBtn)
    {
        Title.text = Lang.MobileDataExplanation;
        YesBtn.text = Lang.Yes;
        NoBtn.text = Lang.No;
    }

    public static void FillAfterLoginOptions(Text selectCharTitle, Text confirmationQuestion, Text yesTitle, Text noTitle, Text beginGameTitle)
    {
        selectCharTitle.text = Lang.SelectCharacter;
        confirmationQuestion.text = Lang.ConfirmQuestion;
        yesTitle.text = Lang.Yes;
        noTitle.text = Lang.No;
        beginGameTitle.text = Lang.Play;
    }
    public static void FillLoginTitles(Text usernameTitle, Text passwordTitle, Text repasswordTitle, Text emailTitle)
    {
        usernameTitle.text = Lang.Username;
        passwordTitle.text = Lang.Password;
        repasswordTitle.text = Lang.ConfirmPassword;
        emailTitle.text = Lang.Email;
    }

    public static void FillLoginPlaceHolders(Text usernamePlaceHolder, Text passwordPlaceHolder, Text repasswordPlaceHolder, Text emailPlaceHolder)
    {
        usernamePlaceHolder.text = Lang.UsernamePlaceHolder;
        passwordPlaceHolder.text = Lang.PasswordPlaceHolder;
        repasswordPlaceHolder.text = Lang.EnterTextPlaceHolder;
        emailPlaceHolder.text = Lang.EnterTextPlaceHolder;
    }
    public static void ToggleUsernameExistence(Text usernameLabel, bool existsDoesnt)
    {
        usernameLabel.color = existsDoesnt ? Color.red : Color.black;
        usernameLabel.text = existsDoesnt ? Lang.UsernameAlreadyExists : Lang.Username;
    }
    public static void TogglePasswordLenghtValidation(Text passwordLabel, bool validInvalid, bool userExists)
    {
        if (userExists)
        {
            passwordLabel.color = validInvalid ? Color.black : Color.red;
            passwordLabel.text = validInvalid ? Lang.Password : Lang.PasswordLenghtInvalid;
        }
        else
        {
            passwordLabel.color = Color.red;
            passwordLabel.text = Lang.PasswordInvalid;
        }
    }

    public static void ToggleUsernameExistenceValidation(Text usernameLabel, bool userExists)
    {
        usernameLabel.color = userExists ? Color.black : Color.red;
        usernameLabel.text = userExists ? Lang.Username : Lang.UsernameNotFound;
    }

    public static void ResetLoginLabels(Text usernameLabel, Text passwordLabel, Text passwordConfirmLabel, Text emailLabel)
    {
        usernameLabel.color = passwordLabel.color = passwordConfirmLabel.color = emailLabel.color = Color.black;
        usernameLabel.text = Lang.Username;
        passwordLabel.text = Lang.Password;
        passwordConfirmLabel.text = Lang.ConfirmPassword;
        emailLabel.text = Lang.Email;
    }

    public static void TogglePasswordExistenceValidation(Text passwordLabel, bool validInvalid)
    {
        passwordLabel.color = validInvalid ? Color.black : Color.red;
        passwordLabel.text = validInvalid ? Lang.Password : Lang.PasswordInvalid;
    }

    public static void TogglePasswordsEquality(Text passwordLabel, Text passwordConfirmLabel, bool validInvalid, bool equalNot)
    {
        if (validInvalid)
        {
            passwordLabel.color = equalNot ? Color.black : Color.red;
            passwordConfirmLabel.color = equalNot ? Color.black : Color.red;
            passwordConfirmLabel.text = equalNot ? Lang.Password : Lang.PasswordsNotEqual;
        }
        else
        {
            passwordConfirmLabel.color = Color.red;
            passwordConfirmLabel.text = Lang.PasswordInvalid;
        }
    }

    public static void ToggleUsernameLenghtValidation(Text usernameLabel, bool validInvalid)
    {
        usernameLabel.color = validInvalid ? Color.black : Color.red;
        usernameLabel.text = validInvalid ? Lang.Username : Lang.UsernameLenghtInvalid;
    }

    public static void ToggleEmailLabel(Text emailLabel, bool validInvalid)
    {
        emailLabel.color = validInvalid ? Color.black : Color.red;
        emailLabel.text = validInvalid ? Lang.Email : Lang.InvalidEmail;
    }

    public static void FillLoginOptions(Text rememberMeTitle, Text loginTitle, Text registerTitle, Text cancelTitle, Text confirmTitle)
    {
        rememberMeTitle.text = Lang.RememberMe;
        loginTitle.text = Lang.Login;
        registerTitle.text = Lang.Register;
        cancelTitle.text = Lang.Cancel;
        confirmTitle.text = Lang.Confirm;
    }

    public static void FillDuelTutorialOptions(Text optionsMessage, Text duelHPsMessage, Text duelCombatSkillsMessage, Text duelResultMessage)
    {
        optionsMessage.text = Lang.DuelOptionsMessage;
        duelHPsMessage.text = Lang.DuelHpsMessage;
        duelCombatSkillsMessage.text = Lang.DuelCombatSkillsMessage;
        duelResultMessage.text = Lang.DuelCombatResultMessage;        
    }

    public static void FillDuelTeamsSides(Text playerTeam, Text botTeam)
    {
        playerTeam.text = Lang.PlayerTeam;
        botTeam.text = Lang.BotTeam;
    }

    public static void FillCaptureTutorialOptions(Text optionsMessage, Text orbCounterMessage, Text orbMessage)
    {
        optionsMessage.text = Lang.CaptureOptions;
        orbCounterMessage.text = Lang.CaptureOrbCounter;
        orbMessage.text = Lang.CaptureOrb;
    }

    public static void FillWorldMapTutorialOptions(Text wellcomeMessage, Text powersMessage, Text monstersMessage, 
        Text monstersMessage2, Text monstersMessage3, Text monstersMessage4, Text duelMessage, Text playersMessage)
    {
        wellcomeMessage.text = Lang.WellcomeMessage;
        powersMessage.text = Lang.PowersMessage;
        monstersMessage.text = Lang.MonsterMessage;
        monstersMessage2.text = Lang.MonsterMessage2;
        monstersMessage3.text = Lang.MonsterMessage3;
        monstersMessage4.text = Lang.MonsterMessage4;
        duelMessage.text = Lang.DuelMessage;
        playersMessage.text = Lang.PlayersMessage;
    }

    public static void FillAbilitiesTutorialOptions(Text attackSubtitle, Text defenseSubtitle, Text sabotageSubtitle)
    {
        attackSubtitle.text = Lang.AbilitiesTutorialAttackLine;
        defenseSubtitle.text = Lang.AbilitiesTutorialDefenseLine;
        sabotageSubtitle.text = Lang.AbilitiesTutorialSabotageLine;
    }

    public static string FormatAbilityValue(float value, bool positiveNegative) => (positiveNegative ? "+" : "-") + value;

    public static void FillSquadronTutorial(Text attackSubtitle, Text defenseSubtitle, Text sabotageSubtitle)
    {
        attackSubtitle.text = Lang.SquadronMonsterTemplate(MonsterType.ATTACK);
        defenseSubtitle.text = Lang.SquadronMonsterTemplate(MonsterType.DEFENSE);
        sabotageSubtitle.text = Lang.SquadronMonsterTemplate(MonsterType.SABOTAGE);
    }

    public static void FillAbilityExample(Text headerSubtitle, Text buttonsSubtitle, Text infoSubtitle, Text iconsSubtitle, Text listSubtitle)
    {
        headerSubtitle.text = Lang.AbilityTutorialHeader;
        buttonsSubtitle.text = Lang.AbilityTutorialButtons;
        infoSubtitle.text = Lang.AbilityTutorialInfo;
        iconsSubtitle.text = Lang.AbilityTutorialIcons;
        listSubtitle.text = Lang.AbilityTutorialListInfo;
    }

    public static void FillMonstersSubPanel(Text monsters, Text saw, Text nonCaptured, Text captured, Text common, Text incommon, Text rare, Text mythic, Text captureRatio)
    {
        monsters.text = Lang.Monsters;
        saw.text = Lang.Saw;
        nonCaptured.text = Lang.NonCaptured;
        captured.text = Lang.Caught;
        common.text = Lang.Common;
        incommon.text = Lang.Uncommon;
        rare.text = Lang.Rare;
        mythic.text = Lang.Mythic;
        captureRatio.text = Lang.CaptureRatio;
    }

    public static void FillBestiaryTutorial(Text typesSubtitle, Text raritiesSubtitle, Text platesSubtitle, Text monsterListSubtitle)
    {
        typesSubtitle.text = Lang.BestiaryTutorialTypes;
        raritiesSubtitle.text = Lang.BestiaryTutorialRarities;
        platesSubtitle.text = Lang.BestiaryTutorialPlates;
        monsterListSubtitle.text = Lang.BestiaryTutorialMonsterList;
    }

    public static void FillPlayerTutorial(Text xPSubtitle, Text pointsSubtitle, Text batlesSubtitle, Text monstersSubtitle, Text potionsSubtitle)
    {
        xPSubtitle.text = Lang.PlayerXPTutorial;
        pointsSubtitle.text = Lang.PlayerPointsTutorial;
        batlesSubtitle.text = Lang.PlayerBatlesTutorial;
        monstersSubtitle.text = Lang.PlayerMonstersTutorial;
        potionsSubtitle.text = Lang.PlayerPotionsTutorial;
    }

    public static void FillBestiaryTutorialOption(Text title, Text explanation)
    {
        title.text = Lang.Bestiary;
        explanation.text = Lang.BestiaryExplanation;
    }

    public static void MenuTutorialHeaderFiller(Text backBtnTitle, Text helpBtnTitle)
    {
        backBtnTitle.text = Lang.BackMainMenuBtnExplanation;
        helpBtnTitle.text = Lang.HelpBtnExplanation;        
    }

    public static void FillTutorialOptions(Text TurnHelpOffTitle, Text closeBtnTitle, bool continueClose, Text previousTitle, Text nextTitle)
    {
        closeBtnTitle.text = Lang.Close;
        TurnHelpOffTitle.text = Lang.TurnOffHelp;
        previousTitle.text = Lang.Previous;
        nextTitle.text = continueClose ? Lang.Next : Lang.Close;        
    }

    public static void FillPlayerTutorialOption(Text title, Text explanation)
    {
        title.text = GameManager.Instance.CurrentPlayer.Username;
        explanation.text = Lang.PlayerExplanation;
    }

    public static void FillSquadronTutorialOption(Text title, Text explanation)
    {
        title.text = Lang.Squadron;
        explanation.text = Lang.SquadronExplanation;
    }

    public static void FillAbilitiesTutorialOption(Text title, Text explanation)
    {
        title.text = Lang.Abilities;
        explanation.text = Lang.AbilitiesExplanation;
    }

    public static void FillDefinitionsTutorialOption(Text title, Text explanation)
    {
        title.text = Lang.Definitions;
        explanation.text = Lang.DefinitionsExplanation;
    }

    public static void FillExitTutorialOption(Text title, Text explanation)
    {
        title.text = Lang.Logout;
        explanation.text = Lang.LogoutExplanation;
    }

    public static void FillDuelOptionsButtons(Text runAway, Text continueToFight)
    {
        runAway.text = Lang.Escape;
        continueToFight.text = Lang.Continue;
    }

    public static void ToggleFightPosition(Text fight, bool attackDefend) => fight.text = attackDefend ? Lang.ToAttack : Lang.ToDefend;

    public static void FillConfirmationSubPanel(Text exitQuestion, Text yes, Text no)
    {
        exitQuestion.text = Lang.ExitQuestion;
        yes.text = Lang.Yes;
        no.text = Lang.No;
    }

    public static void FillCaptureResult(Text title, Text backBtnTitle, Text sawTitle, Text captureTitle, 
        Text levelTitle, bool evolved, bool captured, Text potionsTitle, Text hpTitle, Text inspTitle)
    {
        title.text = captured ? Lang.Success : Lang.Failure;
        FillBackButton(backBtnTitle);
        sawTitle.text = Lang.Saw;
        captureTitle.text = Lang.Catched;
        levelTitle.text = evolved ? Lang.EvolvedLevel : Lang.Level;
        potionsTitle.text = Lang.Potions;
        hpTitle.text = Lang.Heal;
        inspTitle.text = Lang.Inspiration;
    }
    public static void UpdateHPPotions(Text hPPotion, int hpAmount) => hPPotion.text = hpAmount + "\n" + Lang.HpPotions;
    public static void UpdateInspPotions(Text intelPotion, int inspAmount) => intelPotion.text = inspAmount + "\n" + Lang.InspirationPotions;   
    public static void FillDuelFigthtButtons(Text hPPotion, Text intelPotion, int hpAmount, int inspAmount)
    {
        UpdateHPPotions(hPPotion, hpAmount);
        UpdateInspPotions(intelPotion, inspAmount);
    }
    public static void FillAtkDefMonsterCombatStats(Text combatStats, Text attackTitle, Text atkBaseTitle, Text atkLevelTitle, Text defenseTitle,
        Text defBaseTitle, Text defLevelTitle, Text healthTitle, Text hpBaseTitle, Text hpLevelTitle)
    {
        combatStats.text = Lang.CombatStats;
        attackTitle.text = Lang.Attack + " " + Lang.Power;
        atkBaseTitle.text = Lang.Base;
        atkLevelTitle.text = Lang.Extra + " " + Lang.Level;
        defenseTitle.text = Lang.Defense + " " + Lang.Power;
        defBaseTitle.text = Lang.Base;
        defLevelTitle.text = Lang.Extra + " " + Lang.Level;
        healthTitle.text = Lang.Health + " " + Lang.Power;
        hpBaseTitle.text = Lang.Base;
        hpLevelTitle.text = Lang.Extra + " " + Lang.Level;
    }
    public static void FillSabMonsterCombatStats(Text combatStats, Text sabotageTitle, Text sabBaseTitle, Text sabLevelTitle, Text attackTitle,
        Text atkBaseTitle, Text atkLevelTitle, Text defenseTitle, Text defBaseTitle, Text defLevelTitle, Text healthTitle, Text hpBaseTitle, Text hpLevelTitle)
    {
        combatStats.text = Lang.CombatStats;
        sabotageTitle.text = Lang.Sabotage + " " + Lang.Power;
        sabBaseTitle.text = Lang.Base;
        sabLevelTitle.text = Lang.Extra + " " + Lang.Level;
        attackTitle.text = Lang.Attack + " " + Lang.Power;
        atkBaseTitle.text = Lang.Base;
        atkLevelTitle.text = Lang.Extra + " " + Lang.Level;
        defenseTitle.text = Lang.Defense + " " + Lang.Power;
        defBaseTitle.text = Lang.Base;
        defLevelTitle.text = Lang.Extra + " " + Lang.Level;
        healthTitle.text = Lang.Health + " " + Lang.Power;
        hpBaseTitle.text = Lang.Base;
        hpLevelTitle.text = Lang.Extra + " " + Lang.Level;
    }
    public static void FillMonsterPersonalStats(Text personalStats, Text typeTitle, Text subTypeTitle, Text sawTitle, Text catchTitle, Text toEvolveTitle)
    {
        personalStats.text = Lang.PersonalStats;
        typeTitle.text = Lang.Type;
        subTypeTitle.text = Lang.Subtype;
        sawTitle.text = Lang.Seen;
        catchTitle.text = Lang.Catched;
        toEvolveTitle.text = Lang.ToEvolve;
    }
    public static void FillSquadMonsterTitlesSubPanel(Text type, Text level, Text typeValue, MonsterType typeMonster)
    {
        type.text = Lang.Type;
        level.text = Lang.Level;
        switch (typeMonster)
        {
            case MonsterType.ATTACK: typeValue.text = Lang.Attack; break;
            case MonsterType.DEFENSE: typeValue.text = Lang.Defense; break;
            case MonsterType.SABOTAGE: typeValue.text = Lang.Sabotage; break;

        }
    }
    public static void FillSabotageSubPanel(Text sabotage, Text sabBase, Text sabLevel, Text sabAbilities)
    {
        sabotage.text = Lang.Sabotage;
        sabBase.text = Lang.Base;
        sabLevel.text = Lang.Extra + "\n" + Lang.Level;
        sabAbilities.text = Lang.Extra + "\n" + Lang.Abilities;
    }
    public static void FillPointsSubPanel(Text points, Text forUse, Text allPoints)
    {
        points.text = Lang.Points;
        forUse.text = Lang.ToUse;
        allPoints.text = Lang.Total;
    }
    public static void FillXpSubPanel(Text xp, Text actualXp, Text neededXp)
    {
        xp.text = Lang.Experience;
        actualXp.text = Lang.Atual;
        neededXp.text = Lang.ToEvolve;
    }
    public static void FillAttackSubPanel(Text attack, Text atkBase, Text atkLevel, Text atkAbilities)
    {
        attack.text = Lang.Attack;
        atkBase.text = Lang.Base;
        atkLevel.text = Lang.Extra + "\n" + Lang.Level;
        atkAbilities.text = Lang.Extra + "\n" + Lang.Abilities;
    }
    public static void FillBatlesSubPanel(Text batles, Text totalBatles, Text retreat, Text lost, Text won, Text winRatio)
    {
        batles.text = Lang.Batles;
        totalBatles.text = Lang.Total;
        retreat.text = Lang.RunnedAway;
        lost.text = Lang.Lost;
        won.text = Lang.Won;
        winRatio.text = Lang.WinRatio;
    }
    public static void FillHealthSubPanel(Text health, Text healthBase, Text healthLevel, Text healthAbilities)
    {
        health.text = Lang.Health;
        healthBase.text = Lang.Base;
        healthLevel.text = Lang.Extra + "\n" + Lang.Level;
        healthAbilities.text = Lang.Extra + "\n" + Lang.Abilities;
    }
    public static void FillDefenseSubPanel(Text defense, Text defBase, Text defLevel, Text defAbilities)
    {
        defense.text = Lang.Defense;
        defBase.text = Lang.Base;
        defLevel.text = Lang.Extra + "\n" + Lang.Level;
        defAbilities.text = Lang.Extra + "\n" + Lang.Abilities;
    }
    public static void FillPotionsSubPanel(Text potions, Text health, Text intellect)
    {
        potions.text = Lang.Potions;
        health.text = Lang.Health;
        intellect.text = Lang.Inspiration;
    }
    public static void FillEndDuelPanel(bool won, Text title, Text experienceTitle, Text wonTitle, Text totalTitle, Text damageTitle, Text receivedTitle, Text givenTitle, Text defendedTitle, Text endDuelBtn)
    {
        title.text = won ? Lang.Victory : Lang.Defeat;
        experienceTitle.text = Lang.Experience;
        wonTitle.text = Lang.Won;
        totalTitle.text = Lang.Total;
        damageTitle.text = Lang.Damage;
        receivedTitle.text = Lang.Received;
        givenTitle.text = Lang.Given;
        defendedTitle.text = Lang.Defended;
        endDuelBtn.text = Lang.EndDuel;
    }
    public static void FillPlayerLevelUp(Text evolution, Text wonPoints, Text totalPoints, Text wonPointsValue, Text totalPointsValue)
    {
        Player player = GameManager.Instance.CurrentPlayer;
        evolution.text = Lang.Evolution(player.Level);
        wonPoints.text = Lang.WonPoints;
        totalPoints.text = Lang.TotalPoints;
        wonPointsValue.text = player.IncrPoints.ToString();
        totalPointsValue.text = player.PlayerMaxPoints.ToString();
    }
    public static void FillDamageResultPanel(Text round, int roundCounter, Text percentageTitle, Text resultTitle, 
        Text normalTotalDmg, Text criticalTotalDmg, Text passiveTotalDmg,Text normalDmgTitle, Text criticalDmgTitle, 
        Text passiveDmgTitle, Text faintedTitle, Text reviveTitle, Text healTitle, Text endRoundBtn,
        Text plSquadronHp, Text enSquadronHp)
    {
        round.text = Lang.Round + " " + roundCounter;
        percentageTitle.text = Lang.DamagePercentage;
        resultTitle.text = Lang.Result;
        normalTotalDmg.text = Lang.Total + " " + Lang.NormalDamage;
        criticalTotalDmg.text = Lang.Total + " " + Lang.CriticalDamage;
        passiveTotalDmg.text = Lang.Total + " " + Lang.PassiveDamage;
        normalDmgTitle.text = Lang.NormalDamage;
        criticalDmgTitle.text = Lang.CriticalDamage;
        passiveDmgTitle.text = Lang.PassiveDamage;
        faintedTitle.text = Lang.State;
        reviveTitle.text = Lang.Revive;
        healTitle.text = Lang.Heal;
        endRoundBtn.text = Lang.EndRound;
        plSquadronHp.text = Lang.Total + " " + Lang.Squadron + " " + Lang.Hp;
        enSquadronHp.text = Lang.Total + " " + Lang.Squadron + " " + Lang.Hp;
    }
    public static void FillDamageSubPanel(bool fainted, Text faintedState, bool revived, Text revivedState)
    {
        revivedState.text = revived ? Lang.Used : Lang.ToUse;
        faintedState.text = revived ? (!fainted ? Lang.Revived : Lang.Fainted) : (!fainted ? Lang.Alive : Lang.Fainted);
    }

    public static void FillAttackerSection(Text title, Text attackBaseTitle, Text defenseBaseTitle, Text sabotageBaseTitle, Text attackTotalTitle, Text defenseTotalTitle, 
        Text sabotageTotalTitle, Text totalAttack, Text continueBtn, bool isPlayer, Text round, int roundCounter)
    {
        title.text = Lang.Attacker + " (" + (isPlayer ? Lang.You : Lang.Bot) + ")";
        attackBaseTitle.text = defenseBaseTitle.text = sabotageBaseTitle.text = Lang.BaseAttack;
        attackTotalTitle.text = defenseTotalTitle.text = sabotageTotalTitle.text = Lang.TotalAttack;
        totalAttack.text = Lang.CombinedDamage;
        continueBtn.text = Lang.Continue;
        round.text = Lang.Round + " " + roundCounter;
    }
    public static void FillDefensorSection(Text title, Text attackBaseTitle, Text defenseBaseTitle, Text sabotageBaseTitle,
        Text attackTotalTitle, Text defenseTotalTitle, Text sabotageTotalTitle, Text totalAttack, bool isPlayer)
    {
        title.text = Lang.Defensor + " (" + (isPlayer ? Lang.You : Lang.Bot) + ")"; ;
        attackBaseTitle.text = defenseBaseTitle.text = sabotageBaseTitle.text = Lang.BaseDefense;
        attackTotalTitle.text = defenseTotalTitle.text = sabotageTotalTitle.text = Lang.TotalDefense;
        totalAttack.text = Lang.CombinedDefense;
    }
    public static void BestiaryTextFiller(Text title, Text backBtn, Text helpBtn)
    {
        title.text = Lang.Bestiary;
        helpBtn.text = Lang.Help;
        FillBackButton(backBtn);
    }
    public static void AttackSquadronMonsterTemplateFiller(Text name, Text type, Text level, Text attack, Text defense, Text health, Text extraAttack, Text extraDefense, Text extraHealth)
    {
        Squadron squad = GameManager.Instance.CurrentPlayer.Squadron;
        if (squad.AtkMonster != null)
        {
            attack.text = AddPointsAndSpace(Lang.PowerOfAttack) + squad.AtkPowers.AttackPower.Base.ToString();
            defense.text = AddPointsAndSpace(Lang.PowerOfDefense) + squad.AtkPowers.DefensePower.Base.ToString();
            type.text = AddPointsAndSpace(Lang.Type) + Lang.Attack;
            name.text = squad.AtkMonster.MonsterName;
            level.text = AddPointsAndSpace(Lang.Level) + squad.AtkMonster.Stats.Level.ToString();
            FillMonsterStats(level, health, extraAttack, extraDefense, extraHealth, squad.AtkPowers);
        }
        else
        {
            name.text = type.text = level.text = attack.text = defense.text = health.text = extraAttack.text = extraDefense.text = extraHealth.text = "";
        }
    }
    public static void DefenseSquadronMonsterTemplateFiller(Text name, Text type, Text level, Text defense, Text attack, Text health, Text extraDefense, Text extraAttack, Text extraHealth)
    {
        Squadron squad = GameManager.Instance.CurrentPlayer.Squadron;
        if (squad.DefMonster != null)
        {
            attack.text = AddPointsAndSpace(Lang.PowerOfAttack) + squad.DefPowers.AttackPower.Base.ToString();
            defense.text = AddPointsAndSpace(Lang.PowerOfDefense) + squad.DefPowers.DefensePower.Base.ToString();
            type.text = AddPointsAndSpace(Lang.Type) + Lang.Defense;
            name.text = squad.DefMonster.MonsterName;
            level.text = AddPointsAndSpace(Lang.Level) + squad.DefMonster.Stats.Level.ToString();
            FillMonsterStats(level, health, extraAttack, extraDefense, extraHealth, squad.DefPowers);
        }
        else
        {
            name.text = type.text = level.text = attack.text = defense.text = health.text = extraAttack.text = extraDefense.text = extraHealth.text = "";
        }
    }
    public static void SabotageSquadronMonsterTemplateFiller(Text name, Text type, Text level, Text sabotage, Text attackDefense, Text health, Text extraSabotage, Text extraAttack, Text extraDefense, Text extraHealth)
    {
        Squadron squad = GameManager.Instance.CurrentPlayer.Squadron;
        if (squad.SabMonster != null)
        {
            type.text = AddPointsAndSpace(Lang.Type) + Lang.Sabotage;
            name.text = squad.SabMonster.MonsterName;
            level.text = AddPointsAndSpace(Lang.Level) + squad.SabMonster.Stats.Level.ToString();
            sabotage.text = AddPointsAndSpace(Lang.PowerOfSabotage) + squad.SabPowers.SabotagePower.Base.ToString();
            attackDefense.text = squad.SabPowers.AttackPower.Base > 0 ? AddPointsAndSpace(Lang.PowerOfAttack) + squad.SabPowers.AttackPower.Base.ToString() : AddPointsAndSpace(Lang.PowerOfDefense) + squad.SabPowers.DefensePower.Base.ToString();
            extraSabotage.text = AddPointsAndSpace(Lang.Extra + " " + Lang.PowerOfSabotage) + squad.SabPowers.SabotagePower.Bonus.ToString();
            FillMonsterStats(level, health, extraAttack, extraDefense, extraHealth, squad.SabPowers);
        }
        else
        {
            name.text = type.text = level.text = sabotage.text = attackDefense.text = health.text = extraSabotage.text = extraAttack.text = extraDefense.text = extraHealth.text = "";
        }
    }
    private static void FillMonsterStats(Text level, Text health, Text extraAttack, Text extraDefense, Text extraHealth, MonsterPowers powers)
    {
        health.text = AddPointsAndSpace(Lang.Hp) + powers.HealthPower.MaxHp.ToString();
        extraAttack.text = AddPointsAndSpace(Lang.Extra + " " + Lang.PowerOfAttack) + powers.AttackPower.Bonus.ToString();
        extraDefense.text = AddPointsAndSpace(Lang.Extra + " " + Lang.PowerOfDefense) + powers.DefensePower.Bonus.ToString();
        extraHealth.text = AddPointsAndSpace(Lang.Extra + " " + Lang.Hp) + powers.HealthPower.BonusHp.ToString();
    }
    public static void FillMenuOptions(Text logout, Text definitions, Text bestiary, Text player, Text squadron, Text abilities)
    {        
        logout.text = Lang.Logout;
        definitions.text = Lang.Definitions;
        bestiary.text = Lang.Bestiary;
        squadron.text = Lang.Squadron;
        abilities.text = Lang.Abilities;
        player.text = Lang.MalePlayer;         
    }
    public static void FillDefinitionsOptions(Text backgroundSliderTitle, Text soundEffectsSliderTitle, Text languageTitle)
    {
        backgroundSliderTitle.text = Lang.BackgroundMusicVolume;
        soundEffectsSliderTitle.text = Lang.SoundEffectsVolume;
        languageTitle.text = Lang.Language;
    }
    public static void FillAbilitiesMenuOptions(Text attackLogo, Text defenseLogo, Text sabotageLogo)
    {
        attackLogo.text = Lang.Attack;
        defenseLogo.text = Lang.Defense;
        sabotageLogo.text = Lang.Sabotage;
    }

    public static void AbilitiesBranchMenuTextFiller(Text title, AbilityType abilityType, Text points, Text attackPoints, Text defensePoints, Text sabotagePoints, Text userPoints)
    {
        switch (abilityType)
        {
            case AbilityType.ATTACK: title.text = Lang.AttackAbiltiies; break;
            case AbilityType.DEFENSE: title.text = Lang.DefenseAbilities; break;
            case AbilityType.SABOTAGE: title.text = Lang.SabotageAbilities; break;
        }
        points.text = Lang.Points;
        userPoints.text = GameManager.Instance.CurrentPlayer.GetPointsToMax();
        attackPoints.text = GameManager.Instance.AbilitiesContainer.GetPointsToMax(AbilityType.ATTACK);
        defensePoints.text = GameManager.Instance.AbilitiesContainer.GetPointsToMax(AbilityType.DEFENSE);
        sabotagePoints.text = GameManager.Instance.AbilitiesContainer.GetPointsToMax(AbilityType.SABOTAGE);
    }
    public static void UpdateAbilityBranchCounter(Text counter, Text userPoints, AbilityType type)
    {
        counter.text = GameManager.Instance.AbilitiesContainer.GetTypePoints(type).ToString() + "/" + 40;
        userPoints.text = GameManager.Instance.CurrentPlayer.GetPointsToMax();
    }


    private static string AddPointsAndSpace(string text) => text += ": ";
    private static void FillBackButton(Text backBtn) => backBtn.text = Lang.BackBtn;

}
