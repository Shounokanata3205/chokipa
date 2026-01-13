using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDataSender : MonoBehaviour
{
    public int valueToSend; // ボタンごとに変える数値
    public string nextSceneName; // 移動先のシーン名

    public void OnButtonClick()
    {
        GameData.selectedImageID = valueToSend;
        SceneManager.LoadScene(nextSceneName);
    }
}