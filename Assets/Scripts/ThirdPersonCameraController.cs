using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Cinemachine;

public class ThirdPersonCameraController : MonoBehaviour
{

    [SerializeField] private float zoomSpeed;
    [SerializeField] private float zoomLerpSpeed;
    [SerializeField] private float minDistance;
    [SerializeField] private float maxDistance;


    private Player controls;
    private CinemachineCamera cam;
    private CinemachineOrbitalFollow orbital;
    // Stores the difference of the scroll
    private Vector2 scrollDelta;

    private float targetZoom;
    private float currentZoom;


    //public InputActionReference CameraActionReference;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controls = new Player();
        controls.Enable();
        controls.CameraControls.MouseZoom.performed += HandleMouseScroll;

        Cursor.lockState = CursorLockMode.Locked;

        cam = GetComponent<CinemachineCamera>();    
        orbital = cam.GetComponent<CinemachineOrbitalFollow>();

        targetZoom = currentZoom = orbital.Radius;
    }

    private void HandleMouseScroll(InputAction.CallbackContext context)
    {
        scrollDelta = context.ReadValue<Vector2>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(scrollDelta.y != 0)
        {
            if(orbital != null)
            {
                targetZoom = Mathf.Clamp(orbital.Radius - scrollDelta.y * zoomSpeed, minDistance, maxDistance);
                scrollDelta = Vector2.zero;
            }
        }
        currentZoom= Mathf.Lerp(currentZoom,targetZoom,Time.deltaTime * zoomLerpSpeed);
        orbital.Radius = currentZoom;
    }
}
