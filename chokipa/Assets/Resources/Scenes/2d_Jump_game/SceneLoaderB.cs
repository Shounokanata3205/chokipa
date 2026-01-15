using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderB : MonoBehaviour
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