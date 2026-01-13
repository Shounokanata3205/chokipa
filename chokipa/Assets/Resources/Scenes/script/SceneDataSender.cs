// File: SceneDataSender.cs
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDataSender : MonoBehaviour
{
    public int valueToSend;
    public string nextSceneName;

    public void OnButtonClick()
    {
        // 1. データを保存
        GameData.selectedImageID = valueToSend;

        // 2. 同じシーン内のUI Image用スクリプトを探して更新
        SpriteToPlane uiScript = FindObjectOfType<SpriteToPlane>();
        if (uiScript != null) uiScript.UpdateImage();

        // 3. 同じシーン内の2D Sprite用スクリプトを探して更新
        SpriteChanger2D spriteScript = FindObjectOfType<SpriteChanger2D>();
        if (spriteScript != null) spriteScript.UpdateImage();

        // 4. シーン名が入力されていれば移動
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}