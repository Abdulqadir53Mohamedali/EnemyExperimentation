using UnityEngine;
using UnityEngine.InputSystem;
//using UnityEngine.


public class PlayerMovement : MonoBehaviour
{

    public Rigidbody m_rigidbody;
    public float m_moveSpeed = 5f;
    [SerializeField] private Transform m_CameraTransform;

    private Vector2 m_movementInput;
    public  InputActionReference m_movementActionReference;
    public  InputActionReference m_JumpActionReference;

    public bool m_isGrounded;
    private float jumpRaycastDistance = 0.2f;
    [SerializeField] private float m_jumpForce = 5f;
    private float m_jumpCount = 1f;
    private float m_maxJumpCount = 2f;

    public Transform jumpPoint;
    //private bool wasGrounded = false; // Add this as a class-level variable
    [SerializeField] private LayerMask groundLayer;


    private void Update()
    {
        m_movementInput = m_movementActionReference.action.ReadValue<Vector2>();
    }

    private void Awake()
    {

        m_rigidbody =  this.GetComponent<Rigidbody>();


    }
    private void CheckGrounded()
    {
        RaycastHit hit;
        m_isGrounded = Physics.Raycast(jumpPoint.position, Vector3.down ,out hit,jumpRaycastDistance, groundLayer);


        if (m_isGrounded == true)
        {
             m_jumpCount = 1;
            Debug.Log("I am Zero");
        }
 

        
    }
    private void Start()
    {
       
    }
    private void OnEnable()
    {
        m_movementActionReference.action.Enable();
        m_JumpActionReference.action.Enable();
        m_JumpActionReference.action.performed += OnJumpp;

    }
    private void OnDisable()
    {
        m_JumpActionReference.action.performed -= OnJumpp;
        m_movementActionReference.action.Disable();
        m_JumpActionReference.action.Disable();

    }

 
    public void OnJumpp(InputAction.CallbackContext context)
    {


        if (context.performed && m_jumpCount < m_maxJumpCount)
        {
            m_rigidbody.AddForce(Vector3.up * m_jumpForce, ForceMode.Impulse);
            m_jumpCount++;
        }
        Debug.Log(m_jumpCount); 
    }
     
    private void FixedUpdate()
    {
        CheckGrounded();
        Vector3 forward = m_CameraTransform.forward;
        Vector3 right = m_CameraTransform.right;

        forward.Normalize();
        right.Normalize();

        forward.y = 0;
        right.y = 0;
        //// Combines the camera orientation and input direction
        Vector3 moveDirection = (right * m_movementInput.x + forward * m_movementInput.y).normalized;

        m_rigidbody.AddForce(moveDirection * m_moveSpeed, ForceMode.Acceleration);

        

    }
}
