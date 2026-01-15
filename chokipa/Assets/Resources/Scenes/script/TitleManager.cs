using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;


public class TitleManager : MonoBehaviour

{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTransitionToMain()
    {
        FadeManager.Instance.FadeOutToIn(SceneToMain);
    }
    public void OnTransitionToEnd()
    {
        FadeManager.Instance.FadeOutToIn(SceneToEnd);
    }
    public void OnTransitionToTitle()
    {
        FadeManager.Instance.FadeOutToIn(SceneToTitle);
    }
    public void OnTransitionToFree()
    {
        FadeManager.Instance.FadeOutToIn(SceneToFree);
    }
     public void OnTransitionToCoin()
    {
        FadeManager.Instance.FadeOutToIn(SceneToCoin);
    }
    public void OnTransitionToPlay()
    {
        FadeManager.Instance.FadeOutToIn(SceneToPlay);
    }


void SceneToMain()
    {
        SceneManager.LoadScene("MainGame");
    }
    void SceneToEnd()
    {
        SceneManager.LoadScene("room");
    }
    void SceneToTitle()
    {
        SceneManager.LoadScene("title");
    }
    void SceneToFree()
    {
        SceneManager.LoadScene("Touch");
    }
    void SceneToCoin()
    {
        SceneManager.LoadScene("MiniGame");
    }
     void SceneToPlay()
    {
        SceneManager.LoadScene("play");
    }
}
