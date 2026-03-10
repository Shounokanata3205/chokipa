using UnityEngine;
using UnityEngine.UI;

public class PigController : MonoBehaviour
{
    [Header("おなかゲージの設定")]
    public Image hungerGauge;       // インスペクターで「i」をセット
    public float maxHunger = 100f;  // 最大値
    public float currentHunger;     // 現在の値
    public float decreaseRate = 0.1666f; // 減る速度

    void Start()
    {
        // ゲーム開始時は満タンからスタート
        currentHunger = maxHunger;
        UpdateUI();
    }

    void Update()
    {
        // 時間とともにおなかが減る
        if (currentHunger > 0f)
        {
            currentHunger -= decreaseRate * Time.deltaTime;
            UpdateUI();
        }
    }

    // フルーツを食べた時の判定処理
    public void EatFruit(string fruitType)
    {
        float recoveryAmount = 0f;

        // 名前によって回復量を変える
        if (fruitType == "Cherry") {
            recoveryAmount = 30f; // 大好物
        }
        else if (fruitType == "Apple" || fruitType == "Orange") {
            recoveryAmount = 15f; // 普通
        }
        else if (fruitType == "Blueberry") {
            recoveryAmount = 5f;  // 微妙
        }
        else if (fruitType == "Melon") {
            recoveryAmount = -10f; // 苦手（減る）
        }

        currentHunger += recoveryAmount;

        // 0〜100の間に収める
        currentHunger = Mathf.Clamp(currentHunger, 0f, maxHunger);
        UpdateUI();
    }

    void UpdateUI()
    {
        if (hungerGauge != null)
        {
            // 画像のFill Amount（0〜1）に変換して反映
            hungerGauge.fillAmount = currentHunger / maxHunger;
        }
    }
}