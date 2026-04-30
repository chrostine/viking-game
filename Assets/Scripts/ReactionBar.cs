using UnityEngine;

public class ReactionBar : MonoBehaviour
{
    public RectTransform needle;
    public GameObject barBackground;
    public CombatManager combatManager;
    public RectTransform hitZone;
    public TutorialBeer tutorialBeer;

    private float speed = 0.5f;
    private float currentPosition;
    private int direction = 1; 

    private bool isActive = false;

    //baren er ikke vist i starten
    void Start()
    {
    barBackground.SetActive(false);
    }

    //metoder til at aktivere og deaktivere reaction baren, som bliver kaldt fra andre scripts når spilleren kommer ind i en trigger eller rammer/misser i reaction baren.
    public void Activate(){
        barBackground.SetActive(true);
        isActive = true;
    }
    
    public void Deactivate(){
        barBackground.SetActive(false);
        isActive = false;
    }

    //opdaterer positionen af nålen i reaction baren, og håndterer input for at afgøre om spilleren rammer eller misser.
    void Update()
    {
        if (isActive == true){
        //flytter "nålen"
        currentPosition += (speed*direction*Time.deltaTime);

        if (currentPosition >= 1)
        {
            currentPosition = 1;
            direction = -1;
        }
        if (currentPosition <= 0)
            {
                currentPosition = 0;
                direction = 1;
            }
    //opdaterer nålens position i UI baseret på currentPosition, som varierer mellem 0 og 1.
       needle.anchoredPosition = new Vector2(Mathf.Lerp(-300f, 300f, currentPosition),0);

    //håndterer input for at afgøre om spilleren rammer eller misser ved at trykke på space, og sammenligner nålens position med hit zonen for at afgøre resultatet.
        if (Input.GetKeyDown(KeyCode.Space))
        {
           float hitZoneCenter = 0.5f;
            float hitZoneHalfWidth = (hitZone.sizeDelta.x / 600f) * 0.5f;
            if (currentPosition >= hitZoneCenter - hitZoneHalfWidth && currentPosition <= hitZoneCenter + hitZoneHalfWidth)
            {
                if (combatManager != null) combatManager.OnHit();
                if (tutorialBeer != null) tutorialBeer.OnHit();
            }
            else
            {
                if (combatManager != null) combatManager.OnMiss();
                if (tutorialBeer != null) tutorialBeer.OnMiss();
            }

             }
        }
    }
 //metode til at øge sværhedsgraden i reaction baren ved at øge hastigheden og gøre hit zonen mindre for hver fjende spilleren har besejret.
    public void SetDifficulty(int kills)
    {
        speed = 0.5f + (kills * 0.15f);
        Debug.Log("Speed er nu: " + speed);

        hitZone.sizeDelta = new Vector2(100f - (kills * 15f), hitZone.sizeDelta.y);
    }
}

    