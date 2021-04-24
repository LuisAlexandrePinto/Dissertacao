using UnityEngine;
using UnityEngine.UI;

public class CharSelection : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private CharsTypes Character;
    [SerializeField]
    private Toggle toggle;
    [SerializeField]
    private RegisterManager register;
#pragma warning restore 0649
    private void Awake() => toggle.onValueChanged.AddListener(CharSelected);
    private void CharSelected(bool selected) => register.CharSelection(Character, selected);
}
