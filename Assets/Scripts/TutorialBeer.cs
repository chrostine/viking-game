using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialBeer : MonoBehaviour
{
    public ReactionBar reactionBar;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            reactionBar.Activate();
        }
    }

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