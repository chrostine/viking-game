using UnityEngine;

public class PowerUp : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other) // kaldes, når et andet objekt rører ved triggerens collider
    {
        if (other.CompareTag("Player")) // tjekker om objektet der ramte triggeren har tagget Player
        {
            other.GetComponent<PlayerControls>().CollectPowerUp();
            
            Debug.Log("PowerUp collected by: " + other.name);

            // powerup effekt

            Destroy(gameObject); // sletter PowerUp-objektet
        }
    }
}
