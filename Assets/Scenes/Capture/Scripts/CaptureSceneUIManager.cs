using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class CaptureSceneUIManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private CaptureSceneManager manager;
    [SerializeField]
    private GameObject successScreen, failScreen, gameScreen;    
    [SerializeField]
    private Text orbCountText;
#pragma warning restore 0649

    private void Awake()
    {
        Assert.IsNotNull(manager);
        Assert.IsNotNull(successScreen);
        Assert.IsNotNull(failScreen);
        Assert.IsNotNull(gameScreen);
    }

    // Update is called once per frame
    void Update()
    {
        HandleProgressState();
    }
    private void HandleSuccess() => UpdateVisibleScreen();
    private void HandleInProgress()
    {
        UpdateVisibleScreen();
        orbCountText.text = manager.CurrentThrowAttempts.ToString();
    }
    private void HandleFailure() => UpdateVisibleScreen();
    private void UpdateVisibleScreen()
    {        
        successScreen.SetActive(manager.Status == CaptureSceneStatus.Successful);
        failScreen.SetActive(manager.Status == CaptureSceneStatus.Failed);
        gameScreen.SetActive(manager.Status == CaptureSceneStatus.InProgress);
    }
    private void HandleProgressState()
    {
        switch (manager.Status)
        {
            case CaptureSceneStatus.Failed: HandleFailure(); break;
            case CaptureSceneStatus.InProgress: HandleInProgress(); break;
            case CaptureSceneStatus.Successful: HandleSuccess(); break;
            default: break;
        }
    }
}
