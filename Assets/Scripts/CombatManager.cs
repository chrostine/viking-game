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
 //Når spilleren rammer i reaction baren, skal der spawne en øl på fjendens position, fjenden skal forsvinde og reaction baren skal deaktiveres. Hvis spilleren misser, skal spilleren forsvinde og reaction baren deaktiveres.
    public void OnHit()
{
    
        Instantiate(beer, enemy.transform.position, Quaternion.identity);
        Destroy(enemy);
        enemy = null;
        reactionBar.Deactivate();
        kills += 1;
        reactionBar.SetDifficulty(kills);
    
}
//Når spilleren misser, skal spilleren forsvinde og reaction baren deaktiveres.
    public void OnMiss()
    {
        player.SetActive(false);
        reactionBar.Deactivate();
    }
}
