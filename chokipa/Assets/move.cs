using UnityEngine;
using UnityEngine.EventSystems;

public class move : MonoBehaviour, IDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        // マウス（タッチ）位置にImageを移動
        transform.position = eventData.position;
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