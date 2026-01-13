using UnityEngine;

public class SpriteChanger2D : MonoBehaviour
{
    [Header("2Dオブジェクト用の画像リスト")]
    public Sprite[] imageList;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // 2Dオブジェクトの描画コンポーネントを取得
        spriteRenderer = GetComponent<SpriteRenderer>();

        // GameDataからIDを取得（0スタート）
        int index = GameData.selectedImageID;

        Debug.Log("2Dオブジェクト側でIDを受信: " + index);

        if (index >= 0 && index < imageList.Length)
        {
            // SpriteRendererの画像を差し替え
            spriteRenderer.sprite = imageList[index];
            Debug.Log("2Dオブジェクトの画像を更新しました: " + imageList[index].name);
        }
        else
        {
            Debug.LogWarning("2D画像リストに ID " + index + " の画像が登録されていません。");
        }
    }
}