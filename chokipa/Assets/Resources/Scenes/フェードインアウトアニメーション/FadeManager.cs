using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FadeManager : MonoBehaviour
{
    [SerializeField] CanvasGroup CanvasGroup;


    //シングルトンのコード開始
    static public FadeManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    //シングルトンのコード終了

    //フェードインフェードアウトの実装
    //明るくなる
    public void FadeIn()
    {
        CanvasGroup.DOFade(0, 1.5f);
    }
    //暗くなる
    public void FadeOut()
    {
        CanvasGroup.DOFade(1, 1.5f);
    }
    public void FadeOutToIn(TweenCallback action = null)
    {
        CanvasGroup.DOFade(1, 1.5f).OnComplete(
             () =>
             {
                action();
                FadeIn();
             });
    }
}
