using UnityEngine;
#if PLATFORM_ANDROID
using UnityEngine.Android;
using UnityEngine.UI;
#endif

public class PermissionsRationaleDialog : MonoBehaviour
{
    private bool windowOpen = true;
    private GameObject confirmationBox;
    private Button Yes, No;
    public void GetConfirmationBox(GameObject confirmationBox, Button Yes, Button No)
    {
        this.confirmationBox = confirmationBox;
        this.Yes = Yes;
        this.No = No;
    }

    void DoMyWindow()
    {
        Yes.onClick.AddListener(AcceptNewRequest);
        No.onClick.AddListener(ShutdownApp);        
    }

    private void AcceptNewRequest()
    {
#if PLATFORM_ANDROID
        Permission.RequestUserPermission(Permission.FineLocation);
#endif
        confirmationBox.SetActive(false);
        windowOpen = false;
    }

    private void ShutdownApp()
    {
#if PLATFORM_ANDROID
        Application.Quit();
#endif
        windowOpen = false;
    }
    private void OnGUI()
    {
        if (windowOpen)
        {
            confirmationBox.SetActive(true);
            DoMyWindow();
        }
    }
}