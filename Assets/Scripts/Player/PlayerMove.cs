using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody rig;
    [SerializeField] private InputAction moveAction;
    private Vector3 moveVector;

    [SerializeField] private InputAction moveTriggerAction;
    private bool moveTrigger;

    public float moveSpeed;

    public Transform cam;

    void Awake()
    {
        rig = GetComponent<Rigidbody>();
        moveAction = InputSystem.actions.FindAction("Move");
        moveTriggerAction = InputSystem.actions.FindAction("MoveTrigger");
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (moveAction.IsPressed())
        {
            moveVector = moveAction.ReadValue<Vector3>();
            Vector3 dir = (cam.transform.localRotation * Vector3.forward) * moveVector.z + (cam.transform.localRotation * Vector3.right) * moveVector.x;
            dir.y = 0;
            dir.Normalize();
            rig.linearVelocity = dir * moveSpeed;
            transform.LookAt(dir + transform.position);
        }
    }

}
