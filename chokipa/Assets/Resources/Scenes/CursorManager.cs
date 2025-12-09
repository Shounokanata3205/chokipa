using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] ParticleSystem swipeParticlePref;
    [SerializeField] ParticleSystem tapParticlePref;
    [SerializeField] AudioClip tapSE;               // 追加: インスペクタで設定するSE
    [SerializeField] [Range(0f, 1f)] float seVolume = 1f; // 追加: SE音量
    ParticleSystem swipeParticle;
    ParticleSystem tapParticle;
    AudioSource audioSource; // 追加: 再生用AudioSource

    private void Start() {
        swipeParticle = Instantiate(swipeParticlePref);
        tapParticle = Instantiate(tapParticlePref);

        // AudioSource を取得、なければ追加
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null) {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
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
}