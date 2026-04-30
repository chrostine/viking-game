using UnityEngine;

public class Beer : MonoBehaviour
{
   //ølllen som spawner efter et kill og automatisk forsvinder etfer 11 sekund.
    void Start()
    {
        Destroy(gameObject, 1f);
    }

    void Update()
    {
        
    }
}
