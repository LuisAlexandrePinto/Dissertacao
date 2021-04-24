using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTransitionManager : Singleton<SceneTransitionManager>
{    
    private Animator transition;    
    private GameObject levelLoader;
    public void SetLoader(GameObject levelLoader) => this.levelLoader = levelLoader;
    public void SetAnimator(Animator transition) => this.transition = transition;
    /// <summary>
    /// Creates and starts a coroutine responsible for loading and moving objects into the scene specified.
    /// </summary>
    /// <param name="sceneName"> string containing the name of the scene to go to.</param>
    public void GoToScene(string sceneName) => StartCoroutine(LoadSceneNormal(sceneName));
    private IEnumerator LoadSceneNormal(string sceneName)
    {
        levelLoader.SetActive(true);
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
        yield return null;
    }
}