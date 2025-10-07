using System.Collections; // ←これを追加
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class move : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public Sprite normalSprite;    // 通常時の画像
    public Sprite pressedSprite;   // クリック中の画像
    public Sprite otherSprite;     // 別の画像

    public Image ikariIcon; // Inspectorで右上Imageをセット

    private Image img;

    void Awake()
    {
        img = GetComponent<Image>();
        img.sprite = normalSprite;
        if (ikariIcon != null)
        {
            ikariIcon.gameObject.SetActive(false); // 最初は非表示
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        // マウス（タッチ）位置にImageを移動
        transform.position = eventData.position;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        img.sprite = pressedSprite; // クリック中の画像に変更
        StartCoroutine(DelayToOther(10.0f)); // 10秒後にotherSpriteへ
        StartCoroutine(DelayShowIkariIcon(10.0f,10.0f)); // 10秒後に10秒だけ表示
    }

    // 10秒待ってからアイコンを表示し、さらにsec秒後に非表示
    private IEnumerator DelayShowIkariIcon(float delay, float sec)
    {
        yield return new WaitForSeconds(delay); // まずdelay秒待つ
        ikariIcon.gameObject.SetActive(true);   // 表示
        yield return new WaitForSeconds(sec);   // sec秒待つ
        ikariIcon.gameObject.SetActive(false);  // 非表示
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        StartCoroutine(ShowOtherSpriteForSeconds(0.5f));
    }

    private IEnumerator ShowOtherSpriteForSeconds(float sec)
    {
        img.sprite = otherSprite; // 別の画像に変更
        yield return new WaitForSeconds(sec);
        img.sprite = normalSprite; // 通常画像に戻す
    }

    private IEnumerator DelayToOther(float sec)
    {
        yield return new WaitForSeconds(sec);
        img.sprite = otherSprite; // 別の画像に変更
    }

    void Update()
    {
        // マウスホイールで拡大・縮小
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            float scaleChange = 1 + scroll; // スクロール量に応じて倍率変更
            transform.localScale *= scaleChange;
        }

        // Rキーでリセット
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.localScale = Vector3.one; // 元のサイズにリセット
        }
    }
}