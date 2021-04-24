using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
public class StartScript : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private GameObject LoginMenu, DefinitionsMenu;
    [SerializeField]
    private Toggle RememberMe;
    [SerializeField]
    private RegisterManager registerManager;
    [SerializeField]
    private Button BeginGame, YesBtn, NoBtn, DefinitionsBtn, DefinitionsBackBtn;
    [SerializeField]
    private Text UsernameTitle, PasswordTitle, RepasswordTitle, EmailTitle, RememberMeTitle,
        LoginTitle, RegisterTitle, CancelTitle, ConfirmTitle, UsernamePlaceHolder, PasswordPlaceHolder,
        RepasswordPlaceHolder, EmailPlaceHolder, SelectCharTitle, ConfirmationQuestion, YesTitle, NoTitle, BeginGameTitle;
#pragma warning restore 0649
    private bool useFirebase = false;
    private void Awake()
    {
        DefinitionsBackBtn.onClick.AddListener(() => 
        { 
            DefinitionsMenu.SetActive(false);
            FillTexts();
        });
        DefinitionsBtn.onClick.AddListener(() => DefinitionsMenu.SetActive(true));
        BeginGame.onClick.AddListener(() => CheckCharacter());
        YesBtn.onClick.AddListener(() => FinishProcess());
        NoBtn.onClick.AddListener(() => registerManager.ToggleConfirmation(false));
    }
    private void OnEnable() => FillTexts();
    private void FillTexts()
    {
        LanguagesFillers.FillLoginTitles(UsernameTitle, PasswordTitle, RepasswordTitle, EmailTitle);
        LanguagesFillers.FillLoginOptions(RememberMeTitle, LoginTitle, RegisterTitle, CancelTitle, ConfirmTitle);
        LanguagesFillers.FillLoginPlaceHolders(UsernamePlaceHolder, PasswordPlaceHolder, RepasswordPlaceHolder, EmailPlaceHolder);
        LanguagesFillers.FillAfterLoginOptions(SelectCharTitle, ConfirmationQuestion, YesTitle, NoTitle, BeginGameTitle);
    }
    private void CheckCharacter()
    {
        if (registerManager.CharSelected)
        {
            registerManager.ToggleConfirmation(true);
        }
        else
        {
            registerManager.WarnUser();
        }
    }
    public void OnClickLogin()
    {
        registerManager.ResetLabels();
        registerManager.ToggleButtons(false);
        bool nameLenghtValidation = registerManager.CheckUsernameLength();
        registerManager.ToggleUsernameFilling(nameLenghtValidation);
        bool userExists = registerManager.CheckIfUserExists();
        registerManager.ToggleUsernameNotFound(userExists);
        bool passwordLenghtValidation = registerManager.CheckPasswordLength();
        registerManager.TogglePasswordFilling(userExists, passwordLenghtValidation);
        if (useFirebase)
        {
            DoFirebaseLogin();
            return;
        }
        if (nameLenghtValidation && userExists && passwordLenghtValidation && CheckUserPassword())
        {
            registerManager.Remember();
            LoadGame();
        }
        registerManager.ToggleButtons(true);
    }
    private bool CheckUserPassword()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(registerManager.Path, FileMode.Open);
        PlayerData playerData = (PlayerData)bf.Deserialize(file);
        file.Close();
        bool passwordValidation = registerManager.CheckPasswords(playerData.Password);
        registerManager.TogglePasswordValidation(passwordValidation);
        return passwordValidation;
    }
    private void LoadGame()
    {
        PlayerPrefs.SetString(SquadUpConstants.USERNAME, registerManager.User);
        LoginMenu.SetActive(false);
        SceneTransitionManager.Instance.GoToScene(SquadUpConstants.SCENE_WORLD);
    }
    public void OnClickConfirm()
    {
        registerManager.ToggleButtons(false);
        bool emailValid = registerManager.CheckEmail();
        registerManager.ToggleEmailCondition(emailValid);
        bool nameLenghtValid = registerManager.CheckUsernameLength();
        registerManager.ToggleUsernameFilling(nameLenghtValid);
        bool userExists = registerManager.CheckIfUserExists();
        registerManager.ToggleUserExistsCondition(nameLenghtValid, userExists);
        bool passwordLenght = registerManager.CheckPasswordLength();
        registerManager.TogglePasswordFilling(userExists, passwordLenght);
        bool repasswordEquality = registerManager.CheckPasswords();
        registerManager.TogglePasswordsFilling(passwordLenght, repasswordEquality);
        if (emailValid && nameLenghtValid && !userExists && passwordLenght && repasswordEquality)
        {
            registerManager.ToggleCharSelectionUI(true);
        }
        else
        {
            registerManager.ToggleButtons(true);
        }
    }
    private void CreateUser()
    {
        RegistTutorials();
        registerManager.Remember();        
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(registerManager.Path);
        PlayerData data = new PlayerData(registerManager.User, registerManager.UserPass, registerManager.UserEmail, registerManager.CharType); ;
        bf.Serialize(file, data);
        file.Close();
    }
    private void RegistTutorials() => PlayerPrefs.SetInt(SquadUpConstants.MENU_TUTORIAL, 0);
    private void FinishProcess()
    {
        registerManager.ToggleCharSelectionUI(false);
        registerManager.ToggleConfirmation(false);
        CreateUser();
        LoadGame();
    }
    private void DoFirebaseLogin()
    {
        throw new NotImplementedException();
    }
}
