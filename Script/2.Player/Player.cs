using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField]
    public PlayerInputsManager input;

    public Animator anim;
    public CharacterController controller;
    public Transform cam;

    float speed = 4;//6.4f;
    float acceleration = 64;
    float deceleration = 96;
    float sprint = 1.6f;
    float jumpPower = 4;//10.24f;
    float gravityMultiplier = 3.2f;

    Vector2 direction;
    Vector3 velocity;

    private bool grounded;

    [SerializeField] private Dialogue dialogue;
    public Dialogue Dialogue => dialogue;

    public IInteractable Interactable { get; set; }

    #region
    [Tooltip("How fast the character turns to face movement direction")]
    [Range(0.0f, 0.3f)]
    public float RotationSmoothTime = 0.12f;

    [Header("Cinemachine")]
    [Tooltip("The follow target set in the Cinemachine Virtual Camera that the camera will follow")]
    public GameObject CinemachineCameraTarget;

    [Tooltip("How far in degrees can you move the camera up")]
    public float TopClamp = 70.0f;

    [Tooltip("How far in degrees can you move the camera down")]
    public float BottomClamp = -30.0f;

    [Tooltip("Additional degress to override the camera. Useful for fine tuning camera position when locked")]
    public float CameraAngleOverride = 0.0f;

    [Tooltip("For locking the camera position on all axis")]
    public bool LockCameraPosition = false;

    // cinemachine
    private float _cinemachineTargetYaw;
    private float _cinemachineTargetPitch;
    private GameObject _mainCamera;

    private const float _threshold = 0.01f;
    private void Awake()
    {
        // get a reference to our main camera
        if (_mainCamera == null)
        {
            _mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        }
    }
    #endregion
    void Start()
    {
        controller = GetComponent<CharacterController>();
        _cinemachineTargetYaw = CinemachineCameraTarget.transform.rotation.eulerAngles.y;
        _cinemachineTargetPitch = 30f;
        if (input == null)
        {
            return;
        }
    }

    void Update()
    {
        MoveInput();

        if (dialogue != null && dialogue.IsOpen)
            return;

        if (input.interact)
        {
            Interactable?.Interact(player: this);
            input.interact = false;
        }
    }

    void FixedUpdate()
    {
        MoveOutput();
    }
    private void LateUpdate()
    {
        CameraRotation();
    }

    private void CameraRotation()
    {
        // if there is an input and camera position is not fixed
        if (input.look.sqrMagnitude >= _threshold && !LockCameraPosition)
        {
            //Don't multiply mouse input by Time.deltaTime;
            float deltaTimeMultiplier =  Time.deltaTime;


            _cinemachineTargetYaw += input.look.x * deltaTimeMultiplier;
            _cinemachineTargetPitch += input.look.y * deltaTimeMultiplier;
        }

        // clamp our rotations so our values are limited 360 degrees
        _cinemachineTargetYaw = ClampAngle(_cinemachineTargetYaw, float.MinValue, float.MaxValue);
        _cinemachineTargetPitch = ClampAngle(_cinemachineTargetPitch, BottomClamp, TopClamp);

        // Cinemachine will follow this target
        CinemachineCameraTarget.transform.rotation = Quaternion.Euler(_cinemachineTargetPitch + CameraAngleOverride,
            _cinemachineTargetYaw, 0.0f);
    }

    private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
    {
        if (lfAngle < -360f) lfAngle += 360f;
        if (lfAngle > 360f) lfAngle -= 360f;
        return Mathf.Clamp(lfAngle, lfMin, lfMax);
    }

    void MoveInput()
    {
        direction = input.move;
        direction.Normalize();

        float lookAxis = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg + cam.eulerAngles.y;
        Vector3 direction3 = Quaternion.Euler(0, lookAxis, 0) * Vector3.forward;
        direction3.Normalize();

        if (!controller.isGrounded)
        {
            velocity.y += gravityMultiplier * Physics.gravity.y * Time.deltaTime;
        }

        if (direction != Vector2.zero)
        {
            anim.SetBool("isWalk", true);
            if (input.sprint) //(Input.GetButton("Sprint"))
            {
                anim.SetBool("isSprint", true);
                velocity.x = Mathf.MoveTowards(velocity.x, speed * sprint * direction3.x, acceleration * sprint * Time.deltaTime);
                velocity.z = Mathf.MoveTowards(velocity.z, speed * sprint * direction3.z, acceleration * sprint * Time.deltaTime);
            }
            else
            {
                anim.SetBool("isSprint", false);
                velocity.x = Mathf.MoveTowards(velocity.x, speed * direction3.x, acceleration * Time.deltaTime);
                velocity.z = Mathf.MoveTowards(velocity.z, speed * direction3.z, acceleration * Time.deltaTime);
            }
            //회전 복붙
            Vector3 inputDir = new Vector3(input.move.x, 0, input.move.y);
            float targetRotation = Quaternion.LookRotation(inputDir).eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0, targetRotation, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 20 * Time.deltaTime);
        }
        else
        {
            anim.SetBool("isWalk", false);
            anim.SetBool("isSprint", false);
            velocity.x = Mathf.MoveTowards(velocity.x, 0, deceleration * Time.deltaTime);
            velocity.z = Mathf.MoveTowards(velocity.z, 0, deceleration * Time.deltaTime);
        }

        if (controller.isGrounded && input.jump) //(Input.GetButtonDown("Jump"))
        {
            anim.SetBool("isJump", true);
            velocity.y = Mathf.Sqrt(2*jumpPower * Mathf.Abs(Physics.gravity.y));
        }
        else anim.SetBool("isJump", false);
    }

    void MoveOutput()
    {
        controller.Move(velocity * Time.fixedDeltaTime);
    }
}