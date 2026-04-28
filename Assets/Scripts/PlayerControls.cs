using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    
    private Rigidbody2D rb;
    private Vector2 moveInput;
    public float moveSpeed = 4f;

    void Start()
    {
      rb = GetComponent<Rigidbody2D>();  
    }

    void Update()
    {
    moveInput.x = Input.GetAxisRaw("Horizontal");
    moveInput.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }
}
