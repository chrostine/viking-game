using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialBeer : MonoBehaviour
{
    public ReactionBar reactionBar;
 //Når spilleren kommer ind i triggeren, skal reaction baren blive aktiv og spilleren skal kunne ramme i den for at gå videre til næste scene.
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            reactionBar.Activate();
        }
    }
//Når spilleren rammer i reaction baren, skal reaction baren deaktiveres, øllen skal forsvinde og næste scene skal loades. Hvis spilleren misser, skal reaction baren deaktiveres
   public void OnHit()
{
    reactionBar.Deactivate();
    Destroy(gameObject);
    SceneManager.LoadScene(1);
}

    public void OnMiss()
    {
        
    }
}