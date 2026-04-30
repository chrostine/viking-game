using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public ReactionBar reactionBar;
    public GameObject enemy;
    public GameObject player;
    public GameObject beer;
    public GameObject deadPlayer;

    private int kills = 0;

 //Når spilleren rammer i reaction baren, skal der spawne en øl på fjendens position, fjenden skal forsvinde og reaction baren skal deaktiveres. Hvis spilleren misser, skal spilleren forsvinde og reaction baren deaktiveres.
    public void OnHit()
{
    
        GameObject spawnedBeer = Instantiate(beer, enemy.transform.position, Quaternion.identity);
        spawnedBeer.transform.localScale = beer.transform.localScale;

        Destroy(enemy);
        enemy = null;
        reactionBar.Deactivate();
        kills += 1;
        reactionBar.SetDifficulty(kills);
    
}
//Når spilleren misser, skal spilleren forsvinde og reaction baren deaktiveres.
    public void OnMiss()
    {
        Instantiate(deadPlayer, player.transform.position, Quaternion.identity);

        player.SetActive(false);
        reactionBar.Deactivate();
    }
}
