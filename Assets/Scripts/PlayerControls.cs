using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 currentVelocity;
    private int powerUpCount = 0;
    private float acceleration;
    private float deceleration;

    public float moveSpeed = 4f;

    [Header("Player accerleration")]
    public int maxPowerUps = 10; // det maksimale antal powerups du forventer at spilleren kan samle
    public AnimationCurve accelerationCurve;
    public AnimationCurve decelerationCurve;

    void Start()
    {
      rb = GetComponent<Rigidbody2D>();
      UpdateMovementStats();
    }

  //Håndterer spillerens input for bevægelse og opdaterer spillerens position i FixedUpdate for at sikre jævn bevægelse.
    void Update()
    {
    moveInput.x = Input.GetAxisRaw("Horizontal");
    moveInput.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
      Vector2 targetVelocity = moveInput.normalized * moveSpeed;

      // vælger acceleration eller deceleration afhængigt af om spilleren bevæger sig
      float smoothSpeed = moveInput == Vector2.zero ? deceleration : acceleration;
      currentVelocity = Vector2.Lerp(currentVelocity,targetVelocity,smoothSpeed);

      rb.linearVelocity = currentVelocity;
    }
 //viser hvor mange powerups spilleren har samlet, og øger tælleren hver gang en powerup bliver samlet op.
    public void CollectPowerUp()
    {
      powerUpCount++;
      Debug.Log("PowerUps collected: " + powerUpCount);
      UpdateMovementStats();
    }

// håndterer acceleration og deceleration, som er afhængig af collected Powerups.
    private void UpdateMovementStats ()
    {
      float t = Mathf.Clamp01((float)powerUpCount/maxPowerUps);
      acceleration = accelerationCurve.Evaluate(t);
      deceleration = decelerationCurve.Evaluate(t);
      Debug.Log("moveSpped: " + moveSpeed);
      Debug.Log("acceleration: " + acceleration);
      Debug.Log("deceleration: " + deceleration);
    }
}
