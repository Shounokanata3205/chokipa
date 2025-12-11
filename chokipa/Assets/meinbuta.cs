using UnityEngine;
using TMPro;


public class ClickRandomImage : MonoBehaviour
{
    public GameObject[] clickImages; 
    public float showTime = 0.1f;

    private bool isShowing = false;

    public TextMeshProUGUI messageText;

    private string[] messages = {
        "  ぶひっ ",
        "  ぷごっ ",
        "  ぶりっ ",
        "  ぷぎっ ",
    };
    void Start()
    {
        foreach (var img in clickImages)
            img.SetActive(false);

        if (messageText == null)
            messageText = GameObject.Find("MessageText").GetComponent<TextMeshProUGUI>();

        messageText.gameObject.SetActive(false);
    }


    void OnMouseDown()
    {
        if (isShowing) return;

        StartCoroutine(ShowEffect());
    }

    private System.Collections.IEnumerator ShowEffect()
    {
        isShowing = true;

        // ランダム画像
        int idx = Random.Range(0, clickImages.Length);
        clickImages[idx].SetActive(true);

        // ランダムメッセージ
        messageText.text = messages[Random.Range(0, messages.Length)];
        messageText.gameObject.SetActive(true);

        // showTimeだけ表示
        yield return new WaitForSeconds(showTime);

        // 消す
        clickImages[idx].SetActive(false);
        messageText.gameObject.SetActive(false);

        isShowing = false;
    }
}
