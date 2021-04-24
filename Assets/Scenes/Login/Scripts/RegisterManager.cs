using System.IO;
using System.Net.Mail;
using UnityEngine;
using UnityEngine.UI;

public class RegisterManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private InputField Username, Password, Email, PasswordConfirm;
    [SerializeField]
    private Text UsernameLabel, PasswordLabel, EmailLabel, PasswordConfirmLabel;
    [SerializeField]
    private Button Confirm, Login, Register, RegisterCancel;
    [SerializeField]
    private GameObject PasswordConfirmHolder, EmailHolder, CharSelectionUI, ConfirmationUI;
    [SerializeField]    
    private Toggle RememberMe;
#pragma warning restore 0649
    private string basePath;
    public string Path { get => basePath + Username.text + ".dat"; }
    public string User { get => Username.text; }
    public string UserPass { get => Password.text; }
    public string UserEmail { get => Email.text; }
    public CharsTypes CharType { get; private set; }
    private void Start() => basePath = Application.persistentDataPath + "/Player-";
    public bool CheckEmail()
    {
        try
        {
            MailAddress email = new MailAddress(Email.text);
            if (!email.Address.Equals(Email.text))
            {
                return false;
            }
        }
        catch
        {
            return false;
        }
        return true;
    }
    public bool CheckUsernameLength() => Username.text.Length >= 4 && Username.text.Length <= 10;
    public bool CheckPasswordLength() => Password.text.Length >= 8 && Password.text.Length <= 32;    
    public bool CheckPasswords() => Password.text == PasswordConfirm.text;
    public bool CheckPasswords(string passwordData) => Password.text == passwordData;
    public bool CheckIfUserExists() => File.Exists(basePath + Username.text + ".dat");
    public void ToggleEmailCondition(bool validInvalid) => LanguagesFillers.ToggleEmailLabel(EmailLabel, validInvalid);
    public void ToggleUserExistsCondition(bool nameValidInvalid, bool existsDoesnt)
    {
        if (nameValidInvalid)
        {
            LanguagesFillers.ToggleUsernameExistence(UsernameLabel, existsDoesnt);
        }
    }
    public void ToggleUsernameFilling(bool validInvalid) => LanguagesFillers.ToggleUsernameLenghtValidation(UsernameLabel, validInvalid);
    public void TogglePasswordFilling(bool userExists, bool validInvalid) => LanguagesFillers.TogglePasswordLenghtValidation(PasswordLabel, validInvalid, userExists);
    public void TogglePasswordsFilling(bool validInvalid, bool equalNot) => LanguagesFillers.TogglePasswordsEquality(PasswordLabel, PasswordConfirmLabel, validInvalid, equalNot);
    public void TogglePasswordValidation(bool validInvalid) => LanguagesFillers.TogglePasswordExistenceValidation(PasswordLabel, validInvalid);
    public void ToggleUsernameNotFound(bool userExists) => LanguagesFillers.ToggleUsernameExistenceValidation(UsernameLabel, userExists);
    public void ResetLabels() => LanguagesFillers.ResetLoginLabels(UsernameLabel, PasswordLabel, PasswordConfirmLabel, EmailLabel);
    public void ToggleButtons(bool toggle) => Confirm.interactable = Login.interactable = Register.interactable = RegisterCancel.interactable = toggle;
    public void ToggleRegister(bool toggle)
    {
        ResetLabels();
        EmailHolder.gameObject.SetActive(toggle);
        PasswordConfirmHolder.gameObject.SetActive(toggle);
        Confirm.gameObject.SetActive(toggle);
        RegisterCancel.gameObject.SetActive(toggle);
        Login.gameObject.SetActive(!toggle);
        Register.gameObject.SetActive(!toggle);
    }
    public void Remember()
    {
        if (RememberMe.isOn)
        {
            PlayerPrefs.SetInt(SquadUpConstants.REMEMBER_ME, 1);
        }
    }
    public void ToggleCharSelectionUI(bool onOff) => CharSelectionUI.SetActive(onOff);
    public void ToggleConfirmation(bool onOff) => ConfirmationUI.SetActive(onOff);
    public bool CharSelected { get; private set; } = false;
    public void CharSelection(CharsTypes Character, bool selected)
    {
        CharSelected = selected;
        CharType = Character;
        PlayerPrefs.SetString(SquadUpConstants.CHAR_TYPE, Character.ToString());
    }
    public void WarnUser() => ScreenMessage.Instance.ShowMessage(MessageColor.Dark, LanguagesFillers.Lang.SelectCharacter, 2f);
}
