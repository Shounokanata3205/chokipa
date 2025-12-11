using UnityEngine;
using UnityEngine.UI;

public class AudioSetting_Script : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject audioSettingUI;
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider seSlider;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource[] bgmSources;
    [SerializeField] private AudioSource[] seSources;

    private void Start()
    {
        // UI は最初非表示
        audioSettingUI.SetActive(false);

        // スライダー初期値
        bgmSlider.value = 1f;
        seSlider.value  = 1f;

        // スライダー変更時のイベント
        bgmSlider.onValueChanged.AddListener(UpdateBGMVolume);
        seSlider.onValueChanged.AddListener(UpdateSEVolume);
    }

    // UI を開く
    public void OpenSettingUI()
    {
        audioSettingUI.SetActive(true);
    }

    // UI を閉じる
    public void CloseSettingUI()
    {
        audioSettingUI.SetActive(false);
    }

    // BGM 音量調整（複数対応）
    private void UpdateBGMVolume(float value)
    {
        foreach (var src in bgmSources)
        {
            if (src != null) src.volume = value;
        }
    }

    // SE 音量調整（複数対応）
    private void UpdateSEVolume(float value)
    {
        foreach (var src in seSources)
        {
            if (src != null) src.volume = value;
        }
    }
}
