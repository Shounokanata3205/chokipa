using UnityEngine;
using UnityEngine.UI; // UIを扱うために必須

public class SpriteToPlane : MonoBehaviour
{
    [Header("表示したい画像のリスト(Sprite)")]
    public Sprite[] imageList; 

    private Image targetImage;

    void Start()
    {
        // 自分のImageコンポーネントを取得
        targetImage = GetComponent<Image>();

        // 【修正ポイント】 -1 をせず、そのままの数値を使う
        int index = GameData.selectedImageID;

        // ログを出して数値を確認
        Debug.Log("受け取ったID: " + index);

        // indexが0以上、かつリストの枚数より小さいかチェック
        if (index >= 0 && index < imageList.Length)
        {
            // Spriteを差し替える
            targetImage.sprite = imageList[index];

            // 比率維持
            targetImage.preserveAspect = true;

            Debug.Log("画像を更新しました。リストの " + index + " 番目を使用中");
        }
        else
        {
            // 範囲外の場合の警告
            Debug.LogWarning("ID " + index + " は画像リストの範囲外です。リストのSizeを確認してください。");
        }
    }
}