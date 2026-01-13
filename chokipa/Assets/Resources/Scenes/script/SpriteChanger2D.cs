// File: SpriteChanger2D.cs
using UnityEngine;

public class SpriteChanger2D : MonoBehaviour
{
    [Header("2D Sprite用の画像リスト")]
    public Sprite[] imageList;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        UpdateImage();
    }

    // 外（ボタン）から呼び出せるように public にする
    public void UpdateImage()
    {
        if (spriteRenderer == null) spriteRenderer = GetComponent<SpriteRenderer>();

        int index = GameData.selectedImageID;

        if (index >= 0 && index < imageList.Length)
        {
            spriteRenderer.sprite = imageList[index];
            Debug.Log("2Dスプライトを更新: " + index);
        }
    }
}