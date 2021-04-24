using UnityEngine;
using UnityEngine.UI;

public class LoadingScreenResources : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private GameObject loadingScreen;
    //[SerializeField]
    //private Image ProgressBar;
    [SerializeField]
    private Slider progressSlider;
    [SerializeField]
    private Text loadLabel;
#pragma warning restore 0649
    public GameObject LoadingScreen => loadingScreen;
    public Slider ProgressSlider => progressSlider;
    public Text LoadLabel => loadLabel;
}
