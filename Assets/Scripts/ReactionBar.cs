using UnityEngine;

public class ReactionBar : MonoBehaviour
{
    public RectTransform needle;
    public GameObject barBackground;

    private float speed = 0.5f;
    private float currentPosition;
    private int direction = 1; 

    void Start()
    {
        
    }

    void Update()
    {
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

       needle.anchoredPosition = new Vector2(Mathf.Lerp(-300f, 300f, currentPosition),0);
    
    }
}
