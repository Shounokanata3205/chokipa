using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float jumpForce = 12f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;

    // 追加：インスペクターで設定するためのAudioSource
    public AudioSource jumpAudioSource;

    private Rigidbody2D rb;
    private Animator anim;
    private bool isGrounded;
    private float moveInputFromButton;
    private bool facingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // 地面判定の更新
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // デバッグ用（Sceneビューで判定を確認。緑＝接地中、赤＝空中）
        Debug.DrawLine(groundCheck.position, groundCheck.position + Vector3.down * groundCheckRadius, isGrounded ? Color.green : Color.red);

        // 移動入力
        float h = Input.GetAxisRaw("Horizontal");
        float finalInput = Mathf.Clamp(h + moveInputFromButton, -1f, 1f);

        // アニメーション
        if (anim != null) anim.SetBool("isWalking", Mathf.Abs(finalInput) > 0.01f);

        // 向き
        if (finalInput > 0 && !facingRight) Flip();
        else if (finalInput < 0 && facingRight) Flip();

        // PC用ジャンプ
        if (Input.GetButtonDown("Jump") && isGrounded) Jump();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float finalInput = Mathf.Clamp(h + moveInputFromButton, -1f, 1f);
        rb.velocity = new Vector2(finalInput * moveSpeed, rb.velocity.y);
    }

    public void Move(float input) => moveInputFromButton = input;
    public void StopMoving() => moveInputFromButton = 0f;

    public void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            // 追加：オーディオの再生
            if (jumpAudioSource != null)
            {
                jumpAudioSource.Play();
            }

            Debug.Log("ジャンプ成功！");
        }
        else
        {
            Debug.Log("地面にいないので飛べません。判定の円が赤くなっていませんか？");
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //コインオブジェクトの消滅,コイン加算
        if (collision.gameObject.CompareTag("Coin"))
        {
            main.Coin += 1;
            Destroy(collision.gameObject);
        }
    }
}