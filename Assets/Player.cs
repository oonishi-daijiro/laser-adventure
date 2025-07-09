using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public sealed class Player : MonoBehaviour
{
    // initalized inspector
    public float movePower;
    public float jumpPower;
    public float maxSpeed;
    public float sens;
    public GameObject head;
    public float maxVertialHeadRotationAngle = 90f;
    public float minVerticalHeadRotationAngle = -90f;
    public Animator animator;

    private Vector2 inputAxis;
    private Rigidbody rigidBdy;
    private bool isOnGround = true;
    private Vector2 mouseDelta = new(0.0f, 0.0f);
    private float horizonalRotationAngle = 0.0f;
    private float vertivalRotationAngle = 0.0f;


    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rigidBdy = gameObject.GetComponent<Rigidbody>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        // x: A/D   (-1/1)
        // y: W/S   (1/-1)
        inputAxis = context.ReadValue<Vector2>();
        if (inputAxis.Equals(Vector2.zero))
        {
            animator.SetTrigger("Idle");
            animator.SetBool("Running", false);
        }
        else if (inputAxis.Equals(new Vector2(0, 1)))
        {
            animator.SetBool("Running", true);
        }

    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (isOnGround)
        {
            animator.SetTrigger("Jump");
            rigidBdy.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }

    void Update()
    {

        if (rigidBdy.linearVelocity.magnitude < maxSpeed)
        {
            rigidBdy.AddRelativeForce(movePower * new Vector3(inputAxis.x, 0, inputAxis.y));
        }
    }
    void LateUpdate()
    {
        horizonalRotationAngle += mouseDelta.x * sens;

        var newVerticalRotationAngle = vertivalRotationAngle - mouseDelta.y * sens;
        if (minVerticalHeadRotationAngle < newVerticalRotationAngle && newVerticalRotationAngle < maxVertialHeadRotationAngle)
        {
            vertivalRotationAngle = newVerticalRotationAngle;
        }
        head.transform.rotation = Quaternion.Euler(vertivalRotationAngle, horizonalRotationAngle, 0);
        rigidBdy.transform.rotation = Quaternion.Euler(0, horizonalRotationAngle, 0);
    }
}
