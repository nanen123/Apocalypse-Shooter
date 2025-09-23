using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private Rigidbody rig;
    private Vector3 moveVector;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        rig.linearVelocity = moveVector * 3;
    }
    public void OnMove(InputValue value)
    {
        Debug.Log(value.Get<Vector3>());
        moveVector = value.Get<Vector3>();
    }
}
