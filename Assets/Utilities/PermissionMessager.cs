using UnityEngine;
using UnityEngine.UI;

public class PermissionMessager : MonoBehaviour
{
    [SerializeField]
    private Text Message, Yes, No;
    // Start is called before the first frame update
    void Start()
    {
        LanguagesFillers.FillMobileRequestExplanation(Message, Yes, No);
    }
}
