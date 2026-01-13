// File: SpriteToPlane.cs
using UnityEngine;
using UnityEngine.UI;

public class SpriteToPlane : MonoBehaviour
{
    [Header("UI Image用の画像リスト")]
    public Sprite[] imageList; 
    private Image targetImage;

    void Start()
    {
        UpdateImage();
    }

    // 外（ボタン）から呼び出せるように public にする
    public void UpdateImage()
    {
        if (targetImage == null) targetImage = GetComponent<Image>();

        int index = GameData.selectedImageID;

        if (index >= 0 && index < imageList.Length)
        {
            targetImage.sprite = imageList[index];
            targetImage.preserveAspect = true;
            Debug.Log("UI画像を更新: " + index);
        }
    }
}