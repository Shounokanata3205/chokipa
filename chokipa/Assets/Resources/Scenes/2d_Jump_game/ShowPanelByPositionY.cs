using UnityEngine;

public class ShowPanelByPositionY : MonoBehaviour
{
    [Header("目標のY座標")]
    public float targetY = -5f; // ここを -5f に変更
    [Header("表示するパネル")]
    public GameObject uiPanel;

    private bool isShown = false;

    void Update()
    {
        // まだ表示されておらず、Y座標が targetY ( -5 ) 以下になったら
        if (!isShown && transform.position.y <= targetY)
        {
            uiPanel.SetActive(true);
            isShown = true; // 1回だけ実行
        }
    }
}