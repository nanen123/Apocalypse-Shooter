using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMove : MonoBehaviour
{
    private InputAction mouseXMoveAction;
    private InputAction mouseYMoveAction;

    private float rotX; // ∏∂øÏΩ∫ ¿Œ«≤
    private float rotY;

    public Transform objectTofollow;
    public float sensitivity;
    public float clampAngle;

    public Transform cam;
    private Vector3 dirNormalized; // πÊ«‚ ∫§≈Õ
    private Vector3 finalDir;
    public float minDistance;
    public float maxDistance;
    public float finalDistance;

    void Awake()
    {
        mouseXMoveAction = InputSystem.actions.FindAction("MouseXAxis");
        mouseYMoveAction = InputSystem.actions.FindAction("MouseYAxis");

        rotX = transform.localRotation.eulerAngles.x;
        rotY = transform.localRotation.eulerAngles.y;

        dirNormalized = cam.localPosition.normalized;
        finalDistance = cam.localPosition.magnitude;
    }

    void Update()
    {
        rotX -= mouseYMoveAction.ReadValue<float>() * sensitivity * Time.deltaTime;
        rotY += mouseXMoveAction.ReadValue<float>() * sensitivity * Time.deltaTime;
        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);
        Quaternion rot = Quaternion.Euler(rotX, rotY, 0);

        transform.rotation = rot;
    }

    private void LateUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, objectTofollow.position, 10f * Time.deltaTime);

        finalDir = transform.TransformPoint(dirNormalized * maxDistance);
        cam.localPosition = Vector3.Lerp(cam.localPosition, dirNormalized * finalDistance, Time.deltaTime);
    }
}
