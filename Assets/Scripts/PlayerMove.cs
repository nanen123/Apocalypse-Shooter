using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody rig;
    [SerializeField] private InputAction moveAction;

    [SerializeField] private Vector3 moveVector;
    public float moveSpeed;

    [SerializeField] private Vector3 rotVector; // ������ �� ȸ���� ���� ����
    [SerializeField] private float rotSpeed;
    [SerializeField] private bool isFiring;

    [SerializeField] public Transform cam;
    public Vector3 temp;

    void Awake()
    {
        rig = GetComponent<Rigidbody>();
        moveAction = InputSystem.actions.FindAction("Move");
    }

    private void Update()
    {
        moveVector = moveAction.ReadValue<Vector3>();
        Vector3 dir = (cam.transform.localRotation * Vector3.forward) * moveVector.z + (cam.transform.localRotation * Vector3.right) * moveVector.x;
        dir.y = 0;
        dir.Normalize();
        Debug.Log(dir);
        rig.linearVelocity = dir * moveSpeed;

        //rotVector = transform.position + moveVector;
        //if (moveVector != Vector3.zero)
        //    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(rotVector - transform.position), Time.deltaTime * rotSpeed);
    }

}
