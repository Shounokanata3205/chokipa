using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    [SerializeField] private GameObject _loadingUI;
    [SerializeField] private Slider _slider;

public void LoadNextScene()
{
    FadeManager.Instance.FadeOutToIn(() =>
    {
        // フェードアウト後にロード処理スタート
        StartCoroutine(LoadScene());
    });
}

IEnumerator LoadScene()
{
    _loadingUI.SetActive(true);

    AsyncOperation async = SceneManager.LoadSceneAsync("MainGame");
    async.allowSceneActivation = false;

    while (async.progress < 0.9f)
    {
        _slider.value = async.progress;
        yield return null;
    }

    _slider.value = 1;

    // ここではすぐ遷移せず、FadeIn は FadeManager が後でやるのでここで完了を解放
    async.allowSceneActivation = true;
}
}
