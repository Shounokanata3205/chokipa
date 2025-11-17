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

void SceneToMain()
    {
        SceneManager.LoadScene("Load");
    }
    void SceneToEnd()
    {
        SceneManager.LoadScene("End");
    }
    void SceneToTitle()
    {
        SceneManager.LoadScene("title");
    }
}
