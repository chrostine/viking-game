using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class OnDeath : MonoBehaviour
{
    public UnityEvent onDeath;
    public float Delay = 1f;  

    public void Die()
    {
        StartCoroutine(WaitThenTrigger());
    }

    IEnumerator WaitThenTrigger()
    {
        if (Delay > 0f)
            yield return new WaitForSeconds(Delay);

        onDeath?.Invoke();

        yield break;
    }
}
