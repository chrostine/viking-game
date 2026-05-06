using UnityEngine;

public class Mount : MonoBehaviour
{
    private bool _isMounted = false;
    private bool _isPlayerNear = false;

    public float SpeedMultiplierWhenMounted = 1.4f;
    public Vector3 ParentingOffset = Vector3.zero;
    
    public PlayerControls playerControls;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _isPlayerNear = true;
            Debug.Log("Player is near the mount. Press 'E' to mount.");
        }
    }

    void onTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _isPlayerNear = false;
            Debug.Log("Player left the mount area.");
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _isPlayerNear)
        {
            _isMounted = !_isMounted; // toggle mount state
            playerControls.moveSpeedMultiplier = _isMounted ? SpeedMultiplierWhenMounted : 1f; // juster spillerens hastighed baseret på mount state
            transform.parent = _isMounted ? playerControls.transform : null; // sæt mountens parent til spilleren, når den er mounted, og fjern den, når den er dismounted
            transform.localPosition = _isMounted ? ParentingOffset : transform.localPosition; // juster mountens position, når den er mounted
            playerControls.CurrentMount = _isMounted ? this : null; // opdater spillerens reference til den nuværende mount
            Debug.Log(_isMounted ? "Mounted!" : "Dismounted!");
        }
    }

    public GameObject TurnOnOnDeath;
    public void Kill()
    {
        if (TurnOnOnDeath != null)
        {
            TurnOnOnDeath.transform.parent = null;
            TurnOnOnDeath.SetActive(true);
        }
        Destroy(gameObject);
    }
}