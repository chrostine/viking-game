using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public ReactionBar reactionBar;
    public GameObject enemy;
    public GameObject player;
    public GameObject beer;

    private int kills = 0;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void OnHit()
{
    
        Instantiate(beer, enemy.transform.position, Quaternion.identity);
        Destroy(enemy);
        enemy = null;
        reactionBar.Deactivate();
        kills += 1;
        reactionBar.SetDifficulty(kills);
    
}

    public void OnMiss()
    {
        player.SetActive(false);
        reactionBar.Deactivate();
    }
}
