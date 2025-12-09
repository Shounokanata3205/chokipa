using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class movement : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public Sprite normalSprite;
    public Sprite pressedSprite;
    public Sprite otherSprite;

    private Image img;

    private float pressStartTime = 0f;
    private float requiredPressTime = 0.7f;

    private bool isPressing = false;
    private bool longPressed = false;

    void Awake()
    {
        img = GetComponent<Image>();
        img.sprite = normalSprite;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // 🔒 長押し2秒が完了するまでドラッグ禁止
        if (!longPressed) return;

        transform.position = eventData.position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pressStartTime = Time.time;
        isPressing = true;
        longPressed = false; // 押すたびにリセット
        img.sprite = normalSprite;
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
}
