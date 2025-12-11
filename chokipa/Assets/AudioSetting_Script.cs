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

    // 追加: PlayerPrefs キー
    const string PREF_KEY_BGM_VOLUME = "AudioSetting_BGM";
    const string PREF_KEY_SE_VOLUME  = "AudioSetting_SE";

    private void Start()
    {
        // UI は最初非表示
        audioSettingUI.SetActive(false);

        // 保存された値を読み込んでスライダーに反映（無ければ 1f）
        float savedBgm = PlayerPrefs.GetFloat(PREF_KEY_BGM_VOLUME, 1f);
        float savedSe  = PlayerPrefs.GetFloat(PREF_KEY_SE_VOLUME, 1f);

        // スライダー初期値
        bgmSlider.value = savedBgm;
        seSlider.value  = savedSe;

        // 初期音量反映
        UpdateBGMVolume(savedBgm);
        UpdateSEVolume(savedSe);

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
        // 保存
        PlayerPrefs.SetFloat(PREF_KEY_BGM_VOLUME, value);
        PlayerPrefs.Save();
    }

    // SE 音量調整（複数対応）
    private void UpdateSEVolume(float value)
    {
        foreach (var src in seSources)
        {
            if (src != null) src.volume = value;
        }
        // 保存
        PlayerPrefs.SetFloat(PREF_KEY_SE_VOLUME, value);
        PlayerPrefs.Save();

        // CursorManager があればシングルトンの SE 音量も更新しておく（即時反映）
        if (CursorManager.Instance != null)
        {
            CursorManager.Instance.SetSeVolume(value);
        }
    }
}
