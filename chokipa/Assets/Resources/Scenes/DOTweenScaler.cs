using DG.Tweening; // ★必須！
using UnityEngine;
using UnityEngine.EventSystems; // クリックイベントを直接処理する場合

public class DOTweenScaler : MonoBehaviour, IPointerDownHandler
{
    [Header("クリック時の設定")]
    [Tooltip("ボタンが膨らむ最大のスケール (例: 1.1)")]
    public float scaleUpMultiplier = 1.1f;
    [Tooltip("スケール変更にかかる時間 (秒)")]
    public float duration = 0.15f;

    private Vector3 normalScale = Vector3.one;
    private Vector3 enlargedScale;

    [Header("パルス挙動の設定 (Trueで常に有効)")]
    [Tooltip("常にパルス（膨張・収縮）を繰り返すかどうか")]
    public bool isPulsing = false;
    [Tooltip("パルスが1往復するのにかかる時間 (秒)")]
    public float pulseDuration = 1.0f; 

    void Start()
    {
        // 初期スケール（通常サイズ）を保持
        normalScale = transform.localScale;
        // 膨張後のスケールを計算
        enlargedScale = normalScale * scaleUpMultiplier;

        // 設定に応じてパルスを開始
        if (isPulsing)
        {
            StartPulsing();
        }
    }

    // --------------------------------------------------
    // 1. クリック時の挙動 (IPointerDownHandlerを利用)
    // --------------------------------------------------
    
    // マウス/指がボタンに触れて押し込んだ瞬間に呼ばれる
    public void OnPointerDown(PointerEventData eventData)
    {
        // 既にパルス中の場合は、クリック時のアニメーションを行わない
        if (isPulsing) return;
        
        // 現在実行中のDOTweenシーケンスを一旦停止・リセット
        transform.DOKill(); 
        transform.localScale = normalScale; // スケールを基準に戻す

        // 連続したアニメーション（シーケンス）を一行で定義
        // Sequenceはアニメーションを順番に実行するための機能です。
        DOTween.Sequence()
            // 1. 膨張アニメーション
            .Append(transform.DOScale(enlargedScale, duration).SetEase(Ease.OutQuad))
            // 2. 収縮アニメーション (Appendで1の後ろに繋げる)
            .Append(transform.DOScale(normalScale, duration).SetEase(Ease.InQuad));
    }

    // --------------------------------------------------
    // 2. 常にパルスする挙動
    // --------------------------------------------------

    private void StartPulsing()
    {
        // 現在実行中のDOTweenをすべて停止し、新しいパルスを開始
        transform.DOKill(); 
        
        // 無限ループアニメーションを定義
        transform.DOScale(enlargedScale, pulseDuration)
            // .SetLoops(-1, LoopType.Yoyo) : 無限回 (-1) ループし、「行って戻って」 (Yoyo) を繰り返す
            .SetLoops(-1, LoopType.Yoyo)
            // .SetEase(Ease.InOutSine) : スムーズな加速・減速で自然なパルス感を演出
            .SetEase(Ease.InOutSine);
    }

    // パルスのON/OFFを外部から切り替えるためのメソッド
    public void SetPulsing(bool shouldPulse)
    {
        isPulsing = shouldPulse;
        if (isPulsing)
        {
            StartPulsing();
        }
        else
        {
            // パルスを停止し、元のサイズに戻す
            transform.DOKill(); 
            transform.DOScale(normalScale, duration);
        }
    }
}