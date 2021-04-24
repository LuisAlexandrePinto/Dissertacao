using System;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private GameObject FWBL, FWRH, FWBR, FABR, FABL, FBBR, FBBL, MWBL, MWBK, MWBR, MABR, MABK, MBBR, MBBK;
    [SerializeField]
    private Transform PlayerContainer;
#pragma warning restore 0649
    private CharsTypes charType;
    public void Awake() => ProcessCharType();
    public GameObject PlayerCharacter { get; private set; }
    private void ProcessCharType()
    {
        switch (GameManager.Instance.CurrentPlayer.CharType)
        {
            case CharsTypes.FemaleWhiteBlonde:
                PlayerCharacter = Instantiate(FWBL, PlayerContainer, false);
                break;
            case CharsTypes.FemaleWhiteRedHead:
                PlayerCharacter = Instantiate(FWRH, PlayerContainer, false);
                break;
            case CharsTypes.FemaleWhiteBrown:
                PlayerCharacter = Instantiate(FWBR, PlayerContainer, false);
                break;
            case CharsTypes.FemaleAsianBrown:
                PlayerCharacter = Instantiate(FABR, PlayerContainer, false);
                break;
            case CharsTypes.FemaleAsianBlonde:
                PlayerCharacter = Instantiate(FABL, PlayerContainer, false);
                break;
            case CharsTypes.FemaleBlackBrown:
                PlayerCharacter = Instantiate(FBBR, PlayerContainer, false);
                break;
            case CharsTypes.FemaleBlackBlonde:
                PlayerCharacter = Instantiate(FBBL, PlayerContainer, false);
                break;
            case CharsTypes.MaleWhiteBlonde:
                PlayerCharacter = Instantiate(MWBL, PlayerContainer, false);
                break;
            case CharsTypes.MaleWhiteBlack:
                PlayerCharacter = Instantiate(MWBL, PlayerContainer, false);
                break;
            case CharsTypes.MaleWhiteBrown:
                PlayerCharacter = Instantiate(MWBR, PlayerContainer, false);
                break;
            case CharsTypes.MaleAsianBrown:
                PlayerCharacter = Instantiate(MABR, PlayerContainer, false);
                break;
            case CharsTypes.MaleAsianBlack:
                PlayerCharacter = Instantiate(MABK, PlayerContainer, false);
                break;
            case CharsTypes.MaleBlackBrown:
                PlayerCharacter = Instantiate(MBBR, PlayerContainer, false);
                break;
            case CharsTypes.MaleBlackBlack:
                PlayerCharacter = Instantiate(MBBK, PlayerContainer, false);
                break;
            default:
                PlayerCharacter = Instantiate(FWBL, PlayerContainer, false);
                break;
                /*
                string character = PlayerPrefs.GetString(SquadUpConstants.CHAR_TYPE);
                if (Enum.TryParse(character, out charType))
                {
                    switch (charType)
                    {
                        case CharsTypes.FemaleWhiteBlonde:
                            PlayerCharacter = Instantiate(FWBL, PlayerContainer, false);
                            break;
                        case CharsTypes.FemaleWhiteRedHead:
                            PlayerCharacter = Instantiate(FWRH, PlayerContainer, false);
                            break;
                        case CharsTypes.FemaleWhiteBrown:
                            PlayerCharacter = Instantiate(FWBR, PlayerContainer, false);
                            break;
                        case CharsTypes.FemaleAsianBrown:
                            PlayerCharacter = Instantiate(FABR, PlayerContainer, false);
                            break;
                        case CharsTypes.FemaleAsianBlonde:
                            PlayerCharacter = Instantiate(FABL, PlayerContainer, false);
                            break;
                        case CharsTypes.FemaleBlackBrown:
                            PlayerCharacter = Instantiate(FBBR, PlayerContainer, false);
                            break;
                        case CharsTypes.FemaleBlackBlonde:
                            PlayerCharacter = Instantiate(FBBL, PlayerContainer, false);
                            break;
                        case CharsTypes.MaleWhiteBlonde:
                            PlayerCharacter = Instantiate(MWBL, PlayerContainer, false);
                            break;
                        case CharsTypes.MaleWhiteBlack:
                            PlayerCharacter = Instantiate(MWBL, PlayerContainer, false);
                            break;
                        case CharsTypes.MaleWhiteBrown:
                            PlayerCharacter = Instantiate(MWBR, PlayerContainer, false);
                            break;
                        case CharsTypes.MaleAsianBrown:
                            PlayerCharacter = Instantiate(MABR, PlayerContainer, false);
                            break;
                        case CharsTypes.MaleAsianBlack:
                            PlayerCharacter = Instantiate(MABK, PlayerContainer, false);
                            break;
                        case CharsTypes.MaleBlackBrown:
                            PlayerCharacter = Instantiate(MBBR, PlayerContainer, false);
                            break;
                        case CharsTypes.MaleBlackBlack:
                            PlayerCharacter = Instantiate(MBBK, PlayerContainer, false);
                            break;
                        default:
                            PlayerCharacter = Instantiate(FWBL, PlayerContainer, false);
                            break;
                    }
                }*/
        }
    }
}
