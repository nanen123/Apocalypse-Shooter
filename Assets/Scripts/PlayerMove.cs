using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody rig;
    private Vector3 moveVector;
    private bool isFiring;
    [SerializeField] private InputAction moveAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rig = GetComponent<Rigidbody>();
        moveAction = InputSystem.actions.FindAction("Move");
    }
    private void Update()
    {
        rig.linearVelocity = moveAction.ReadValue<Vector3>();
    }

}
