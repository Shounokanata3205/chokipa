using UnityEngine;

public class SpriteToPlane : MonoBehaviour
{
    public Sprite[] imageList; // インスペクターで画像を登録する

    void Start()
    {
        // 1番＝配列の0番目なので -1 する
        int index = GameData.selectedImageID - 1;

        if (index >= 0 && index < imageList.Length)
        {
            Sprite targetSprite = imageList[index];
            
            // 画像をPlaneに適用
            GetComponent<Renderer>().material.mainTexture = targetSprite.texture;

            // 画像の比率に合わせてPlaneの大きさを調整
            float aspectRatio = (float)targetSprite.texture.width / targetSprite.texture.height;
            
            // Planeの基本サイズ(10)を考慮してScaleを設定
            // 縦を基準(0.1)とし、横にアスペクト比を掛ける
            transform.localScale = new Vector3(0.1f * aspectRatio, 1f, 0.1f);
        }
    }
}