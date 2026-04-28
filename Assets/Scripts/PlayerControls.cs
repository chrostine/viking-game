using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    
    private Rigidbody2D rb;
    private Vector2 moveInput;
    public float moveSpeed = 4f;
    private int powerUpCount = 0;

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

    public void CollectPowerUp()
    {
      powerUpCount++;
      Debug.Log("PowerUps collected: " + powerUpCount);
    }
}
