using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class move : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public Sprite normalSprite;
    public Sprite pressedSprite;
    public Sprite otherSprite;

    public Image ikariIcon;

    private Image img;
    private bool ikariIconActive = false;
    private int ikariIconCount = 0;

    void Awake()
    {
        img = GetComponent<Image>();
        img.sprite = normalSprite;
        if (ikariIcon != null)
        {
            ikariIcon.gameObject.SetActive(false);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        img.sprite = pressedSprite;
        if (!ikariIconActive)
        {
            ikariIconActive = true;
            StartCoroutine(DelayShowIkariIcon(8.0f, 10.0f));
        }
        StartCoroutine(DelayToOther(8.0f));
    }

    private IEnumerator DelayShowIkariIcon(float delay, float sec)
    {
        yield return new WaitForSeconds(delay);
        ikariIcon.gameObject.SetActive(true);
        ikariIconCount++;
        Debug.Log($"{ikariIconCount}回");
        yield return new WaitForSeconds(sec);
        ikariIcon.gameObject.SetActive(false);
        ikariIconActive = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ikariIcon.gameObject.SetActive(false);
        StartCoroutine(ShowOtherSpriteForSeconds(0.5f));
    }

    private IEnumerator ShowOtherSpriteForSeconds(float sec)
    {
        img.sprite = otherSprite;
        yield return new WaitForSeconds(sec);
        img.sprite = normalSprite;
    }

    private IEnumerator DelayToOther(float sec)
    {
        yield return new WaitForSeconds(sec);
        img.sprite = otherSprite;
    }

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            float scaleChange = 1 + scroll;
            transform.localScale *= scaleChange;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.localScale = Vector3.one;
        }
    }
}