using UnityEngine;

public class playerController : MonoBehaviour
{
    Rigidbody2D r2d;
    float move;
    Vector2 moveInput;

    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] bool IsJumpping = false;
    
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        r2d.AddForce(moveInput * speed);


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
