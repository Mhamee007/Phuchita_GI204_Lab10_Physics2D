using UnityEngine;

public class playerController : MonoBehaviour
{
    Rigidbody2D r2d;
    float move;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] bool IsJumpping;
    
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        move = Input.GetAxis("Horizontal");
        r2d.velocity = new Vector2(move * speed, r2d.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && !IsJumpping)
        {
            r2d.AddForce(new Vector2(r2d.velocity.x, jumpForce));
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            IsJumpping = false;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            IsJumpping = true;
        }
    }
}
