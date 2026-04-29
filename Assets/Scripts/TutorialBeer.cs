using UnityEngine;

public class TutorialBeer : MonoBehaviour

{
    public ReactionBar reactionBar;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            reactionBar.Activate();
        }
    }
}
