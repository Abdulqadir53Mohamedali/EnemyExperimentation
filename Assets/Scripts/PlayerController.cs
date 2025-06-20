using UnityEngine;
using UnityEngine.InputSystem;

namespace EnemyExperimentation
{
    public class PlayerController : MonoBehaviour
    {
        public Rigidbody m_rigidbody;
        public Animator m_animator;
        public float m_moveSpeed = 5f;
        [SerializeField] private Transform m_CameraTransform;

        public  Vector2 m_movementInput;
        public InputActionReference m_movementActionReference;
        public InputActionReference m_JumpActionReference;

        public bool m_isGrounded;
        private float jumpRaycastDistance = 0.2f;
        [SerializeField] private float m_jumpForce = 5f;
        private float m_jumpCount = 0f;
        private float m_maxJumpCount = 2f;

        public bool m_jumpRequested;

        public Transform jumpPoint;
        //private bool wasGrounded = false; // Add this as a class-level variable
        [SerializeField] private LayerMask groundLayer;

        public StateMachine stateMachine;

        public IdleState IdleState { get; private set; }
        public WalkingState WalkingState { get; private set; }
        public JumpState JumpState { get; private set; }


        private void Update()
        {
            m_movementInput = m_movementActionReference.action.ReadValue<Vector2>();
            stateMachine.Update();
        }

        private void Awake()
        {

            m_rigidbody = this.GetComponent<Rigidbody>();
            m_animator = this.GetComponent<Animator>();

            stateMachine = new StateMachine();

            // Decalre states 
            JumpState = new JumpState(this, m_animator);
            WalkingState = new WalkingState(this, m_animator);
            IdleState = new IdleState(this, m_animator);

            Any(JumpState, new FuncPredicate(() => m_jumpRequested));
            //Any(jumpState, () => m_jumpRequested);
            At(from: WalkingState, to: IdleState, condition: new FuncPredicate(() => m_movementInput.sqrMagnitude == 0.00f && m_isGrounded));
            At(from: IdleState, to: WalkingState, condition: new FuncPredicate(() => m_movementInput.sqrMagnitude >= 0.01f));
            //At(from: IdleState, to: JumpState, condition: new FuncPredicate(() => m_jumpRequested == true));
            //At(from: WalkingState, to: JumpState, condition: new FuncPredicate(() => m_jumpRequested == true ));
            //At(from: JumpState, to: WalkingState, condition: new FuncPredicate(() => m_isGrounded == true && m_movementInput.sqrMagnitude >= 0.01f));

            stateMachine.SetState(IdleState);
        }

        void At(IState from, IState to, IPredicate condition) => stateMachine.AddTransition(from, to, condition);
        void Any(IState from, IPredicate condition) => stateMachine.AddAnyTransition(from, condition);

        private void CheckGrounded()
        {
            RaycastHit hit;
            m_isGrounded = Physics.Raycast(jumpPoint.position, Vector3.down, out hit, jumpRaycastDistance, groundLayer);


            if (m_isGrounded == true)
            {
                m_jumpCount = 0;
                //Debug.Log("I am Zero");
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

        public void HandleJump()
        {
            m_rigidbody.AddForce(Vector3.up * m_jumpForce, ForceMode.Impulse);
            m_jumpCount++;
            m_jumpRequested = false;
        }
        public void OnJumpp(InputAction.CallbackContext context)
        {


            if (context.performed && m_jumpCount < m_maxJumpCount)
            {
                Debug.Log("Jump is pressed");
                m_jumpRequested = true;
            }
            Debug.Log(m_jumpCount);
        }
        public void Walking()
        {
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

        private void FixedUpdate()
        {
            CheckGrounded();
            //Walking();
            stateMachine.FixedUpdate();



        }
    }


}
