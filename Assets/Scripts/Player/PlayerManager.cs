using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }

    private PlayerMovement playerMovement;
    private CameraRotation cameraRotation;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        cameraRotation = GetComponent<CameraRotation>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
