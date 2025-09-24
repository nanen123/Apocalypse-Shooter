using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private Rigidbody rig;
    private Vector3 moveVector;
    private bool isFiring;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        rig.linearVelocity = moveVector * 3;
        Debug.Log(isFiring);
    }
    public void OnMove(InputValue value)
    {
        Debug.Log(value.Get<Vector3>());
        moveVector = value.Get<Vector3>();
    }

    public void OnMouseClick(InputValue value)
    {
       isFiring = value.isPressed;
    }
}
