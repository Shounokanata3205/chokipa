using UnityEngine;
using TMPro;

public class ClickRandomImage : MonoBehaviour
{
    public GameObject[] clickImages; // ランダム表示する画像
    public float showTime = 0.1f;    // 表示時間

    private bool isShowing = false;  // 今表示中かどうか

    public TextMeshProUGUI messageText;  // 表示するテキスト

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
    }

    void OnMouseDown()
    {
        // 表示中ならクリック無視
        if (isShowing) return;

        // ランダムメッセージ表示
        ShowRandomMessage();

        // ランダム画像表示
        StartCoroutine(ShowRandomImage());
    }

    private System.Collections.IEnumerator ShowRandomImage()
    {
        isShowing = true;

        int index = Random.Range(0, clickImages.Length);

        clickImages[index].SetActive(true);
        yield return new WaitForSeconds(showTime);
        clickImages[index].SetActive(false);

        isShowing = false;
    }

    private void ShowRandomMessage()
    {
        messageText.text = messages[Random.Range(0, messages.Length)];
    }
}
