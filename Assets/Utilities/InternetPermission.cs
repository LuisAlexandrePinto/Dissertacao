using UnityEngine;
#if PLATFORM_ANDROID
using UnityEngine.Android;
using UnityEngine.UI;
#endif

public class InternetPermission : MonoBehaviour
{
    GameObject dialog = null;
    [SerializeField]
    private Text Message, Yes, No;
    [SerializeField]
    private Button YesBtn, NoBtn;
    [SerializeField]
    private GameObject ConfirmationBox;    
    void Start()
    {
        LanguagesFillers.FillMobileRequestExplanation(Message, Yes, No);

#if PLATFORM_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
            dialog = new GameObject();
       }
#endif
    }

    void OnGUI()
    {
#if PLATFORM_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            dialog.AddComponent<PermissionsRationaleDialog>();
            PermissionsRationaleDialog permissions = dialog.GetComponent<PermissionsRationaleDialog>();
            permissions.GetConfirmationBox(ConfirmationBox, YesBtn, NoBtn);
            return;
        }
        else if (dialog != null)
        {
            Destroy(dialog);
        }
#endif       
    }
}
