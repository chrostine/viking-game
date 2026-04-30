using UnityEngine;

public class Enemies : MonoBehaviour
{
   // private SpriteRenderer sr;
    public ReactionBar rb;
    public CombatManager combatManager;

    void Start()
    {
    //sr = GetComponent<SpriteRenderer>();
    //sr.enabled = false;
    }


    void Update()
    {
        
    }
 //Når spilleren kommer ind i triggeren, skal fjenden blive aktiv og kunne rammes i reaction baren.
    void OnTriggerEnter2D(Collider2D other)
    {
    if (other.tag == "Player")
    {
        //sr.enabled = true;
        combatManager.enemy = this.gameObject;
        rb.Activate();

    }
    }
}
