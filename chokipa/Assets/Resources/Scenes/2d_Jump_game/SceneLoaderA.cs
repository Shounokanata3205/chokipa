using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderA : MonoBehaviour
{
    [Header("移動先のシーン名")]
    public string sceneName;

    // ボタンのOnClickからこれを呼ぶ
    public void ChangeScene()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}