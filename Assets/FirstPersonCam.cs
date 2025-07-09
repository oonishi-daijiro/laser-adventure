using System.Dynamic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonCam : MonoBehaviour
{
    [SerializeField] public GameObject playerHead;
    float verticalRotAngle;
    float horizonalRotAngle;
    Vector2 mouseDelta;

    private GameObject cam;

    void Start()
    {
        cam = gameObject;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }

    void LateUpdate()
    {
        var pos = playerHead.transform.position;
        horizonalRotAngle += mouseDelta.x;

        var newVerticalRotationAngle = verticalRotAngle + mouseDelta.y * -0.2f;
        if (-90 < newVerticalRotationAngle && newVerticalRotationAngle < 90)
        {
            verticalRotAngle = newVerticalRotationAngle;
        }
        cam.transform.rotation = Quaternion.Euler(verticalRotAngle, horizonalRotAngle, 0);

        // pos.y += 0.2f;
        // pos.z += 0.8f;
        cam.transform.position = pos;
    }
}
