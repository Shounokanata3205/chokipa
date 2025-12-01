using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] ParticleSystem swipeParticlePref;
    [SerializeField] ParticleSystem tapParticlePref;
    ParticleSystem swipeParticle;
    ParticleSystem tapParticle;

    private void Start() {
        swipeParticle = Instantiate(swipeParticlePref);
        tapParticle = Instantiate(tapParticlePref);
    }

    private void Update() {
        Vector3 mousePosi = Camera.main.ScreenToWorldPoint(Input.mousePosition + Camera.main.transform.forward * 10);
        swipeParticle.transform.position = mousePosi;

        if (Input.GetMouseButtonDown(0)) {
            tapParticle.transform.position = mousePosi;
            tapParticle.Play();
            swipeParticle.Play();
        }
        if (Input.GetMouseButtonUp(0)) {
            swipeParticle.Stop();
        }
    }
}