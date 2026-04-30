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

  //Håndterer spillerens input for bevægelse og opdaterer spillerens position i FixedUpdate for at sikre jævn bevægelse.
    void Update()
    {
    moveInput.x = Input.GetAxisRaw("Horizontal");
    moveInput.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }
 //viser hvor mange powerups spilleren har samlet, og øger tælleren hver gang en powerup bliver samlet op.
    public void CollectPowerUp()
    {
      powerUpCount++;
      Debug.Log("PowerUps collected: " + powerUpCount);
    }
}
