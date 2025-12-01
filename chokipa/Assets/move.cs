using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class move : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public Sprite normalSprite;
    public Sprite pressedSprite;
    public Sprite otherSprite;

    private Image img;

    void Awake()
    {
        img = GetComponent<Image>();
        if (img != null)
        {
            img.sprite = normalSprite;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (img != null) img.sprite = pressedSprite;
        StartCoroutine(DelayToOther(8.0f)); // 8秒後に otherSprite に切り替え
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        StartCoroutine(ShowOtherSpriteForSeconds(0.5f)); // 離したら一時的に otherSprite を表示
    }

    private IEnumerator ShowOtherSpriteForSeconds(float sec)
    {
        if (img != null) img.sprite = otherSprite;
        yield return new WaitForSeconds(sec);
        if (img != null) img.sprite = normalSprite;
    }

    private IEnumerator DelayToOther(float sec)
    {
        yield return new WaitForSeconds(sec);
        if (img != null) img.sprite = otherSprite;
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
