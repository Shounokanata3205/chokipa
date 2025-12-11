using UnityEngine;
using UnityEngine.UI;

public class ToggleUI_Script : MonoBehaviour
{
    // 表示/非表示する対象の UI (割り当て必須)
    [SerializeField] private GameObject targetUI;

    // 任意: このボタンが指定されていれば Start() で自動的に Toggle を登録
    [SerializeField] private Button toggleButton;

    // 起動時の表示状態
    [SerializeField] private bool startActive = false;

    private void Start()
    {
        if (targetUI != null)
        {
            targetUI.SetActive(startActive);
        }

        if (toggleButton != null)
        {
            toggleButton.onClick.AddListener(Toggle);
        }
    }

    // 公開: 表示
    public void Show()
    {
        if (targetUI != null) targetUI.SetActive(true);
    }

    // 公開: 非表示
    public void Hide()
    {
        if (targetUI != null) targetUI.SetActive(false);
    }

    // 公開: トグル
    public void Toggle()
    {
        if (targetUI != null) targetUI.SetActive(!targetUI.activeSelf);
    }

    // 公開: 明示的に状態をセット
    public void SetActive(bool active)
    {
        if (targetUI != null) targetUI.SetActive(active);
    }
}
