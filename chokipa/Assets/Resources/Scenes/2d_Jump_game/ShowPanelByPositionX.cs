using UnityEngine;

public class ShowPanelByPositionX : MonoBehaviour
{
    [Header("目標のX座標")]
    public float targetX = 48.76f; // ここを 48.76f に変更しました
    [Header("表示するパネル")]
    public GameObject uiPanel;

    private bool isShown = false;

    void Update()
    {
        // まだ表示されておらず、X座標が 48.76 以上になったら
        if (!isShown && transform.position.x >= targetX)
        {
            uiPanel.SetActive(true);
            isShown = true; // 1回だけ実行
        }
    }
}