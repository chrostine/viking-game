using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public float yOffset = 1f;
    public Transform Target;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 targetPosition = new Vector3(Target.position.x, Target.position.y + yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, targetPosition, FollowSpeed * Time.deltaTime);
    }
}
