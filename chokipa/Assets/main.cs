using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class move : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public Sprite normalSprite;
    public Sprite pressedSprite;
    public Sprite otherSprite;

    public GameObject tapEffectObj;  
    public Vector2 tapOffset = new Vector2(80, 80);

    private Image img;
    private RectTransform rect;
    private RectTransform tapRect;

    private float pressStartTime = 0f;
    private float requiredPressTime = 1.0f;

    private bool isPressing = false;
    private bool longPressed = false;
    private bool isDragging = false;

    void Awake()
    {
        img = GetComponent<Image>();
        rect = GetComponent<RectTransform>();
        img.sprite = normalSprite;

        if (tapEffectObj != null)
        {
            tapRect = tapEffectObj.GetComponent<RectTransform>();
            tapEffectObj.SetActive(false);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pressStartTime = Time.time;
        isPressing = true;
        longPressed = false;
        isDragging = false;

        img.sprite = normalSprite;

        if (tapEffectObj != null)
            tapEffectObj.SetActive(false);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressing = false;

        if (longPressed)
        {
            StartCoroutine(ShowOtherSpriteForSeconds(1.0f));
        }
        else if (!isDragging)
        {
            StartCoroutine(ShowTapEffect());
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!longPressed) return;

        isDragging = true;

        if (tapEffectObj != null)
            tapEffectObj.SetActive(false);

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rect.parent as RectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out Vector2 localPos
        );

        rect.anchoredPosition = localPos;
    }

    void Update()
    {
        if (isPressing && !longPressed)
        {
            if (Time.time - pressStartTime >= requiredPressTime)
            {
                longPressed = true;
                img.sprite = pressedSprite;
            }
        }

        if (tapEffectObj != null && tapEffectObj.activeSelf)
        {
            tapRect.anchoredPosition = rect.anchoredPosition + tapOffset;
        }
    }

    private IEnumerator ShowOtherSpriteForSeconds(float sec)
    {
        img.sprite = otherSprite;
        yield return new WaitForSeconds(sec);
        img.sprite = normalSprite;
    }

    private IEnumerator ShowTapEffect()
    {
        tapEffectObj.SetActive(true);
        tapRect.anchoredPosition = rect.anchoredPosition + tapOffset;

        yield return new WaitForSeconds(0.3f);

        tapEffectObj.SetActive(false);
    }
}
