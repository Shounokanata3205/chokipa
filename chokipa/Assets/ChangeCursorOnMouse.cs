using UnityEngine;

public class ChangeCursorOnMouse : MonoBehaviour
{
    public Texture2D cursorTexture; // 変更したいカーソルテクスチャ
    public CursorMode cursorMode = CursorMode.Auto; // カーソルモード
    public Vector2 hotSpot = Vector2.zero; // カーソルのホットスポット

    private void OnMouseEnter()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode); // カーソルを新しいテクスチャに設定
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode); // カーソルをデフォルトに戻す（nullを指定）
    }
}
