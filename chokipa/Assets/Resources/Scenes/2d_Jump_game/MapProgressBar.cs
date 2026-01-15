using UnityEngine;
using UnityEngine.UI; // スライダーを使うために必要

public class MapProgressBar : MonoBehaviour
{
    [Header("参照")]
    public Transform player;      // プレイヤーのTransform
    public Slider progressBar;    // UIのスライダー

    [Header("地点設定")]
    public float startX = 0f;     // 開始地点のX座標
    public float endX = 100f;     // 終了地点のX座標

    void Update()
    {
        if (player == null || progressBar == null) return;

        // 現在のプレイヤーのX座標を取得
        float currentX = player.position.x;

        // 進捗率を計算 (0.0 ～ 1.0)
        // (現在地 - 開始地) / (終了地 - 開始地)
        float progress = (currentX - startX) / (endX - startX);

        // 値が 0以下や 1以上にならないように制限（クランプ）
        progress = Mathf.Clamp01(progress);

        // スライダーに反映
        progressBar.value = progress;
    }
}