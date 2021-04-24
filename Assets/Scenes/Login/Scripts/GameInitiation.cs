using System.IO;
using UnityEngine;
#if PLATFORM_ANDROID
using UnityEngine.Android;
#endif
public class GameInitiation : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private GameObject GUI, levelLoader, blank;
    private string basePath;
    [SerializeField]
    private Animator transition;
    [SerializeField]
    private SettingsManager settingsManager;
#pragma warning restore 0649

    private bool initiated = false;
    private void Awake()
    {
        basePath = Application.persistentDataPath + "/Player-";
        SceneTransitionManager.Instance.SetLoader(levelLoader);
        SceneTransitionManager.Instance.SetAnimator(transition);
    }
    // Start is called before the first frame update
    private void Start()
    {
#if PLATFORM_ANDROID        
        if (Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {            
            StartGame();
        }
    }
#endif

    private void StartGame()
    {
        settingsManager.SetMusicVolume();
        settingsManager.SetSFXVolume();
        initiated = true;
        string username = PlayerPrefs.GetString(SquadUpConstants.USERNAME);
        if (PlayerPrefs.GetInt(SquadUpConstants.REMEMBER_ME) == 1 && username != null && username.Length >= 4 && username.Length <= 32)
        {
            string path = basePath + username + ".dat";
            if (File.Exists(path))
            {
                blank.SetActive(false);
                SceneTransitionManager.Instance.GoToScene(SquadUpConstants.SCENE_WORLD);
            }
            else
            {
                blank.SetActive(false);
                GUI.SetActive(true);
            }
        }
        else
        {
            blank.SetActive(false);
            GUI.SetActive(true);
        }
    }
    private void OnGUI()
    {
        if(Permission.HasUserAuthorizedPermission(Permission.FineLocation) && !initiated)
        {
            StartGame();
        }
    }
}
