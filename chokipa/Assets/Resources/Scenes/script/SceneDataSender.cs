using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDataSender : MonoBehaviour
{
    public int valueToSend;
    public string nextSceneName;

    public void OnButtonClick()
    {
        GameData.selectedImageID = valueToSend;
        SceneManager.LoadScene(nextSceneName);
    }
}