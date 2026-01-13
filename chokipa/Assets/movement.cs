using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class movement : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public Sprite normalSprite;
    public Sprite pressedSprite;
    public Sprite otherSprite;

    //ハートアニメーション
    public int tap = 10;
    private int tapCount = 0;
    public GameObject otherObject;
    public UnityEngine.Animator otherAnimator;
    public float showDuration = 2.5f; // 固定待機時間（デフォルト2.5秒）

    private Image img;

    private float pressStartTime = 0f;
    private float requiredPressTime = 0.7f;

    private bool isPressing = false;
    private bool longPressed = false;
    private bool isAnimating = false;

    void Awake()
    {
        img = GetComponent<Image>();
        img.sprite = normalSprite;
        
        // otherAnimator が Inspector で未設定なら otherObject から自動取得を試みる
        if (otherAnimator == null && otherObject != null)
        {
            otherAnimator = otherObject.GetComponent<Animator>();
            if (otherAnimator == null)
            {
                otherAnimator = otherObject.GetComponentInChildren<Animator>();
            }
            
        }

        if (otherObject != null) otherObject.SetActive(false); // 初期状態は非表示
        if (otherAnimator != null) otherAnimator.enabled = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // 長押し2秒が完了するまでドラッグ禁止
        if (!longPressed) return;

        transform.position = eventData.position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pressStartTime = Time.time;
        isPressing = true;
        longPressed = false; // 押すたびにリセット
        img.sprite = normalSprite;

        // クリックカウント
        tapCount++;
        if (tapCount >= tap && !isAnimating)
        {
            // カウント到達時に表示してアニメーションを実行
            if (otherObject != null)
            {
                StartCoroutine(ShowAndAnimate());
            }
            tapCount = 0; // リセット
            longPressed = false; // 長押し状態をリセット
            // tapCount が 0 になったのでオブジェクトは非表示（アニメーション終了後にも確実に非表示にする）
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressing = false;

        if (longPressed)
        {
            StartCoroutine(ShowOtherSpriteForSeconds(1.0f));
        }
        else
        {
            img.sprite = normalSprite;
        }
    }

    void Update()
    {
        // 長押しチェック
        if (isPressing && !longPressed)
        {
            if (Time.time - pressStartTime >= requiredPressTime)
            {
                longPressed = true;
                img.sprite = pressedSprite; // 長押し成功
            }
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            transform.localScale *= 1 + scroll;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.localScale = Vector3.one;
        }
    }

    private IEnumerator ShowOtherSpriteForSeconds(float sec)
    {
        img.sprite = otherSprite;
        yield return new WaitForSeconds(sec);
        img.sprite = normalSprite;
    }

    private IEnumerator ShowAndAnimate()
    {
        if (isAnimating) yield break;
        isAnimating = true;

        if (otherObject != null) otherObject.SetActive(true);

        if (otherAnimator != null)
        {
            otherAnimator.enabled = true;
            otherAnimator.Play(0, 0, 0f);
            // 再生開始のために1フレーム待ち
            yield return null;

            // 再生中のクリップ情報を取得
            float waitTime = showDuration;
            var clips = otherAnimator.GetCurrentAnimatorClipInfo(0);
            if (clips != null && clips.Length > 0 && clips[0].clip != null)
            {
                var clip = clips[0].clip;
                // Animator の speed を考慮
                float speed = Mathf.Approximately(otherAnimator.speed, 0f) ? 1f : otherAnimator.speed;
                waitTime = clip.length / speed;
                
            }
            // 最低待機時間を確保（1フレームで消えるのを防ぐ）
            waitTime = Mathf.Max(waitTime, 0.1f);
            yield return new WaitForSeconds(waitTime);
        }
        else
        {
            yield return new WaitForSeconds(showDuration);
        }

        // 終了時は必ず非表示にする
        if (otherObject != null)
        {
            otherObject.SetActive(false);
        }

        isAnimating = false;
    }
}
