using UnityEngine;
using UnityEngine.Serialization;

namespace TedLab
{
    // エディタでの設定変更時に即座に更新されるようにする
    [ExecuteInEditMode] 
    public class RectScalerWithViewport : MonoBehaviour
    {
        private const float LogBase = 2;

        [Header("参照設定")]
        [Tooltip("ターゲットカメラ。設定されていない場合はCamera.mainを使用します。")]
        [SerializeField] private Camera refCamera = null;
        
        [Tooltip("スケール調整を行うRectTransform。設定されていない場合はこのGameObjectのコンポーネントを使用します。")]
        [SerializeField] private RectTransform refRect = null;
        
        [Header("スケーリング設定")]
        [Tooltip("基準となる解像度（e.g., 1920x1080）。")]
        [SerializeField] private Vector2 referenceResolution = new Vector2(1920, 1080);
        
        [Tooltip("0: 幅優先, 1: 高さ優先, 0.5: 幅と高さの比率を考慮")]
        [Range(0, 1)] 
        [SerializeField] private float matchWidthOrHeight = 0;

        // キャッシュされた値
        private Camera _targetCamera;
        private float _widthCache = -1;
        private float _heightCache = -1;
        private float _matchCache = -1;

        private void Awake()
        {
            if (refRect == null)
            {
                refRect = GetComponent<RectTransform>();
            }
        }

        private void OnEnable()
        {
            InitializeCamera();
            UpdateRect(true); // 強制更新
        }

        private void Update()
        {
            if (!Application.isPlaying)
            {
                // エディタモード中は、カメラ設定が変わりうるためInitializeCameraを呼ぶ
                InitializeCamera(); 
                UpdateRectWithCheck(true); // エディタでの設定変更チェック
            }
            else
            {
                UpdateRectWithCheck(false); // プレイモード中は効率的なチェック
            }
        }

        /// <summary>
        /// 参照カメラのキャッシュを初期化または更新する
        /// </summary>
        private void InitializeCamera()
        {
            // 設定があればそちらを優先
            _targetCamera = refCamera != null ? refCamera : Camera.main;
        }

        /// <summary>
        /// 幅、高さ、match設定に変更があった場合にのみRectTransformを更新する
        /// </summary>
        public void UpdateRectWithCheck(bool forceUpdate = false)
        {
            if (refRect == null) return;
            if (_targetCamera == null)
            {
                 InitializeCamera();
            }
            if (_targetCamera == null) return;

            var rect = _targetCamera.rect;
            var width = rect.width * Screen.width;
            var height = rect.height * Screen.height;

            // キャッシュと比較して変更がなければ終了（強制更新フラグが立っている場合を除く）
            if (!forceUpdate 
                && Mathf.Approximately(_widthCache, width)
                && Mathf.Approximately(_heightCache, height)
                && Mathf.Approximately(_matchCache, matchWidthOrHeight))
            {
                return;
            }

            UpdateRectInternal(width, height);
        }

        /// <summary>
        /// RectTransformのスケールとサイズを計算・適用する（位置ずれ防止処理を含む）
        /// </summary>
        private void UpdateRectInternal(float width, float height)
        {
            if (refRect == null 
                || Mathf.Approximately(referenceResolution.x, 0f) 
                || Mathf.Approximately(referenceResolution.y, 0f)
                || width == 0f 
                || height == 0f)
            {
                return;
            }
            
            // ==========================================================
            // 【UIの位置ずれ防止のための強制固定処理】
            // アンカーとピボットを中央 (0.5, 0.5) に固定し、オフセットをリセットすることで、
            // 親要素の中心をビューポートの中心に保持する。
            refRect.anchorMin = new Vector2(0.5f, 0.5f);
            refRect.anchorMax = new Vector2(0.5f, 0.5f);
            refRect.pivot = new Vector2(0.5f, 0.5f);
            refRect.anchoredPosition = Vector2.zero;
            // ==========================================================
            
            // Canvas Scalerのロジックを引用してスケールを計算
            var logWidth = Mathf.Log(width / referenceResolution.x, LogBase);
            var logHeight = Mathf.Log(height / referenceResolution.y, LogBase);
            
            var logWeightedAverage = Mathf.Lerp(logWidth, logHeight, matchWidthOrHeight);
            var scale = Mathf.Pow(LogBase, logWeightedAverage);

            if (float.IsNaN(scale) || scale <= 0f)
            {
                return;
            }

            // 1. スケールを適用
            refRect.localScale = new Vector3(scale, scale, scale);

            // 2. スケールで小さくなった分を打ち消すようにサイズ（sizeDelta）を調整し、ビューポート全体をカバーさせる
            var revScale = 1f / scale;
            refRect.sizeDelta = new Vector2(width * revScale, height * revScale);

            // キャッシュを更新
            _widthCache = width;
            _heightCache = height;
            _matchCache = matchWidthOrHeight;
        }
        
        /// <summary>
        /// 外部からRectTransformの更新を強制する public メソッド
        /// </summary>
        public void UpdateRect(bool force = true)
        {
            InitializeCamera();
            UpdateRectWithCheck(force);
        }
    }
}