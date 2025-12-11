using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] ParticleSystem swipeParticlePref;
    [SerializeField] ParticleSystem tapParticlePref;
    [SerializeField] AudioClip tapSE;               // 追加: インスペクタで設定するSE
    [SerializeField] [Range(0f, 1f)] float seVolume = 1f; // 追加: SE音量

    // 追加: インスペクタで AudioSource を持つ GameObject を指定できるようにする
    [SerializeField] GameObject audioSourceObject;

    ParticleSystem swipeParticle;
    ParticleSystem tapParticle;
    AudioSource audioSource; // 追加: 再生用AudioSource

    // 変更: シングルトンを公開プロパティに変更
    public static CursorManager Instance { get; private set; }
    const string PREF_KEY_SE_VOLUME = "CursorManager_SeVolume";

    private void Awake() {
        // シングルトン化：重複していたら破棄
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            // 設定の読み込み（保存があれば上書き）
            if (PlayerPrefs.HasKey(PREF_KEY_SE_VOLUME)) {
                seVolume = PlayerPrefs.GetFloat(PREF_KEY_SE_VOLUME, seVolume);
            }
        } else if (Instance != this) {
            Destroy(gameObject);
            return;
        }
    }

    private void Start() {
        swipeParticle = Instantiate(swipeParticlePref);
        tapParticle = Instantiate(tapParticlePref);

        // AudioSource 初期化
        InitializeAudioSource();
    }

    void InitializeAudioSource() {
        if (audioSourceObject != null) {
            audioSource = audioSourceObject.GetComponent<AudioSource>();
            if (audioSource == null) {
                audioSource = audioSourceObject.AddComponent<AudioSource>();
                audioSource.playOnAwake = false;
            }
        } else {
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null) {
                audioSource = gameObject.AddComponent<AudioSource>();
                audioSource.playOnAwake = false;
            }
        }
    }

    private void Update() {
        Vector3 mousePosi = Camera.main.ScreenToWorldPoint(Input.mousePosition + Camera.main.transform.forward * 10);
        swipeParticle.transform.position = mousePosi;

        if (Input.GetMouseButtonDown(0)) {
            tapParticle.transform.position = mousePosi;
            tapParticle.Play();
            swipeParticle.Play();

            // 追加: タップ時にSEを再生
            if (tapSE != null && audioSource != null) {
                audioSource.PlayOneShot(tapSE, seVolume);
            }
        }
        if (Input.GetMouseButtonUp(0)) {
            swipeParticle.Stop();
        }
    }

    // 追加: 音量を設定して保存する（UI などから呼ぶ）
    public void SetSeVolume(float volume) {
        seVolume = Mathf.Clamp01(volume);
        PlayerPrefs.SetFloat(PREF_KEY_SE_VOLUME, seVolume);
        PlayerPrefs.Save();
    }

    // 追加: ランタイムで AudioSource を持つオブジェクトを差し替える
    public void SetAudioSourceObject(GameObject go) {
        audioSourceObject = go;
        InitializeAudioSource();
    }
}