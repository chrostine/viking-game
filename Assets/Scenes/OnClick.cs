using UnityEngine;
using UnityEngine.Events;

public class OnClick : MonoBehaviour
{
    public UnityEvent onClick;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            onClick?.Invoke();
        }
    }
}
