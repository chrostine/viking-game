using UnityEngine;

public class PlayerFlip : MonoBehaviour
{
    private Vector3 originalScale;
    private Vector2 moveInput;

    void Start()
    {
        originalScale = transform.localScale; // Fjernet rb og UpdateMovementStats - hører ikke til her
    }

    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");

        if (moveInput.x > 0)
            transform.localScale = new Vector3(-originalScale.x, originalScale.y, originalScale.z);
        else if (moveInput.x < 0)
            transform.localScale = new Vector3(originalScale.x, originalScale.y, originalScale.z);
    }
}